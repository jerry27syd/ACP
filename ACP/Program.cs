﻿using System;
using System.Collections.Generic;

namespace ACP
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var lists = new List<List<string>>();

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
            lists.Add(noun);
            lists.Add(verb);
            lists.Add(verb);

            new ListGenerator(lists).Generate().ForEach(Console.WriteLine);

            Console.ReadKey();
        }
    }
}