using SFML.Graphics;
using SFML.Window;
using System;

namespace KolejarzCs
{
    class Program
    {
        static void Main(string[] args)
        {
            RenderWindow window = new RenderWindow(new VideoMode(200, 200), "SFML works!");
            CircleShape shape = new CircleShape(100);
            shape.FillColor = Color.Green;

            window.Closed += Window_Closed;

            while (window.IsOpen)
            {
                window.Clear();
                window.Draw(shape);
                window.Display();
            }
        }

        private static void Window_Closed(object sender, EventArgs e)
        {
            (sender as Window).Close();
        }
    }
}
