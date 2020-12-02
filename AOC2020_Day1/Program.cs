using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text.RegularExpressions;

namespace AOC2020_Day1
{
	class Program
	{
		static void Main(string[] args)
		{
			var path = $"{Directory.GetParent(Environment.CurrentDirectory).Parent?.Parent?.FullName}/Inputs/Day1InputDataFile.txt";
			var expenses = new List<int>();
			var stopwatch = new Stopwatch();
			
			stopwatch.Start();
			if (File.Exists(path))
			{
				var text = File.ReadAllText(path);
				var result = Regex.Split(text, "\r\n|\n|\r");

				foreach (var entry in result)
				{
					var isParseable = int.TryParse(entry, out var number);

					if (isParseable)
					{
						expenses.Add(number);
					}
				}
			}
			stopwatch.Stop();

			Console.WriteLine("Startup time: " + stopwatch.ElapsedTicks + Environment.NewLine);

			stopwatch.Restart();
			var assignment1Solution = Assignment1(expenses);
			stopwatch.Stop();

			if (assignment1Solution != 0)
			{
				Console.WriteLine("The solution to assignment 1-1 is " + assignment1Solution + " | " + stopwatch.ElapsedTicks);
			}

			stopwatch.Restart();
			var assignment2Solution = Assignment2(expenses);
			stopwatch.Stop();

			if (assignment2Solution != 0)
			{
				Console.WriteLine("The solution to assignment 1-2 is " + assignment2Solution + " | " + stopwatch.ElapsedTicks);
			}

			Console.WriteLine("The End");
		}

		private static int Assignment1(IReadOnlyList<int> expenses)
		{
			var current = 0;
			var current2 = 1;
			for (; current2 < expenses.Count; current2++)
			{
				if (expenses[current] + expenses[current2] == 2020)
				{
					var solution = expenses[current] * expenses[current2];
					return solution;
				}

				if (current2 >= expenses.Count - 1)
				{
					current++;
					current2 = current + 1;
				}
			}

			return 0;
		}

		private static int Assignment2(IReadOnlyList<int> expenses)
		{
			var current = 0;
			var current2 = 1;
			var current3 = 2;
			for (; current3 < expenses.Count; current3++)
			{
				if (expenses[current] + expenses[current2] + expenses[current3] == 2020)
				{
					var solution = expenses[current] * expenses[current2] * expenses[current3];
					return solution;
				}

				if (current3 >= expenses.Count - 1)
				{
					current2++;
					current3 = 0;
				}

				if (current2 >= expenses.Count - 1)
				{
					current++;
					current2 = current + 1;
				}
			}

			return 0;
		}
	}
}
