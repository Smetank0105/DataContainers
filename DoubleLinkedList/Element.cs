using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoubleLinkedList
{
	class Element
	{
		public int Data { get; set; }
		internal Element pNext { get; set; }
		internal Element pPrev { get; set; }
		public Element(int Data, Element pNext = null, Element pPrev = null)
		{
			this.Data = Data;
			this.pNext = pNext;
			this.pPrev = pPrev;
			Console.WriteLine($"EConsturctor:\t{GetHashCode()}");
		}
		~Element()
		{
			Console.WriteLine($"LDesturctor:\t{GetHashCode()}");
		}
		public override string ToString()
		{
			return $"{Data}";
		}
	}
}
