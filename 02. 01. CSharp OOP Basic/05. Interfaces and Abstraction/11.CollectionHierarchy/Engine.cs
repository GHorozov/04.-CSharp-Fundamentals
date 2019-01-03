using System;

public class Engine
{
    private IAddCollection addCollection;
    private IAddRemoveCollection addRemoveCollection;
    private IMyList myList;

    public Engine()
    {
        this.addCollection = new AddCollection();
        this.addRemoveCollection = new AddRemoveCollection();
        this.myList = new MyList();
    }

    public void Run()
    {
        var input = Console.ReadLine().Split();
        var removeNumber = int.Parse(Console.ReadLine());

        var resultOne = FillCollection(input, addCollection);
        var resultTwo = FillCollection(input, addRemoveCollection);
        var resultThree = FillCollection(input, myList);
        var resultRemoveOne = RemoveOperation(removeNumber, addRemoveCollection);
        var resultRemoveTwo = RemoveOperation(removeNumber, myList);

        Console.WriteLine(string.Join(" ", resultOne));
        Console.WriteLine(string.Join(" ", resultTwo));
        Console.WriteLine(string.Join(" ", resultThree));
        Console.WriteLine(string.Join(" ", resultRemoveOne));
        Console.WriteLine(string.Join(" ", resultRemoveTwo));
    }

    private string[] RemoveOperation(int removeNumber, IAddRemoveCollection collection)
    {
        var result = new string[removeNumber];
        for (int i = 0; i < removeNumber; i++)
        {
            result[i] = collection.Remove();
        }

        return result;
    }

    private int[] FillCollection(string[] input, IAddCollection collection)
    {
        var result = new int[input.Length];
        for (int i = 0; i < input.Length; i++)
        {
            result[i] = collection.Add(input[i]);
        }

        return result;
    }
}
