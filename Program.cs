using System;
using System.Collections.Generic;

class Set
{
    private List<int> elements;

    public Set()
    {
        elements = new List<int>();
    }

    public Set(List<int> elements)
    {
        this.elements = elements;
    }

    ~Set()
    {
        Console.WriteLine("Деструктор вызван");
    }

    public Set Union(Set otherSet)
    {
        List<int> result = new List<int>(this.elements);
        foreach (int element in otherSet.elements)
        {
            if (!result.Contains(element))
            {
                result.Add(element);
            }
        }
        return new Set(result);
    }

    public Set Intersection(Set otherSet)
    {
        List<int> result = new List<int>();
        foreach (int element in this.elements)
        {
            if (otherSet.elements.Contains(element))
            {
                result.Add(element);
            }
        }
        return new Set(result);
    }

    public Set Difference(Set otherSet)
    {
        List<int> result = new List<int>(this.elements);
        foreach (int element in otherSet.elements)
        {
            if (result.Contains(element))
            {
                result.Remove(element);
            }
        }
        return new Set(result);
    }

    public void AddElement(int element)
    {
        if (!elements.Contains(element))
        {
            elements.Add(element);
        }
    }

    public void RemoveElement(int element)
    {
        elements.Remove(element);
    }

    public bool Includes(Set otherSet)
    {
        foreach (int element in otherSet.elements)
        {
            if (!elements.Contains(element))
            {
                return false;
            }
        }
        return true;
    }

    public bool IsEmpty()
    {
        return elements.Count == 0;
    }

    public bool Equals(Set otherSet)
    {
        if (elements.Count != otherSet.elements.Count)
        {
            return false;
        }

        foreach (int element in elements)
        {
            if (!otherSet.elements.Contains(element))
            {
                return false;
            }
        }

        return true;
    }

    public void Print()
    {
        foreach (int element in elements)
        {
            Console.Write(element + " ");
        }
        Console.WriteLine();
    }
}

class Program
{
    static void Main()
    {
        Console.WriteLine("Введите элементы для 1 набора через пробел:");
        string input1 = Console.ReadLine();
        string[] elements1 = input1.Split(' ');

        Set set1 = new Set();
        foreach (string element in elements1)
        {
            if (int.TryParse(element, out int num))
            {
                set1.AddElement(num);
            }
        }

        Console.WriteLine("Введите элементы для 2 набора через пробел::");
        string input2 = Console.ReadLine();
        string[] elements2 = input2.Split(' ');

        Set set2 = new Set();
        foreach (string element in elements2)
        {
            if (int.TryParse(element, out int num))
            {
                set2.AddElement(num);
            }
        }

        Set unionSet = set1.Union(set2);
        Console.WriteLine("Объединение:");
        unionSet.Print();

        Set intersectionSet = set1.Intersection(set2);
        Console.WriteLine("Пересечения:");
        intersectionSet.Print();

        Set differenceSet = set1.Difference(set2);
        Console.WriteLine("Разность:");
        differenceSet.Print();

        Console.WriteLine("Набор 1 включает в себя набор 2: " + set1.Includes(set2));
        Console.WriteLine("Набор 1 пустой: " + set1.IsEmpty());
        Console.WriteLine("Набор 1 идентичный набору 2: " + set1.Equals(set2));
    }
}
