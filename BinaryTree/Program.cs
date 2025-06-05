//#define TREE_1
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryTree
{
	class Program
	{
		static void Main(string[] args)
		{
#if TREE_1
			Console.WriteLine("Введите размер дерева: ");
			int n = Convert.ToInt32(Console.ReadLine());
			Random rnd = new Random(0);
			Tree tree = new Tree();
			for (int i = 0; i < n; i++)
			{
				tree.Insert(rnd.Next(100), tree.Root);
			}
			//tree.Print(tree.Root);
			Console.WriteLine();
			//Console.WriteLine($"Min value in tree: {tree.MinValue()}");
			//Console.WriteLine($"Max value in tree: {tree.MaxValue()}");
			//Console.WriteLine($"Кол-во элементов дерева: {tree.Count()}");
			//Console.WriteLine($"Сумма элементов дерева: {tree.Sum()}");
			TreePerformance<int>.Measure($"Минимальное значение в дереве:", tree.MinValue);
			TreePerformance<int>.Measure($"Максимальное значение в дереве:", tree.MaxValue);
			TreePerformance<int>.Measure($"Кол-во элементов дерева:", tree.Count);
			TreePerformance<int>.Measure($"Сумма элементов дерева:", tree.Sum);
			TreePerformance<double>.Measure($"Среднее арифметическое элементов дерева:", tree.Avg);

			UniqueTree u_tree = new UniqueTree();
			for (int i = 0; i < n; i++)
			{
				u_tree.Insert(rnd.Next(100), u_tree.Root);
			}
			//tree.Print(u_tree.Root);
			Console.WriteLine();
			Console.WriteLine($"Min value in tree: {u_tree.MinValue()}");
			Console.WriteLine($"Max value in tree: {u_tree.MaxValue()}");
			Console.WriteLine($"Кол-во элементов дерева: {u_tree.Count()}");
			Console.WriteLine($"Сумма элементов дерева: {u_tree.Sum()}"); 
#endif
			//Tree tree = new Tree() { 50, 25, 75, 16, 32, 70, 80 };
			Tree tree = new Tree();
			tree.Insert(50);
			tree.Insert(25);
			tree.Insert(75);
			tree.Insert(16);
			tree.Insert(32);
			tree.Insert(70);
			tree.Insert(80);
			tree.Erase(50);
			tree.Print();
			Console.WriteLine("\n-----------------------------------------------\n");
			//tree.DepthPrint(0);
			tree.TreePrint();
			Console.WriteLine();
		}
	}
}
