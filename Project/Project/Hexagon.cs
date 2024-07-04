namespace Project
{
    internal class Hexagon : Shape
    {
        private PointF[] pnt = new PointF[6];
        float y;
        SolidBrush? brush = null;
        public Hexagon(Point position, int n, Color color)
        {
            Position = position;
            Size = n;
            Color = color;
            y = (float)((Math.Sqrt(3) / 2) * Size);
        }
        public override void Draw(Graphics g)
        {
            y = (float)((Math.Sqrt(3) / 2) * Size);
            brush = new SolidBrush(Color);
            this.pnt[0] = new PointF(Position.X, Position.Y - y);//upper
            this.pnt[1] = new PointF(Position.X + y, Position.Y - y / 2);//upperright
            this.pnt[2] = new PointF(Position.X + y, Position.Y + y / 2);//lowerright
            this.pnt[3] = new PointF(Position.X, Position.Y + y);//lower
            this.pnt[4] = new PointF(Position.X - y, Position.Y + y / 2);//lowerleft
            this.pnt[5] = new PointF(Position.X - y, Position.Y - y / 2);//upperleft
            g.FillPolygon(brush, pnt);
        }
        public override bool IsPointInside(Point point)
        {
            int sidesClose = 0;
            foreach (PointF pnt in pnt)
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
            g.DrawLine(pen, pnt[1], pnt[2]);
            g.DrawLine(pen, pnt[2], pnt[3]);
            g.DrawLine(pen, pnt[3], pnt[4]);
            g.DrawLine(pen, pnt[4], pnt[5]);
            g.DrawLine(pen, pnt[5], pnt[0]);
        }
        public override float GetArea()
        {
            return ((3 * (float)Math.Sqrt(3) / 2) * Size * Size);
        }
        public override Shape Clone() => new Hexagon(this.Position, this.Size, this.Color);
    }
}
