namespace Project
{
    public partial class Form1 : Form
    {
        private Color selectedColor = Color.Black;
        private Shape? selectedShape = null;
        private List<Shape> shapes = new List<Shape>();
        private Stack<List<Shape>> undoStack = new Stack<List<Shape>>();
        private Stack<List<Shape>> redoStack = new Stack<List<Shape>>();
        private Figure selectedFigure = Figure.Square;
        bool move = false;
        string? userInput = null;
        int ins = 0;
        public Form1() => InitializeComponent();
        private void Painter(object sender, PaintEventArgs e)
        {
            Area.Text = $"Select a shape to see its area";
            SideText.Text = $"Select a shape to see its side";
            var shape = shapes.FirstOrDefault(i => i == selectedShape);
            foreach (Shape sh in shapes) sh.Draw(e.Graphics);
            if (shape != null && selectedShape != null)
            {
                shape.Outline(e.Graphics);
                Area.Text = $"Area: {selectedShape.GetArea()}px.";
                SideText.Text = $"Side:{selectedShape.Side()}px.";
            }
            if (shapes.Count > 0)
            {
                usedShape.Text = $"Shape[{shapes
            .GroupBy(s => s.GetType().Name)
            .OrderByDescending(g => g.Count())
            .First()
            .Key}]";
                usedCol.Text = $"{shapes
            .GroupBy(s => s.Color)
            .OrderByDescending(g => g.Count())
            .First()
            .Key}";
            }
            else
            {
                usedShape.Text = "none";
                usedCol.Text = "none";
            }
        }
        private void Mouse_Down(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                AddtoUndoStack();
                redoStack.Clear();
                switch (selectedFigure)
                {
                    case Figure.Square:
                        shapes.Add(new Square(e.Location, 150, selectedColor));
                        break;
                    case Figure.Triangle:
                        shapes.Add(new Triangle(e.Location, 150, selectedColor));
                        break;
                    case Figure.Hexagon:
                        shapes.Add(new Hexagon(e.Location, 90, selectedColor));
                        break;
                }
                Refresh();
            }
            else if (e.Button == MouseButtons.Left)
            {
                selectedShape = null;
                var shape = shapes.FirstOrDefault(i => i.IsPointInside(e.Location));
                selectedShape = shape;
                if (e.Button == MouseButtons.Left && selectedShape != null && selectedShape.IsPointInside(e.Location))
                {

                    move = true;
                    if (move && ins == 0)
                    {
                        ins = 1;
                        AddtoUndoStack();
                    }
                    Invalidate();
                }
            }
        }
        private void Mouse_Up(object sender, MouseEventArgs e)
        {
            move = false;
            ins = 0;

        }
        private void Mouse_Move(object sender, MouseEventArgs e)
        {
            if (move == true && selectedShape != null) selectedShape.Move(e.Location);
            Refresh();
        }
        private void ColorButton_Click(object sender, EventArgs e)
        {
            var colorDialog = new ColorDialog
            {
                AllowFullOpen = true,
                FullOpen = true,
                AnyColor = true,
                Color = selectedColor,
            };
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                selectedColor = colorDialog.Color;
                AddtoUndoStack();
                selectedShape?.ChangeColor(selectedColor);
            }
        }
        private void Delete(object sender, EventArgs e)
        {
            if (selectedShape != null) shapes?.Remove(selectedShape);
            else shapes.Clear();
            selectedShape = null;
            Refresh();
        }
        private void AddtoUndoStack()
        {
            List<Shape> state = new List<Shape>();
            state.AddRange(shapes.Select(shape => shape.Clone()));
            undoStack.Push(state);
        }
        private void undo_Click(object sender, EventArgs e)
        {
            if (undoStack.Count > 0)
            {
                redoStack.Push(new List<Shape>(shapes));
                shapes = undoStack.Pop();
                Refresh();
            }
        }
        private void RedoButton_Click(object sender, EventArgs e)
        {
            if (redoStack.Count > 0)
            {
                AddtoUndoStack();
                shapes = redoStack.Pop();
                selectedShape = null;
            }
            Refresh();
        }
        private void Shapes_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (Shapes.GetItemText(Shapes.SelectedItem))
            {
                case "Square":
                    selectedFigure = Figure.Square;
                    break;
                case "Triangle":
                    selectedFigure = Figure.Triangle;
                    break;
                case "Hexagon":
                    selectedFigure = Figure.Hexagon;
                    break;
            }
        }
        private void ConfirmInput_Click(object sender, EventArgs e)
        {
            userInput = sizeChanger.Text;
            AddtoUndoStack();
            if (int.TryParse(userInput, out _) && int.Parse(userInput) < 0) MessageBox.Show("Invalid Input");
            else if (int.TryParse(userInput, out _) && shapes != null && selectedShape != null)
                shapes.FirstOrDefault(i => i == selectedShape).Resize(int.Parse(userInput));
            else MessageBox.Show("Invalid Input");
            Refresh();
        }
        private void Save_Click(object sender, EventArgs e)
        {
            var saveFileDialog = new SaveFileDialog
            {
                Filter = "JSON files (*.json)|*.json|All files (*.*)|*.*",
                Title = "Save shapes data to JSON"
            };

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = saveFileDialog.FileName;
                try
                {
                    string jsonData = Json.Saver(shapes);
                    File.WriteAllText(filePath, jsonData);
                    MessageBox.Show("Saved successfully.", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error " + ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void Load_Click(object sender, EventArgs e)
        {
            var openFileDialog = new OpenFileDialog
            {
                Filter = "JSON files (*.json)|*.json|All files (*.*)|*.*",
                Title = "Open shapes data from text file"
            };

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = openFileDialog.FileName;
                shapes.Clear();
                try
                {
                    string jsonData = File.ReadAllText(filePath);
                    List<Shape> loadedShapes = Json.Loader(jsonData);
                    if (loadedShapes != null)
                    {
                        shapes.AddRange(loadedShapes);
                        MessageBox.Show("Loaded successfully.", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                        MessageBox.Show("Error", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error loading data: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                Refresh();
            }
        }
        public enum Figure
        {
            Triangle,
            Square,
            Hexagon
        }
    }
}