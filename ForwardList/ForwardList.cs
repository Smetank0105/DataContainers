using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace ForwardList
{
	class ForwardList : IEnumerable
	{
		private Element Head { get; set; }
		public int Lenght { get; private set; }
		public Element this[int Index]
		{
			get
			{
				if (Index >= Lenght || Index < 0)
				{
					throw new IndexOutOfRangeException("Error: Выход за пределы списка");
				}
				if (Index == 0)
				{
					return this.Head;
				}
				Element Temp = Head;
				for (int i = 0; i < Index - 1; i++)
				{
					if (Temp.pNext == null) break;
					Temp = Temp.pNext;
				}
				return Temp.pNext;
			}
			set
			{
				if (Index >= Lenght)
				{
					throw new IndexOutOfRangeException("Error: Выход за пределы списка");
				}
				else if (Index == 0)
				{
					this.Head = value;
				}
				else
				{
					Element Temp = Head;
					for (int i = 0; i < Index - 1; i++)
					{
						if (Temp.pNext == null) break;
						Temp = Temp.pNext;
					}
					Temp.pNext = value;
				}
			}
		}
		public ForwardList()
		{
			Head = null;
			Console.WriteLine($"LConsturctor:\t{GetHashCode()}");
		}
		~ForwardList()
		{
			Head = null;
			Console.WriteLine($"LDesturctor:\t{GetHashCode()}");
		}
		public void Clear()
		{
			Head = null;
			Lenght = 0;
		}
		//Добавление элементов
		public void PushFront(int Data)
		{
			//Element New = new Element(Data);
			//New.pNext = Head;
			//Head = New;
			Head = new Element(Data, Head);
			Lenght++;
		}
		public void PushBack(int Data)
		{
			if (Head == null)
			{
				PushFront(Data);
				return;
			}
			Element Temp = Head;
			while (Temp.pNext != null)
			{
				Temp = Temp.pNext;
			}
			Temp.pNext = new Element(Data);
			Lenght++;
		}
		public void Add(int Data)
		{
			PushBack(Data);
		}
		public void Insert(int Data, int Index)
		{
			if (Index > Lenght || Index < 0)
			{
				throw new IndexOutOfRangeException("Error: Выход за пределы списка");
			}
			if (Index == 0)
			{
				PushFront(Data);
				return;
			}
			Element Temp = Head;
			for(int i = 0; i < Index - 1; i++)
			{
				if (Temp.pNext == null) break;
				Temp = Temp.pNext;
			}
			Temp.pNext = new Element(Data, Temp.pNext);
			Lenght++;
		}
		//Удаление элементов
		public void PopFront()
		{
			if (Head != null)
			{
				Head = Head.pNext;
				Lenght--;
			}
		}
		public void PopBack()
		{
			if (Head != null || Head.pNext != null)
			{
				Element Temp = Head;
				while (Temp.pNext.pNext != null)
				{
					Temp = Temp.pNext;
				}
				Temp.pNext = null;
				Lenght--;
			}
		}
		public void Print()
		{
			for (Element Temp = Head; Temp != null; Temp = Temp.pNext)
			{
				Console.Write($"{Temp.Data}\t");
			}
			Console.WriteLine();
			Console.WriteLine($"Кол-во элементов списка: {Lenght}");
		}
		public override string ToString()
		{
			return $"{Head}";
		}
		IEnumerator IEnumerable.GetEnumerator() => new ForwardListEnumerator(this);
	}
}
