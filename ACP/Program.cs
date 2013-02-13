using System;
using System.Collections.Generic;

namespace ACP
{
    internal class Program
    {
        public static bool HasDefiniton(string grammar)
        {
            var x = grammar.Split('(');

            return x.Length > 0;
        }

        private static void Main(string[] args)
        {
            var lists = new List<List<string>>();

            var noun = new List<string>();
            noun.Add("Jerry");
            noun.Add("Petter");
            noun.Add("John");

            var verb = new List<string>();

            verb.Add(VerbTense.ConvertToSimplePast("bid"));
            verb.Add(VerbTense.ConvertToSimplePast("eat"));
            verb.Add(VerbTense.ConvertToSimplePast("book"));

            var subject = new List<string>();
            subject.Add("a book");
            subject.Add("a cake");
            subject.Add("a cake");


            ConstantValue.GetGrammars().ForEach(c =>
                {
                    foreach (var symbol in c.Value.Split('+'))
                    {
                        var trimedSymbol = symbol.Trim();
                        if (HasDefiniton(trimedSymbol))
                        {
                            trimedSymbol = trimedSymbol.Split('(')[0];
                        }
                        if (trimedSymbol == "NOUN")
                        {
                            lists.Add(noun);
                        }
                        else if (trimedSymbol == "SUBJECT")
                        {
                            lists.Add(subject);
                        }
                        else if (trimedSymbol == "VERB")
                        {
                            foreach (var ve in verb)
                            {
                            }

                            lists.Add(verb);
                        }
                        else
                        {
                            lists.Add(new List<string>() {trimedSymbol});
                        }
                    }
                    new ListGenerator(lists).Generate().ForEach(Console.WriteLine);
                    Console.WriteLine("---");
                    lists.Clear();
                });


            Console.ReadKey();
        }
    }
}