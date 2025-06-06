using System;
using System.Collections;
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
            //Console.WriteLine($"TConstructor:{GetHashCode()}");
        }
        ~Tree()
        {
            //Console.WriteLine($"TDestructor:{GetHashCode()}");
        }
        public void Insert(int Data) { Insert(Data, Root); }
        public void Insert(Element NewRoot) { Insert(NewRoot, Root); }
        void Insert(Element NewRoot, Element Root)
        {
            if (NewRoot == null) return;
            if (this.Root == null) this.Root = NewRoot;
            if (Root == null) return;
            if (NewRoot.Data < Root.Data)
            {
                if (Root.pLeft == null) Root.pLeft = NewRoot;
                else Insert(NewRoot, Root.pLeft);
            }
            else
            {
                if (Root.pRight == null) Root.pRight = NewRoot;
                else Insert(NewRoot, Root.pRight);
            }
        }
        void Insert(int Data, Element Root)
        {
            if (this.Root == null) this.Root = new Element(Data);
            if (Root == null) return;
            if (Data < Root.Data)
            {
                if (Root.pLeft == null) Root.pLeft = new Element(Data);
                else Insert(Data, Root.pLeft);
            }
            else
            {
                if (Root.pRight == null) Root.pRight = new Element(Data);
                else Insert(Data, Root.pRight);
            }
        }
        public int MinValue() { return MinValue(Root); }
        int MinValue(Element Root)
        {
            if (Root == null) return 0;
            else return Root.pLeft == null ? Root.Data : MinValue(Root.pLeft);
        }
        public int MaxValue() { return MaxValue(Root); }
        int MaxValue(Element Root)
        {
            if (Root == null) return 0;
            else return Root.pRight == null ? Root.Data : MaxValue(Root.pRight);
        }
        public int Count() { return Count(Root); }
        int Count(Element Root)
        {
            return Root == null ? 0 : Count(Root.pLeft) + Count(Root.pRight) + 1;
        }
        public int Sum() { return Sum(Root); }
        int Sum(Element Root)
        {
            return Root == null ? 0 : Sum(Root.pLeft) + Sum(Root.pRight) + Root.Data;
        }
        public void Erase(int Data) { Erase(Data, Root); }
        void Erase(int Data, Element Root)
        {
            if (this.Root == null) return;
            else if (Root == null) return;
            else if (this.Root.Data == Data)
            {
                Element tmp = this.Root.pLeft;
                if (this.Root.pRight != null)
                {
                    this.Root = this.Root.pRight;
                    Insert(tmp, this.Root);
                }
                else this.Root = this.Root.pLeft;
            }
            else if (Data < Root.Data)
            {
                if (Root.pLeft == null) throw new KeyNotFoundException("Error: Значение не найдено");
                else if (Root.pLeft.Data != Data) Erase(Data, Root.pLeft);
                else
                {
                    Element tmp = Root.pLeft;
                    if (Root.pLeft.pRight != null)
                    {
                        Root.pLeft = Root.pLeft.pRight;
                        Insert(tmp.pLeft, Root.pLeft);
                    }
                    else Root.pLeft = Root.pLeft.pLeft;
                }
            }
            else
            {
                if (Root.pRight == null) throw new KeyNotFoundException("Error: Значение не найдено");
                else if (Root.pRight.Data != Data) Erase(Data, Root.pRight);
                else
                {
                    Element tmp = Root.pRight;
                    if (Root.pRight.pLeft != null)
                    {
                        Root.pRight = Root.pRight.pLeft;
                        Insert(tmp.pRight, Root.pRight);
                    }
                    else Root.pRight = Root.pRight.pRight;
                }
            }
        }
        public double Avg()
        {
            return (double)Sum(Root) / Count(Root);
        }
        public void Clear()
        {
            this.Root = null;
        }
        public int Depth()
        {
            return Depth(Root);
        }
        int Depth(Element Root)
        {
            if (Root == null) return 0;
            int lDepth = Depth(Root.pLeft);
            int rDepth = Depth(Root.pRight);
            return (lDepth > rDepth ? lDepth : rDepth) + 1;
        }
        public void DepthPrint(int Depth)
        {
            DepthPrint(Root, Depth);
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
        }
        void DepthPrint(Element Root, int Depth)
        {
            if (Root == null)
            {
                PrintInterval(1);
                Console.Write("  ");
                PrintInterval(1);
                return;
            }
            if (Depth <= 0)
            {
                PrintInterval((int)Math.Pow(2, this.Depth(Root)) - 1);
                Console.Write(Root.Data);
                PrintInterval((int)Math.Pow(2, this.Depth(Root)) - 1);
            }
            else
            {
                DepthPrint(Root.pLeft, Depth - 1);
                DepthPrint(Root.pRight, Depth - 1);
            }
        }
        public void TreePrint(int Depth = 0)
        {
            if (Root == null) return;
            if (this.Depth(this.Root) - Depth <= 0) return;
            //DepthPrint(Depth);
            //TreePrint(Depth + 1);
            for (int i = 0; i < this.Depth(); i++)
            {
                DepthPrint(i);
            }
        }
        void PrintInterval(int Count)
        {
            for (int i = 0; i < Count; i++)
            {
                Console.Write(" ");
            }
        }
        public void Balance()
        {
            List<int> list = new List<int>();
            FillList(this.Root, list);
            Clear();
            BalanceList(Root, list);

        }
        void FillList(Element Root, List<int> list)
        {
            if (Root == null) return;
            FillList(Root.pLeft, list);
            list.Add(Root.Data);
            FillList(Root.pRight, list);
        }
        void BalanceList(Element Root, List<int> list)
        {
            if (list.Count == 0) return;
            int Count = list.Count() / 2;
            Insert(list[list.Count() / 2]);
            BalanceList(Root, list.Take(Count).ToList());
            BalanceList(Root, list.Skip(Count + 1).ToList());
        }
        public void Print() { Print(Root); Console.WriteLine(); }
        void Print(Element Root)
        {
            if (Root == null) return;
            Print(Root.pLeft);
            Console.Write(Root.Data + "\t");
            Print(Root.pRight);
        }
    }
}
