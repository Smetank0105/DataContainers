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
            Console.WriteLine("--------------------Tree--------------------");
			Tree tree = new Tree();
			for(int i = 0; i < n; i++)
			{
				tree.Insert(rnd.Next(100));
			}
            Test(tree);

            Console.Write("Введите значение, которое нужно удалить:\t");
			int m = Convert.ToInt32(Console.ReadLine());
            try { tree.Erase(m); }
            catch (Exception ex) { Console.WriteLine($"Error: {ex.Message}"); }
			Test(tree);

			tree.Clear();
            Console.WriteLine("Дерево очищено");
			Test(tree);

            Console.WriteLine("----------------Unique Tree----------------");
            UniqueTree u_tree = new UniqueTree();
            for (int i = 0; i < n; i++)
            {
                u_tree.Insert(rnd.Next(100));
            }
			Test(u_tree);
			Console.Write("Введите значение, которое нужно удалить:\t");
			m = Convert.ToInt32(Console.ReadLine());
			try { u_tree.Erase(m); }
			catch (Exception ex) { Console.WriteLine($"Error: {ex.Message}"); }
			Test(u_tree);

			u_tree.Clear();
			Console.WriteLine("Дерево очищено");
			Test(u_tree);
		}
		public static void Test(Tree tree)
        {
			tree.Print();
			Console.WriteLine();
			Console.WriteLine($"Min value in tree: {tree.MinValue()}");
			Console.WriteLine($"Max value in tree: {tree.MaxValue()}");
			Console.WriteLine($"Кол-во элементов дерева: {tree.Count()}");
			Console.WriteLine($"Сумма элементов дерева: {tree.Sum()}");
			Console.WriteLine($"Глубина дерева: {tree.Depth()}");
		}
	}
}
