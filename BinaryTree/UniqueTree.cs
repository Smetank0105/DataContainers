using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryTree
{
	class UniqueTree : Tree
	{
		public new void Insert(int Data)
		{
			if (this.Root == null) this.Root = new Element(Data);
			else this.Root.UniqueInsert(Data);
		}
	}
}
