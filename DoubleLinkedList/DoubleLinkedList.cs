using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace DoubleLinkedList
{
	class DoubleLinkedList : IEnumerable
	{
		private Element Head { get; set; }
		private Element Tail { get; set; }
		public int Lenght { get; private set; }
		//Индексация
		public Element this[int Index]
		{
			get
			{
				if (Index >= Lenght || Index < 0) throw new IndexOutOfRangeException("Error: Выход за пределы списка");
				if (Index == 0) return this.Head.pNext;
				if (Index == Lenght - 1) return this.Tail.pPrev;
				if (Index < Lenght / 2)
				{
					Element Temp = Head.pNext;
					for (int i = 0; i < Index; i++)
					{
						if (Temp.pNext == null) break;
						Temp = Temp.pNext;
					}
					return Temp;
				}
				else
				{
					Element Temp = Tail.pPrev;
					for (int i = Lenght - 1; i > Index; i--)
					{
						if (Temp.pPrev == null) break;
						Temp = Temp.pPrev;
					}
					return Temp;
				}
			}
			set
			{
				if (Index > Lenght || Index < 0) throw new IndexOutOfRangeException("Error: Выход за пределы списка");
				else if (Index == 0) this.Head.pNext = value;
				else if (Index == Lenght) this.Tail.pPrev = value;
				else
				{
					if (Index < Lenght / 2)
					{
						Element Temp = Head.pNext;
						for (int i = 0; i < Index - 1; i++)
						{
							if (Temp.pNext == null) break;
							Temp = Temp.pNext;
						}
						Temp = value;
					}
					else
					{
						Element Temp = Tail.pPrev;
						for(int i = Lenght; i > Index; i--)
						{
							if (Temp.pPrev == null) break;
							Temp = Temp.pPrev;
						}
						Temp = value;
					}
				}
			}
		}
		//Конструктор/Деструктор
		public DoubleLinkedList()
		{
			Head = new Element(0);
			Tail = new Element(0, null, Head);
			Head.pNext = Tail;
			Console.WriteLine($"DLConsturctor:\t{GetHashCode()}");
		}
		~DoubleLinkedList()
		{
			Console.WriteLine($"DLDesturctor:\t{GetHashCode()}");
		}
		//Очищение списка
		public void Clear()
		{
			Head.pNext = Tail;
			Tail.pPrev = Head;
			Lenght = 0;
		}
		//Добавление элементов
		public void PushFront(int Data)
		{
			if (Head.pNext == Tail)
			{
				Element New = new Element(Data);
				Head.pNext = New;
				Tail.pPrev = New;
			}
			else
			{
				Element New = new Element(Data, Head.pNext, null);
				Head.pNext.pPrev = New;
				Head.pNext = New;
			}
			Lenght++;
		}
		public void Add(int Data)
		{
			PushBack(Data);
		}
		public void PushBack(int Data)
		{
			if (Tail.pPrev == Head)
			{
				Element New = new Element(Data);
				Head.pNext = New;
				Tail.pPrev = New;
			}
			else
			{
				Element New = new Element(Data, null, Tail.pPrev);
				Tail.pPrev.pNext = New;
				Tail.pPrev = New;
			}
			Lenght++;
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
			if (Index == Lenght)
			{
				PushBack(Data);
				return;
			}
			if (Index < Lenght / 2)
			{
				Element Temp = Head.pNext;
				for (int i = 0; i < Index - 1; i++)
				{
					if (Temp.pNext == null) break;
					Temp = Temp.pNext;
				}
				Temp.pNext = new Element(Data, Temp.pNext, Temp);
				Temp.pNext.pNext.pPrev = Temp.pNext;
			}
			else
			{
				Element Temp = Tail.pPrev;
				for (int i = Lenght; i > Index + 1; i--)
				{
					if (Temp.pPrev == null) break;
					Temp = Temp.pPrev;
				}
				Temp.pPrev = new Element(Data, Temp, Temp.pPrev);
				Temp.pPrev.pPrev.pNext = Temp.pPrev;
			}
			Lenght++;
		}
		//Удаление элементов
		public void PopFront()
		{
			if (Head.pNext != Tail)
			{
				Lenght--;
				if (Lenght != 0)
				{
					Head.pNext = Head.pNext.pNext;
					Head.pNext.pPrev = null;
				}
				else Clear();
			}
		}
		public void PopBack()
		{
			if (Tail.pPrev != Head)
			{
				Lenght--;
				if (Lenght != 0)
				{
					Tail.pPrev = Tail.pPrev.pPrev;
					Tail.pPrev.pNext = null;
				}
				else Clear();
			}
		}
		//Вывод на экран
		public void Print()
		{
			for (Element Temp = Head.pNext; (Temp != null && Temp != Tail); Temp = Temp.pNext)
			{
				Console.Write($"{Temp.Data}\t");
			}
			Console.WriteLine();
			Console.WriteLine($"Кол-во элементов списка: {Lenght}");
		}

		public IEnumerator GetEnumerator() => new DoubleLinkedListEnumerator(this);
	}
}
