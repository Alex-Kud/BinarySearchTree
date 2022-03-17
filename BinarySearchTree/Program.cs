using System;
using System.Diagnostics;

namespace BinarySearchTree
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("Введите 0 для завершения программы:");
                Console.WriteLine("Введите 1 для запуска:");
                
                int typeCommand;
                try
                {
                    typeCommand = Convert.ToInt32(Console.ReadLine());
                }
                catch (FormatException)
                {
                    Console.WriteLine("Введено некорректное значение команды! Повторите попытку!");
                    continue;
                }
                while (typeCommand < 0 || typeCommand > 1)
                {
                    Console.WriteLine("Ошибка! Команда не найдена! Введите значение снова");
                    try
                    {
                        typeCommand = Convert.ToInt32(Console.ReadLine());
                    }
                    catch (FormatException)
                    {
                        Console.WriteLine("Введено некорректное значение команды! Повторите попытку");
                    }
                }
                switch (typeCommand)
                {
                    case 0:
                        return;
                    case 1:
                        Console.WriteLine("Введите размерность дерева:");
                        try
                        {
                            int n = Convert.ToInt32(Console.ReadLine());
                            if (n < 1)
                            {
                                Console.WriteLine("Введено некорректное значение размерности! Повторите попытку");
                                break;
                            }
                            TestingTheTree(n);
                        }
                        catch (FormatException)
                        {
                            Console.WriteLine("Введено некорректное значение размерности! Повторите попытку");
                        }
                        break;
                    default:
                    {
                        return;
                    }
                }
            }
        }

        private static void TestingTheTree(int n)
        {
            Random rnd = new Random();      // Создание объекта для генерации чисел
            Stopwatch centerTime = new Stopwatch(), widthTime = new Stopwatch();

            BinarySearchTree tree = new BinarySearchTree();
            for (int i = 0; i < n; ++i)
                tree.Insert(rnd.Next(0, 100));

            Console.WriteLine("\nЦентрированный обход дерева в глубину:");
            Console.Write("Найденные простые числа: ");
            centerTime.Start();
            tree.CenterTraversal(tree.Root);
            centerTime.Stop();
            Console.WriteLine("\nВремя выполнения: " + centerTime.ElapsedTicks.ToString());

            Console.WriteLine("\nОбход дерева в ширину:");
            Console.Write("Найденные простые числа: ");
            widthTime.Start();
            tree.WidthTraversal(tree.Root);
            widthTime.Stop();
            Console.WriteLine("\nВремя выполнения: " + widthTime.ElapsedTicks.ToString());

            if (centerTime.ElapsedTicks > widthTime.ElapsedTicks)
            {
                Console.WriteLine("\nВремя выполнения обхода в глубину больше, чем время выполнения обхода в ширину");
            }
            else if (centerTime.ElapsedTicks < widthTime.ElapsedTicks)
            {
                Console.WriteLine("\nВремя выполнения обхода в глубину меньше, чем время выполнения обхода в ширину");
            }
            else
            {
                Console.WriteLine("\nВремя выполнения обхода в  глубину равно времени выполнения обхода в ширину");
            }

            tree.PrintTree();
        }

    }
}
