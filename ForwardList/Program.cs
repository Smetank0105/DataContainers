//#define OLD_VERS
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForwardList
{
	class Program
	{
		static void Main(string[] args)
		{
#if OLD_VERS
			Console.Write("Введите размер списка: ");
			int n = Convert.ToInt32(Console.ReadLine());
			ForwardList list = new ForwardList();
			Random rnd = new Random(0);
			for (int i = 0; i < n; i++)
			{
				list.PushFront(rnd.Next(100));
			}
			list.PushBack(234);
			list.Print();
			list.PopFront();
			list.Print();
			list.PopBack();
			list.Print();
			Console.Write("Введите индекс: ");
			int index = Convert.ToInt32(Console.ReadLine());
			Console.Write("Введите значение: ");
			int value = Convert.ToInt32(Console.ReadLine());
			try
			{
				list.Insert(value, index);
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.Message);
			}
			list.Print();
#endif
			ForwardList list = new ForwardList() { 3, 5, 8, 13, 21 };
			foreach (int i in list)
			{
				Console.Write($"{i}\t");
			}
			Console.WriteLine();
			list.Print();
		}
	}
}
