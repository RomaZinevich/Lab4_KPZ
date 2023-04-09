public abstract class Shape
{
    protected Renderer renderer;
    private int x;
    public int X
    {
        set { x = value; }
        get { return x; }
    }
    private int y;
    public int Y
    {
        set { y = value; }
        get { return y; }
    }

    public Shape(Renderer renderer, int x, int y)
    {
        this.renderer = renderer;
        this.x = x;
        this.y = y;
    }

    public abstract void Draw();
}

public class Circle : Shape
{
    private int radius;
    public int Radius
    {
        set { radius = value; }
        get { return radius; }
    }

    public Circle(Renderer renderer, int x, int y, int radius) : base(renderer, x, y)
    {
        this.radius = radius;
    }

    public override void Draw()
    {
        Console.Write("Drawing Circle");
        renderer.Render();
    }
}

public class Square : Shape
{
    private int side;
    public int Side
    {
        set { side = value; }
        get { return side; }
    }
    public Square(Renderer renderer, int x, int y, int side) : base(renderer, x, y)
    {
        this.side = side;
    }

    public override void Draw()
    {
        Console.Write("Drawing Square");
        renderer.Render();
    }
}

public class Triangle : Shape
{
    private int height;
    public int Height
    {
        set { height = value; }
        get { return height; }
    }
    public Triangle(Renderer renderer, int x, int y, int height) : base(renderer, x, y)
    {
        this.height = height;
    }

    public override void Draw()
    {
        Console.Write("Drawing Triangle");
        renderer.Render();
    }
}

public interface Renderer
{
    void Render();
}

public class VectorRenderer : Renderer
{
    public void Render()
    {
        Console.WriteLine(" as vectors.");
    }
}

public class RasterRenderer : Renderer
{
    public void Render()
    {
        Console.WriteLine(" as pixels.");
    }
}

class Program
{
    static void Main(string[] args)
    {
        Shape circleVector = new Circle(new VectorRenderer(), 10, 5, 6);
        Shape circleRaster = new Circle(new RasterRenderer(), 10, 5, 6);
        Shape squareVector = new Square(new VectorRenderer(), 10, 5, 19);
        Shape squareRaster = new Square(new RasterRenderer(), 10, 5, 19);
        Shape triangleVector = new Triangle(new VectorRenderer(), 10, 5, 8);
        Shape triangleRaster = new Triangle(new RasterRenderer(), 10, 5, 8);

        circleVector.Draw();    
        circleRaster.Draw();    
        squareVector.Draw();    
        squareRaster.Draw();    
        triangleVector.Draw();  
        triangleRaster.Draw();
    }
}