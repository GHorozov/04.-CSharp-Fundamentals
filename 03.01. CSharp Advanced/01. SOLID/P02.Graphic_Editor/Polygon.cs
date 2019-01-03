namespace P02.Graphic_Editor
{
    public class Polygon : IShape
    {
        public string Type => this.GetType().Name;
    }
}