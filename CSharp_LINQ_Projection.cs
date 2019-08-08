using System;
using System.Linq;
using System.Collections.Generic;

namespace Projection
{
	class MainClass
	{
		public static void Main(string[] args)
		{
			var proj = new ProjectionClass();

			proj.GetProje();

		}
	}

	class ProjectionClass
	{
		public void GetProje()
		{
			var source = new[] {
				new {Name = "Kenji", Age = 38}, 
				new {Name = "Mayuko", Age = 22}, 
				new {Name = "Kenichirou", Age = 62}, 
				new {Name = "Yukio", Age = 22},  
			};

			// Select()
			// 1つの要素を単一の要素に射影
			var name = source.Select(e => e.Name);
			foreach (var n in name)
				Console.WriteLine(n);
			Console.WriteLine();

			// Select()
			// Select()を使って正方形の面積を算出
			IEnumerable<int> squares = Enumerable.Range(1, 10).Select(x => x * x);
			foreach (int num in squares)
				Console.WriteLine(num);
			Console.WriteLine();

			// SelectMany()
			// 1つの要素から複数の要素に射影
			var nameM = source.SelectMany(e => e.Name);
			foreach (var n in nameM)
				Console.Write("{0} ", n);
			Console.WriteLine();
			Console.WriteLine();

			// GroupBy()
			// 指定のキーて要素をグループ化
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
