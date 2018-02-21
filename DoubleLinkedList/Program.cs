using System;

namespace DoubleLinkedList {
    class Program {
        static void Main(string[] _args) {
            Console.WriteLine("Starting DoubeLinkedList");

            DoubleLinkedList list = new DoubleLinkedList();
            list.append("This is the first String");
            list.toFirst();
            Console.WriteLine(list.getObject());


            Console.ReadLine();
        }
    }
}