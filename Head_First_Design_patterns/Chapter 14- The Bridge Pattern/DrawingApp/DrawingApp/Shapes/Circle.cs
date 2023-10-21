using DrawingApp.Renderers;

namespace DrawingApp.Shapes
{
    public class Circle : Shape
    {
        private float radius;

        public Circle(float radius, IRenderer renderer) : base(renderer)
        {
            this.radius = radius;
        }

        public override void Draw()
        {
            Console.WriteLine("Drawing a circle...");
            renderer.RenderCircle(radius);
        }
    }
}
