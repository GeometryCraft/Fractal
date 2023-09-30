using System.Windows.Forms;
using System.Drawing;
using System.Threading;
using System.Timers;
using Microsoft.VisualBasic.Devices;

namespace P222310546TM
{
    public partial class Form1 : Form
    {
        Color color = Color.AliceBlue;
        Color col, colOpuesto;
        int vertice, triangulo;
        List<Point[]> dibujo = new List<Point[]>();
        List<float> anchoLinea = new List<float>();
        List<Color> coloresDegradados = new List<Color>();
        List<Color> coloresTriangulos = new List<Color>();
        public Form1()
        {
            InitializeComponent();
            timer1 = new System.Windows.Forms.Timer(); // Crear el timer
            timer1.Interval = 300; // Intervalo inicial de 0.3 seg
            timer1.Tick += timer1_Tick;
        }

        private void timer1_Tick(object? sender, EventArgs e)
        {
            Graphics g = pbFractal.CreateGraphics(); // Obtener la propiedad graphics del pictureBox

            Point[] trianguloActual = dibujo[triangulo]; // Guardar los puntos del triangulo por dibujar en un arreglo

            // Dibujar las aristas del triangulo
            if (vertice < trianguloActual.Length - 1) // Conectar el punto 0 con el 1 y el 1 con el 2
            {
                g.DrawLine(new Pen(coloresTriangulos[triangulo], anchoLinea[triangulo]), trianguloActual[vertice], trianguloActual[vertice + 1]);
            }
            else // Conectar el punto 2 con el 0
            {
                g.DrawLine(new Pen(coloresTriangulos[triangulo], anchoLinea[triangulo]), trianguloActual[trianguloActual.Length - 1], trianguloActual[0]);
            }

            // Pasar al siguiente punto
            vertice++;

            // Cuando se dibujan todos los puntos del triangulo, avanzar al siguiente
            if (vertice == trianguloActual.Length)
            {
                vertice = 0; // Regresar al punto 0
                triangulo++; // Pasar al siguiente triangulo

                // Si se dibujaron todos los triangulos, detener el Timer
                if (triangulo == dibujo.Count)
                {
                    timer1.Stop();
                    // Borrar las listas para liberar memoria
                    Limpiar();
                }
            }
            // Liberar memoria del Graphics
            g.Dispose();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Configurar el form
            this.Height = 3 * Screen.PrimaryScreen.Bounds.Height / 4;
            this.Width = 2 * Screen.PrimaryScreen.Bounds.Width / 3;
            this.CenterToScreen();
            this.BackColor = Color.LightBlue;

            // Configurar y ubicar los controles respecto al form
            btnSalir.Location = new Point((this.ClientSize.Width - btnSalir.Width) / 2, this.ClientSize.Height - btnSalir.Height - 10);
            btnSkip.Location = new Point((btnSalir.Location.X - btnSkip.Width) / 2, this.ClientSize.Height - btnSalir.Height - 10);
            trackVelocidad.Location = new Point(this.ClientSize.Width - this.ClientSize.Width / 4, this.ClientSize.Height - btnSalir.Height - 10);
            lblVelocidad.Location = new Point(this.ClientSize.Width - this.ClientSize.Width / 4 - lblVelocidad.Width - 10, this.ClientSize.Height - btnSalir.Height - 10);
            btnDibujar.Location = new Point(this.ClientSize.Width - btnDibujar.Width - 10, 10);
            int controlesMedida = numNivel.Location.X + numNivel.Width;
            lblTitulo.Location = new Point(controlesMedida + (btnDibujar.Location.X - controlesMedida - lblTitulo.Width) / 2, lblTitulo.Location.Y);
            btnColor.BackColor = color;

            // Ajustar el panel
            pbFractal.Width = this.ClientSize.Width - 25;
            pbFractal.Height = this.ClientSize.Height - btnColor.Height - btnSalir.Height - 40;
        }

