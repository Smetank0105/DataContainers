using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace DoubleLinkedList
{
	class DoubleLinkedListEnumerator : IEnumerator
	{
		DoubleLinkedList list;
		int position = -1;
		public DoubleLinkedListEnumerator(DoubleLinkedList list) => this.list = list;
		public object Current
		{
			get
			{
				if (position == -1 || position >= list.Lenght)
					throw new ArgumentException();
				return list[position].Data;
			}
		}

		public bool MoveNext()
		{
			if (position < list.Lenght - 1)
			{
				position++;
				return true;
			}
			else
				return false;
		}

		public void Reset() => position = -1;
	}
}
