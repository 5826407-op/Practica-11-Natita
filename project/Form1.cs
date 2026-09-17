using System.Diagnostics;

namespace DemolntroAsyncNatt
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        // Peligroso: async void debe ser evitado, EXCEPTO en eventos.
        private async void button1_Click(object sender, EventArgs e)
        {
            button1.Enabled = false;
            lblResultado.Text = "";
            pictureBox1.Visible = true;

            // ----- Secuencial -----
            var swSecuencial = new Stopwatch();
            swSecuencial.Start();

            await RealizarProcesamientoLargoA();
            await RealizarProcesamientoLargoB();
            await RealizarProcesamientoLargoC();

            swSecuencial.Stop();
            double segundosSecuencial = swSecuencial.ElapsedMilliseconds / 1000.0;

            // ----- Paralelo -----
            var swParalelo = new Stopwatch();
            swParalelo.Start();

            var tareas = new List<Task>()
            {
                RealizarProcesamientoLargoA(),
                RealizarProcesamientoLargoB(),
                RealizarProcesamientoLargoC()
            };

            await Task.WhenAll(tareas);

            swParalelo.Stop();
            double segundosParalelo = swParalelo.ElapsedMilliseconds / 1000.0;

            lblResultado.Text =
                $"Secuencial - duración en segundos: {segundosSecuencial}" + Environment.NewLine +
                $"Paralelo - duración en segundos: {segundosParalelo}";

            pictureBox1.Visible = false;
            button1.Enabled = true;
        }

        private async Task RealizarProcesamientoLargoA()
        {
            await Task.Delay(1000); // Asíncrona
        }

        private async Task RealizarProcesamientoLargoB()
        {
            await Task.Delay(1000); // Asíncrona
        }

        private async Task RealizarProcesamientoLargoC()
        {
            await Task.Delay(1000); // Asíncrona
        }

        private static List<imagen> ObtenerImagenes()
        {
            var imagenes = new List<imagen>();

            for (int i = 0; i < 7; i++)
            {
                imagenes.Add(new imagen()
                {
                    Nombre = $"Corazon sv {i}.jpg",
                    URL = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcTHzcY4i6Ckurt6WDxBNVKeAdRyI7IX4EYKRKDrscFhFlhtWSnQ9NM9Mw8E&s=10"
                });

                imagenes.Add(new imagen()
                {
                    Nombre = $"Bandera {i}.jpg",
                    URL = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcTFwglbQbw_zvXTiFuDT0bK9RWyd-MlWx6OOm3NB87CJ3w__n7FDtxazSA&s=10"
                });

                imagenes.Add(new imagen()
                {
                    Nombre = $"Binaes {i}.jpg",
                    URL = "https://asipi.org/elsalvador2025/wp-content/uploads/sites/34/2025/02/Centro-Historico-de-San-Salvador-Vista-Aerea-09.jpg"
                });
            }

            return imagenes;
        }
    }
}
