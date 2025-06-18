namespace jeje
{
    public class Circle : Shape
    {
        private double _radius;

        public Circle(string color, double radius)
            : base(color)
        {
            _radius = radius;
        }

        public override double GetArea()
        {
            return System.Math.PI * _radius * _radius;
        }
    }
}
