namespace Project
{
    internal class Triangle : Shape
    {
        private int sides = 3;
        private float height;
        private float distance;
        SolidBrush? brush = null;
        PointF[] pnt = new PointF[3];
        public Triangle(Point position, int n, Color color)
        {
            Position = position;
            Size = n;
            Color = color;
        }
        public override void Draw(Graphics g)
        {
            height = (float)Math.Sqrt(Size * Size - (Size / 2) * (Size / 2)) * -1;
            brush = new SolidBrush(Color);
            pnt[0] = new PointF(Position.X, Position.Y + height / 2);
            pnt[1] = new PointF(Position.X + Size / 2, Position.Y - height / 2);
            pnt[2] = new PointF(Position.X - Size / 2, Position.Y - height / 2);
            g.FillPolygon(brush, pnt);
        }
        public override bool IsPointInside(Point point)
        {
            int sidesClose = 0;
            foreach (PointF pnt in pnt)
            {
                distance = (float)(Math.Sqrt(Math.Pow(pnt.X - point.X, 2) + Math.Pow(pnt.Y - point.Y, 2)));
                if (distance < (float)Size)
                    sidesClose++;
            }
            if (sidesClose > Math.Ceiling((decimal)sides / 2))
                return true;
            return false;
        }
        public override void Outline(Graphics g)
        {
            Pen pen;
            if (brush != null && brush.Color == Color.Red) pen = new Pen(Color.Black, 2);
            else pen = new Pen(Color.Red, 2);
            g.DrawLine(pen, pnt[0], pnt[1]);
            g.DrawLine(pen, pnt[0], pnt[2]);
            g.DrawLine(pen, pnt[1], pnt[2]);
        }
        public override float GetArea()
        {
            height = (float)Math.Sqrt(Size * Size - (Size / 2) * (Size / 2));
            return (float)((Size * height) / 2);
        }
        public override Shape Clone() => new Triangle(this.Position, this.Size, this.Color);
    }
}
