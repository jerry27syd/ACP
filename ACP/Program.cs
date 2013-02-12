using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACP
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var list = new List<string>();

            var noun = new List<string>();
            noun.Add("Jerry");
            noun.Add("Petter");
            noun.Add("John");

            var verb = new List<string>();

            verb.Add("makes");
            verb.Add("studies");

            var subject = new List<string>();
            subject.Add("a book");
            subject.Add("a cake");
            subject.Add("a cake");


            var lists = new List<List<string>>();

            lists.Add(noun);
            lists.Add(verb);
            lists.Add(subject);


            var indexer = new Indexer(lists);


            while (!indexer.End)
            {
                for (int i = 0; i < indexer.Indices.Count; i++)
                {
                    var index = indexer.Indices[i];
                    Console.Write(lists[i][index] + " ");
                }
                Console.WriteLine();
                indexer.Increment();
            }

            Console.ReadKey();
        }
    }

    public class Indexer
    {
        public List<int> Limits = new List<int>();
        public List<int> Indices = new List<int>();

        public Indexer(IEnumerable<IEnumerable<object>> items)
        {
            foreach (var item in items)
            {
                Limits.Add(item.Count());
                Indices.Add(0);
            }
        }

        public bool End { get; set; }

        public void Increment(int value = 1, int index = 0)
        {
            if (End) return;
            int tryAdd = Indices[index] + value;
            if (tryAdd >= Limits[index])
            {
                Indices[index] = tryAdd%Limits[index];
                var nextIndex = index + 1;
                if (nextIndex < Indices.Count)
                {
                    tryAdd = tryAdd/Limits[index];
                    index++;
                    Increment(tryAdd, index);
                }
                else
                {
                    End = true;
                }
            }
            else
            {
                Indices[index] = tryAdd;
            }
        }
    }


    public class Test
    {
        private List<int> limits = new List<int>();
        private List<int> indexes = new List<int>();

        public Test(List<string> items)
        {
            foreach (var item in items)
            {
                limits.Add(item.Count());
            }
        }

        public void Reset()
        {
        }

        public void Increment(int value = 1)
        {
            int index = 0;
            if (value > limits[index])
            {
            }
        }

        public void Decrement()
        {
        }
    }

    #region Test1

    public class Node
    {
        public Node Next { get; set; }
        public int Value { get; set; }
    }

    public class Test1
    {
        public Test1()
        {
            Node root = new Node();
            var n = new Node();
            n.Value = 10;
            root.Next = n;


            Show(root);
        }

        private void Show(Node root)
        {
            Console.WriteLine(root.Value);
            if (root.Next == null)
            {
                return;
            }
            Show(root.Next);
        }
    }

    #endregion

    #region Test2

    internal class Test2
    {
        public Test2()
        {
            var ls = new List<string>();
            ls.Add("A");
            ls.Add("B");
            ls.Add("C");


            foreach (var l in ls)
            {
                Console.WriteLine(l);
            }

            for (int i = 0; i < ls.Count; i++)
            {
                Console.WriteLine(ls[i]);
            }

            ls.ForEach(Console.WriteLine);


            var index = 0;
            while (index < ls.Count)
            {
                Console.WriteLine(ls[index]);
                index++;
            }
            foreach (var l in ls)
            {
                Console.WriteLine(l);
            }


            Func(ls, 0);
        }

        private void Run(dynamic ls)
        {
            foreach (var obj in ls)
            {
                if (obj.GetType() == typeof (List<string>))
                {
                    Run(obj);
                }
                else
                {
                }
            }
        }

        private class Node
        {
            private List<Node> Next;
        }

        private void Func(List<string> ls, int index)
        {
            Console.WriteLine(ls[index]);
            index++;
            if (index < ls.Count)
            {
                Func(ls, index);
            }
        }
    }

    #endregion
}