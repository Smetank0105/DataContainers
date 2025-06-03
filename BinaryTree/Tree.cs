using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryTree
{
	class Tree
	{
		public Element Root { get; protected set; }
		public Tree()
		{
			Root = null;
			Console.WriteLine($"TConstructor:{GetHashCode()}");
		}
		~Tree()
		{
			Console.WriteLine($"TDestructor:{GetHashCode()}");
		}
		public void Insert(int Data)
        {
			if (this.Root == null) this.Root = new Element(Data);
			else this.Root.Insert(Data);
        }
		public int MinValue()
		{
			if (this.Root == null) return 0;
			else return Root.MinValue();
		}
		public int MaxValue()
		{
			if (this.Root == null) return 0;
			else return Root.MaxValue();
		}
		public int Count()
		{
			return this.Root == null ? 0 : this.Root.Count();
		}
		public int Sum()
		{
			return this.Root == null ? 0 : this.Root.Sum();
		}
		public void Clear()
		{
			this.Root = null;
		}
		public int Depth()
        {
			if (this.Root == null) return 0;
			return this.Root.Depth();
        }
		public void Erase(int Data)
        {
			if (this.Root == null) throw new NullReferenceException("Error: Дерево не содержит элементов");
			else if (this.Root.Data != Data) this.Root.Erase(Data);
			else
			{
				Element tmp = this.Root.pLeft;
				this.Root = this.Root.pRight;
				this.Root.Insert(tmp);
			}
        }
		public void Print()
		{
			if (this.Root == null) return;
			this.Root.Print();
		}
	}
}
