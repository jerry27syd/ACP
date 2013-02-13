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
            var lists = new List<WordCollection>();
            var subject = new WordCollection();

            subject.Add(new Word("I"));
            subject.Add(new Word("They"));
            subject.Add(new Word("She"));
            subject.Add(new Word("Jerry"));
            subject.Type = "SUBJECT";

            var verb = new WordCollection();
            verb.Add(new Word("is"));
            verb.Add(new Word("eat"));
            verb.Add(new Word("book"));
            verb.Type = "VERB";

            var noun = new WordCollection();

            noun.Add(new Word("cake"));
            noun.Add(new Word("rice"));
            noun.Type = "NOUN";
            

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
                            lists.Add(verb);
                        }
                        else
                        {
                            lists.Add(new WordCollection() {new Word(trimedSymbol)});
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