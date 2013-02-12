using System;
using System.Collections.Generic;

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
                var str = string.Empty;
                for (int i = 0; i < indexer.Indices.Count; i++)
                {
                    int index = indexer.Indices[i];
                    
                    str += lists[i][index] + " ";
                }
                list.Add(str);
                indexer.Increment();
            }

            Console.ReadKey();
        }
    }
}