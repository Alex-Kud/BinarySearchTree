using System;
using System.Collections.Generic;
using System.IO;

namespace BinarySearchTree
{
    class BinarySearchTree
    {
        public Node Root { get; private set; }

        public BinarySearchTree()
        {
            Root = null;
        }

        public BinarySearchTree(long val)
        {
            Root = new Node(val);
        }

        public void Insert(long val)
        {
            // Возвращаем новый узел, если дерево пустое 
            if (Root == null)
            {
                Root = new Node(val);
                return;
            }
            Node current = Root; // Текущая вершина
            while (true)
            {
                if (val == current.Value)       // Добавляемое значение равно значению в текущей вершине
                    return;
                if (val < current.Value)        // Добавляемое значение меньше значения в текущей вершине
                {
                    if (current.Left == null)
                    {
                        current.Left = new Node(val);
                        return;
                    }
                    current = current.Left;
                }
                else                            // Добавляемое значение больше значения в текущей вершине
                {
                    if (current.Right == null)
                    {
                        current.Right = new Node(val);
                        return;
                    }
                    current = current.Right;
                }
            }
        }

        public void CenterTraversal(Node current)
        {
            if (current == null)
                return;
            CenterTraversal(current.Left);
            if (IsSimple(current.Value))
                Console.Write(current.Value + " ");
            CenterTraversal(current.Right);
        }

        public void WidthTraversal(Node current)
        {
            if (current == null)
                return;
            Queue<Node> nodes = new Queue<Node>();  // Создание очереди
            nodes.Enqueue(current);                 // Добавление в очередь
            while (nodes.Count > 0)
            {
                current = nodes.Dequeue();          // Извлечение из очереди
                if (IsSimple(current.Value))
                    Console.Write(current.Value + " ");
                if (current.Left != null)
                    nodes.Enqueue(current.Left);
                if (current.Right != null)
                    nodes.Enqueue(current.Right);
            }
        }

        public void PrintTree()
        {
            var globalStack = new Stack<Node>();        // Общий стек для значений дерева
            globalStack.Push(Root);
            bool isRowEmpty = false;
            string separator = "#################################################################";
            string result = separator + "\n\n";
            while (!isRowEmpty)
            {
                var localStack = new Stack<Node>();     // Локальный стек для задания потомков элемента
                isRowEmpty = true;
                // Пока в общем стеке есть элементы
                while (globalStack.Count > 0)
                { 
                    Node temp = globalStack.Pop();      // Берем следующий, при этом удаляя его из стека
                    if (temp != null)
                    {
                        result += temp.Value + "; ";    // Выводим его значение в консоли
                        localStack.Push(temp.Left);     // Соохраняем в локальный стек, наследники текущего элемента
                        localStack.Push(temp.Right);
                        if (temp.Left != null || temp.Right != null)
                            isRowEmpty = false;
                    }
                    else
                    {
                        result += "__; ";               // Если элемент пустой
                        localStack.Push(null);
                        localStack.Push(null);
                    }
                }
                result += "\n\n";
                while (localStack.Count > 0)
                    globalStack.Push(localStack.Pop()); // Перемещаем все элементы из локального стека в глобальный
            }
            result += separator;
            StreamWriter f = new StreamWriter("test.txt");
            f.WriteLine(result);
            f.Close();
            Console.WriteLine("\nДерево записано в файл!\n");
        }

        private bool IsSimple(long number)
        {
            for (int i = 2; i < number; i++)
            {
                if (number % i == 0)
                    return false;
            }
            return true;
        }
    }
}
