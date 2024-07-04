namespace Project
{
    internal class Square : Shape
    {
        SolidBrush? brush = null;
        private Point[] pnt = new Point[4];
        public Square(Point position, int n, Color color)
        {
            Position = position;
            Size = n;
            Color = color;
        }
        public override void Draw(Graphics g)
        {
            brush = new SolidBrush(Color);
            this.pnt[0] = new Point(Position.X - Size / 2, Position.Y - Size / 2);
            this.pnt[1] = new Point(Position.X + Size / 2, Position.Y - Size / 2);
            this.pnt[2] = new Point(Position.X + Size / 2, Position.Y + Size / 2);
            this.pnt[3] = new Point(Position.X - Size / 2, Position.Y + Size / 2);
            g.FillPolygon(brush, pnt);
        }
        public override bool IsPointInside(Point point)
        {
            int sidesClose = 0;
            foreach (Point pnt in pnt)
            {
                float distance = (float)(Math.Sqrt(Math.Pow(pnt.X - point.X, 2) + Math.Pow(pnt.Y - point.Y, 2)));
                if (distance < Size)
                    sidesClose++;
            }
            if (sidesClose > 2)
                return true;
            return false;
        }
        public override void Outline(Graphics g)
        {
            Pen pen;
            if (brush != null && brush.Color == Color.Red) pen = new Pen(Color.Black, 2);
            else pen = new Pen(Color.Red, 2);
            g.DrawLine(pen, pnt[0], pnt[1]);
            g.DrawLine(pen, pnt[0], pnt[3]);
            g.DrawLine(pen, pnt[2], pnt[3]);
            g.DrawLine(pen, pnt[1], pnt[2]);
        }
        public override float GetArea()
        {
            return Size * Size;
        }
        public override Shape Clone() => new Square(this.Position, this.Size, this.Color);
    }

}

