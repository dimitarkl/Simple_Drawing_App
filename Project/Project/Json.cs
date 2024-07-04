using System.Text.Json;

namespace Project
{
    public class Json
    {
        public static string Saver(List<Shape> shapes)
        {
            var shapeData = new List<object>();

            foreach (var shape in shapes)
            {
                var shapeInfo = new
                {
                    Type = shape.GetType().Name,
                    Color = shape.Color.ToArgb(),
                    Position = new { X = shape.Position.X, Y = shape.Position.Y },
                    Size = shape.Size
                };
                shapeData.Add(shapeInfo);
            }
            return JsonSerializer.Serialize(shapeData);
        }
        public static List<Shape> Loader(string jsonData)
        {
            var shapeData = JsonSerializer.Deserialize<List<object>>(jsonData);
            var shapes = new List<Shape>();
            if (shapeData != null)
            {
                foreach (var data in shapeData)
                {
                    if (data is JsonElement element && element.TryGetProperty("Type", out var typeProperty))
                    {
                        var typeName = typeProperty.GetString();
                        var colorProperty = element.GetProperty("Color").GetInt32();
                        var sizeProperty = element.GetProperty("Size").GetInt32();
                        var positionProperty = element.GetProperty("Position");
                        var x = positionProperty.GetProperty("X").GetInt32();
                        var y = positionProperty.GetProperty("Y").GetInt32();
                        switch (typeName)
                        {
                            case "Square":
                                shapes.Add(new Square(new Point(x, y), sizeProperty, Color.FromArgb(colorProperty)));
                                break;
                            case "Triangle":
                                shapes.Add(new Triangle(new Point(x, y), sizeProperty, Color.FromArgb(colorProperty)));
                                break;
                            case "Hexagon":
                                shapes.Add(new Hexagon(new Point(x, y), sizeProperty, Color.FromArgb(colorProperty)));
                                break;
                            default:
                                throw new Exception("File is corrupted");
                        }
                    }
                }
            }
            return shapes;
        }
    }
}
