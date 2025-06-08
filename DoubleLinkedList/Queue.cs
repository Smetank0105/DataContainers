using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoubleLinkedList
{
	class Queue
	{
		DoubleLinkedList List { get; set; }
		public Queue()
		{
			List = new DoubleLinkedList();
			Console.WriteLine($"QConsturctor:\t{GetHashCode()}");
		}
		~Queue()
		{
			Console.WriteLine($"QDesturctor:\t{GetHashCode()}");
		}
		public void Clear()
		{
			List.Clear();
		}
		public bool Contain(int Data)
		{
			for(int i=0; i < List.Lenght; i++)
			{
				if (Data == List[i].Data) return true;
			}
			return false;
		}
		public void Enqueue(int Data)
		{
			List.PushBack(Data);
		}
		public int Dequeue()
		{
			if (List.Lenght <= 0) throw new InvalidOperationException("Queue is empty");
			int result = List[0].Data;
			List.PopFront();
			return result; ;
		}
		public int Peek()
		{
			if (List.Lenght <= 0) throw new InvalidOperationException("Queue is empty");
			return List[0].Data;
		}
		public void Print()
		{
			List.Print();
		}
	}
}
