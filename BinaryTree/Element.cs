using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryTree
{
    class Element
    {
        public int Data { get; set; }
        public Element pLeft { get; set; }
        public Element pRight { get; set; }
        public Element(int Data, Element pLeft = null, Element pRight = null)
        {
            this.Data = Data;
            this.pLeft = pLeft;
            this.pRight = pRight;
            Console.WriteLine($"EConstructor:{GetHashCode()}");
        }
        ~Element()
        {
            Console.WriteLine($"EDestructor:{GetHashCode()}");
        }
        public void Insert(int Data)
        {
            if (Data < this.Data)
            {
                if (pLeft == null) pLeft = new Element(Data);
                else pLeft.Insert(Data);
            }
            else
            {
                if (pRight == null) pRight = new Element(Data);
                else pRight.Insert(Data);
            }
        }
        public void Insert(Element elem)
        {
            if (elem.Data < this.Data)
            {
                if (pLeft == null) pLeft = elem;
                else pLeft.Insert(elem);
            }
            else
            {
                if (pRight == null) pRight = elem;
                else pRight.Insert(elem);
            }
        }
        public void UniqueInsert(int Data)
        {
            if (Data < this.Data)
            {
                if (pLeft == null) pLeft = new Element(Data);
                else pLeft.UniqueInsert(Data);
            }
            else if (Data > this.Data)
            {
                if (pRight == null) pRight = new Element(Data);
                else pRight.UniqueInsert(Data);
            }
        }
        public int MinValue()
        {
            return pLeft == null ? this.Data : pLeft.MinValue();
        }
        public int MaxValue()
        {
            return pRight == null ? this.Data : pRight.MaxValue();
        }
        public int Count()
        {
            return (pLeft != null ? pLeft.Count() : 0) + (pRight != null ? pRight.Count() : 0) + 1;
        }
        public int Sum()
        {
            return this.Data + (pLeft != null ? pLeft.Sum() : 0) + (pRight != null ? pRight.Sum() : 0);
        }
        public int Depth()
        {
            return 1 + Math.Max(pLeft != null ? pLeft.Depth() : 0, pRight != null ? pRight.Depth() : 0);
        }
        public void Erase(int Data)
        {
            if (Data < this.Data)
            {
                if (pLeft == null) throw new KeyNotFoundException("Error: Значение не найдено");
                else if (pLeft.Data != Data) pLeft.Erase(Data);
                else
                {
                    Element tmp = pLeft.pLeft;
                    pLeft = pLeft.pRight;
                    pLeft.Insert(tmp);
                }
            }
            else
            {
                if (pRight == null) throw new KeyNotFoundException("Error: Значение не найдено");
                else if (pRight.Data != Data) pRight.Erase(Data);
                else
                {
                    Element tmp = pRight.pRight;
                    pRight = pRight.pLeft;
                    pRight.Insert(tmp);
                }
            }
        }
        public void Print()
        {
            if (pLeft != null) pLeft.Print();
            Console.Write(this.Data + "\t");
            if (pRight != null) pRight.Print();
        }
    }
}
