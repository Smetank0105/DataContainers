using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForwardList
{
	class Stack
	{
		private ForwardList Head { get; set; }
		public Stack()
		{
			Head = new ForwardList();
			Console.WriteLine($"SConsturctor:\t{GetHashCode()}");
		}
		~Stack()
		{
			Console.WriteLine($"SDesturctor:\t{GetHashCode()}");
		}
		public void Clear()
		{
			Head.Clear();
		}
		public bool Contain(int Data)
		{
			for (int i = 0; i < Head.Lenght; i++)
			{
				if (Data == Head[i].Data) return true;
			}
			return false;
		}
		public void Push(int Data)
		{
			Head.PushFront(Data);
		}
		public int Pop()
		{
			if (Head.Lenght <= 0) throw new InvalidOperationException("Stack is empty");
			int result = Head[0].Data;
			Head.PopFront();
			return result;
		}
		public int Peek()
		{
			if (Head.Lenght <= 0) throw new InvalidOperationException("Stack is empty");
			return Head[0].Data;
		}
		public void Print()
		{
			Head.Print();
		}
	}
}
