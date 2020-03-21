namespace ProjectIris.Utils
{
    using Microsoft.Xna.Framework;

    public class RectangleD
    {
        public double X { get; set; }
        public double Y { get; set; }
        public double Width { get; set; }
        public double Height { get; set; }

        public Rectangle Rectangle { get => new Rectangle((int)X, (int)Y, (int)Width, (int)Height); }

        public RectangleD(double x, double y, double width, double height)
        {
            this.X = x;
            this.Y = y;
            this.Width = width;
            this.Height = height;
        }
    }
}
