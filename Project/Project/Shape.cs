namespace Project
{
    public abstract class Shape
    {
        public Point Position { get; set; }
        public Color Color { get; set; }
        public int Size { get; set; }
        public abstract void Draw(Graphics g);
        public abstract bool IsPointInside(Point point);
        public void Move(Point position) => Position = position;
        public abstract void Outline(Graphics g);
        public abstract float GetArea();
        public void Resize(int s) => Size = s;
        public int Side() => Size;
        public abstract Shape Clone();
        public void ChangeColor(Color color) => Color = color;

    }
}
