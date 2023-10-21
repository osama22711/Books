// See https://aka.ms/new-console-template for more information


using DrawingApp.Renderers;
using DrawingApp.Shapes;

IRenderer rasterRenderer = new RasterRenderer();
IRenderer vectorRenderer = new VectorRenderer();

Shape circle = new Circle(5, rasterRenderer);
circle.Draw();

circle = new Circle(10, vectorRenderer);
circle.Draw();