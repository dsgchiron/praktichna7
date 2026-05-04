using System;

namespace PracticWork7_Var4
{
    // Абстрактний клас Фігура на площині
    abstract class Figure
    {
        // Масив для зберігання довжин сторін фігури або радіуса (для круга)
        public double[] Dimensions { get; set; }

        // Абстрактні (віртуальні) методи обчислення площі та периметра
        public abstract double GetArea();
        public abstract double GetPerimeter();

        // Метод виведення даних на екран реалізовано ТІЛЬКИ в базовому класі
        public void PrintInfo()
        {
            Console.WriteLine($"--- Фігура: {this.GetType().Name} ---");
            Console.Write("Параметри (довжини сторін / радіус): ");
            foreach (var dim in Dimensions)
            {
                Console.Write(dim + " ");
            }
            Console.WriteLine();
            Console.WriteLine($"Периметр: {Math.Round(GetPerimeter(), 2)}");
            Console.WriteLine($"Площа: {Math.Round(GetArea(), 2)}\n");
        }
    }

    // Похідний клас: Круг
    class Circle : Figure
    {
        // Dimensions[0] виступає в ролі радіуса
        public override double GetArea()
        {
            return Math.PI * Math.Pow(Dimensions[0], 2);
        }

        public override double GetPerimeter()
        {
            return 2 * Math.PI * Dimensions[0];
        }
    }

    // Похідний клас: Прямокутник
    class Rectangle : Figure
    {
        // Dimensions[0] - ширина, Dimensions[1] - довжина
        public override double GetArea()
        {
            return Dimensions[0] * Dimensions[1];
        }

        public override double GetPerimeter()
        {
            return 2 * (Dimensions[0] + Dimensions[1]);
        }
    }

    // Похідний клас: Трикутник
    class Triangle : Figure
    {
        // Dimensions[0], Dimensions[1], Dimensions[2] - сторони трикутника
        public override double GetArea()
        {
            // Використовуємо формулу Герона
            double p = GetPerimeter() / 2;
            return Math.Sqrt(p * (p - Dimensions[0]) * (p - Dimensions[1]) * (p - Dimensions[2]));
        }

        public override double GetPerimeter()
        {
            return Dimensions[0] + Dimensions[1] + Dimensions[2];
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // Створюємо об'єкти за допомогою ініціалізаторів (без виклику спеціальних конструкторів)
            Circle myCircle = new Circle { Dimensions = new double[] { 5.0 } };
            Rectangle myRectangle = new Rectangle { Dimensions = new double[] { 4.0, 6.0 } };
            Triangle myTriangle = new Triangle { Dimensions = new double[] { 3.0, 4.0, 5.0 } };

            // Демонструємо роботу методів
            myCircle.PrintInfo();
            myRectangle.PrintInfo();
            myTriangle.PrintInfo();

            Console.ReadLine();
        }
    }
}