namespace _02.Graphic_Editor
{
    public class Program
    {
        public static void Main()
        {
            IShape rectangle = new Rectangle();

            GraphicEditor gE = new GraphicEditor();

            gE.DrawShape(rectangle);
        }
    }
}
