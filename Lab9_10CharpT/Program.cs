using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;

namespace ConsoleApp2;

internal class Program
{
    static void Main(string[] args)
    {
        while (true)
        {
            Console.WriteLine("\n=============================");
            Console.WriteLine("        Lab 9 - Меню         ");
            Console.WriteLine("=============================");
            Console.WriteLine("1 - Завдання 1: Зворотні рядки (Stack)");
            Console.WriteLine("2 - Завдання 2: Голосні та приголосні (Queue)");
            Console.WriteLine("3 - Завдання 3: Зворотні рядки | олосні та приголосні (ArrayList)");
            Console.WriteLine("5 - Завдання 4: Каталог компакт-дисків (Hashtable)");
            Console.WriteLine("0 - Вихід");
            Console.WriteLine("=============================");
            Console.Write("Ваш вибір: ");

            string? choice = Console.ReadLine();
            Console.WriteLine();

            switch (choice)
            {
                case "1":
                    Compare_row.RunTask1();
                    break;
                case "2":
                    TextFile.RunTask_2();
                    break;
                case "3":
                    CompareRowArrayList.RunTask_3Row();
                    TextFileArrayList.RunTask2TextFile();
                    break;
                case "4":
                    Task_4.RunTask4();
                    break;
                case "0":
                    Console.WriteLine("Завершення роботи програми...");
                    return;
                default:
                    Console.WriteLine("Невірний вибір. Спробуйте ще раз.");
                    break;
            }
        }
    }
}