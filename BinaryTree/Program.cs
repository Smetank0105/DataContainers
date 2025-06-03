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
			Console.WriteLine("Введите размер дерева: ");
			int n = Convert.ToInt32(Console.ReadLine());
			Random rnd = new Random(0);
			Tree tree = new Tree();
			for(int i = 0; i < n; i++)
			{
				tree.Insert(rnd.Next(100));
			}
			tree.Print();
			Console.WriteLine();
			Console.WriteLine($"Min value in tree: {tree.MinValue()}");
			Console.WriteLine($"Max value in tree: {tree.MaxValue()}");
			Console.WriteLine($"Кол-во элементов дерева: {tree.Count()}");
			Console.WriteLine($"Сумма элементов дерева: {tree.Sum()}");

			UniqueTree u_tree = new UniqueTree();
            for (int i = 0; i < n; i++)
            {
                u_tree.Insert(rnd.Next(100));
            }
            u_tree.Print();
			Console.WriteLine();
			Console.WriteLine($"Min value in tree: {u_tree.MinValue()}");
			Console.WriteLine($"Max value in tree: {u_tree.MaxValue()}");
			Console.WriteLine($"Кол-во элементов дерева: {u_tree.Count()}");
			Console.WriteLine($"Сумма элементов дерева: {u_tree.Sum()}");
		}
	}
}
