//#define OLD_VERS
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoubleLinkedList
{
	class Program
	{
		static void Main(string[] args)
		{
#if OLD_VERS
			DoubleLinkedList list = new DoubleLinkedList();
			list.Print();
			list.PushFront(2);
			list.PushBack(3);
			list.PushFront(1);
			list.PushBack(4);
			list.PushBack(5);
			list.PushBack(6);
			list.Print();
			list.PopFront();
			list.PopBack();
			list.Print();
			list.Insert(0, 3);
			list.Print();
			Console.WriteLine($"TEST: {list[3]}"); 
#endif
			DoubleLinkedList list = new DoubleLinkedList() { 3, 5, 8, 13, 21 };
			foreach (int i in list)
			{
				Console.Write($"{i}\t");
			}
			Console.WriteLine();
			list.Print();
		}
	}
}
