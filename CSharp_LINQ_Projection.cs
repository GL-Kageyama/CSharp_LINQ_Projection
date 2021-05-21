using System;
using System.Linq;
using System.Collections.Generic;

namespace Projection
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            var projectionClass = new ProjectionClass();

            projectionClass.GetProje();

        }
    }

    class ProjectionClass
    {
        public void GetProje()
        {
            var source = new[] {
                new { Name = "Evans", Age = 38 },
                new { Name = "Smith", Age = 22 },
                new { Name = "Jones", Age = 62 },
                new { Name = "Wilson", Age = 22 },
            };

            // Select()
            // Projection of one element to a single element
            var name = source.Select(e => e.Name);
            foreach (var n in name)
                Console.WriteLine(n);
            Console.WriteLine();

            // Select()
            // Calculate the area of a square using Select()
            IEnumerable<int> squares = Enumerable.Range(1, 10).Select(x => x * x);
            foreach (int num in squares)
                Console.WriteLine(num);
            Console.WriteLine();

            // SelectMany()
            // Projection from one element to multiple elements
            var nameM = source.SelectMany(e => e.Name);
            foreach (var n in nameM)
                Console.Write("{0} ", n);
            Console.WriteLine();
            Console.WriteLine();

            // GroupBy()
            // Group elements by a specified key
            IEnumerable<IGrouping<int, string>> query = source.GroupBy(e => e.Age, n => n.Name);
            foreach (IGrouping<int, string> friGroup in query)
            {
                Console.WriteLine(friGroup.Key);
                foreach (string nameF in friGroup)
                    Console.WriteLine(" -> {0}", nameF);
            }
        }
    }
}