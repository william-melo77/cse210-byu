using System;
using System.Collections.Generic;

namespace jeje
{
    class Program
    {
        static void Main(string[] args)
        {
            // Creamos una lista heterogénea de Shape
            List<Shape> shapes = new List<Shape>
            {
                new Square("Rojo", 5),
                new Rectangle("Azul", 4, 6),
                new Circle("Verde", 3)
            };

            // Polimorfismo en acción: la misma llamada GetArea() varía según el tipo
            foreach (var shape in shapes)
            {
                Console.WriteLine(
                    $"Color: {shape.GetColor()}, Área: {shape.GetArea():F2}"
                );
            }
        }
    }
}