        private void btnColor_Click(object sender, EventArgs e) // Configurar el colorDialog
        {
            // Crea un ColorDialog
            ColorDialog colorDialog = new ColorDialog();

            // Muestra el cuadro de selección de color
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                // Guarda el color seleccionado
                color = colorDialog.Color;
            }
            // Cambiar el color del botón
            btnColor.BackColor = color;
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Application.Exit(); // Cerrar la aplicación
        }
        private void btnDibujar_Click(object sender, EventArgs e)
        {
            pbFractal.Invalidate(); // Borrar el contenido del pictureBox

            Limpiar(); // Borrar las listas

            col = color; // Guardar el color al dibujar para evitar cambios a medio proceso de dibujo
            colOpuesto = ColorOpuesto(col); // Guardar el color complementario
            for (int i = 0; i < numNivel.Value; i++) // Guardar en una lista el degradado entre el mismo numero de niveles que de colores
            {
                float proporcion = (float)i / (float)numNivel.Value;
                coloresDegradados.Add(DegradarColor(col, colOpuesto, proporcion));
            }

            Point PuntoCentro = new Point(pbFractal.Width / 2, pbFractal.Height / 2); // Punto central del picturebox
            int lado = pbFractal.Height / 2; // Asignar al lado del triangulo la mitad de la altura del pictureBox
            Fractal(PuntoCentro, (int)numNivel.Value, lado); // Llamar al método

            // Reiniciar las variables de control para el dibujo
            vertice = 0;
            triangulo = 0;

            // Iniciar el Timer para dibujar las figuras con pausas
            timer1.Start();
        }

        private void Fractal(Point centro, int nivel, int lado)
        {
            if (nivel == 0) // Caso base
            {
                return;
            }

            // Añadir al arreglo de anchuras la proporción del nivel actual respecto al nivel mayor, por cinco
            anchoLinea.Add((nivel * 5f / (float)numNivel.Value));

            // Hacer coincidir por indice los triangulos con sus colores con su respectivo degradado
            coloresTriangulos.Add(coloresDegradados[(int)numNivel.Value - nivel]);

            Point p1, p2, p3; // Generar tres puntos

            // Obtener la altura del triángulo con pitágoras
            int altura = (int)Math.Sqrt(Math.Pow(lado, 2) - Math.Pow(lado / 2, 2));

            if (cbDireccion.SelectedIndex == 1) // Crear los vertices del triangulo respecto al centro y la altura
            {
                p1 = new Point(centro.X - lado / 2, centro.Y + altura / 2);
                p2 = new Point(centro.X + lado / 2, centro.Y + altura / 2);
                p3 = new Point(centro.X, centro.Y - altura / 2);
            }
            else
            {
                p1 = new Point(centro.X - lado / 2, centro.Y - altura / 2);
                p2 = new Point(centro.X + lado / 2, centro.Y - altura / 2);
                p3 = new Point(centro.X, centro.Y + altura / 2);
            }
            // Agregar los vértices a la lista de triangulos
            Point[] puntos = { p1, p2, p3 };
            dibujo.Add(puntos);

            // Casos recursivos
            for (int i = 0; i < puntos.Length; i++)
            {
                Fractal(puntos[i], nivel - 1, lado / 2);
            }
        }

        private void cbDireccion_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnDibujar.Enabled = true; // Permitir dibujar solo cuando se elija una opción de dibujo
        }

        private void btnSkip_Click(object sender, EventArgs e) // Terminar de dibujar rápidamente
        {
            timer1.Stop(); // Detener los ticks del timer
            while (triangulo < dibujo.Count())  // Mientras haya triangulos restantes
            {
                Graphics g = pbFractal.CreateGraphics(); // Obtener la propiedad graphics del pictureBox

                // Dibujar triangulo
                g.DrawPolygon(new Pen(coloresTriangulos[triangulo], anchoLinea[triangulo]), dibujo[triangulo]);

                // Siguiente triangulo
                triangulo++;

                // Liberar memoria del Graphics
                g.Dispose();
            }
            // Borrar las listas para liberar memoria
            Limpiar();
        }
        private Color ColorOpuesto(Color original) // Encontrar el color complementario
        {
            int r = 255 - original.R;
            int g = 255 - original.G;
            int b = 255 - original.B;
            return Color.FromArgb(r, g, b);
        }
        private Color DegradarColor(Color colInicio, Color colDestino, float proporcion) // Degradar el color dependiendo de la proporcion
        {
            int r = (int)(colInicio.R + (colDestino.R - colInicio.R) * proporcion);
            int g = (int)(colInicio.G + (colDestino.G - colInicio.G) * proporcion);
            int b = (int)(colInicio.B + (colDestino.B - colInicio.B) * proporcion);
            return Color.FromArgb(r, g, b);
        }
        private void Limpiar() // Limpiar las listas usadas
        {
            dibujo.Clear();
            anchoLinea.Clear();
            coloresDegradados.Clear();
            coloresTriangulos.Clear();
        }

        private void trackVelocidad_Scroll(object sender, EventArgs e)
        {
            lblVelocidad.Text = "Velocidad: " + trackVelocidad.Value.ToString();
            // Definir el intervalo en el metodo para evitar cambios de velocidad durante el dibujo
            timer1.Interval = 101 - (int)Math.Pow((double)trackVelocidad.Value, 2);
        }
    }
}