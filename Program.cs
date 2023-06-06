namespace RingBuffer;

class Program
{
    static int Main()
    {
        RingBufferInt myArray = new RingBufferInt(2);
        myArray.AddElement(5);
        myArray.AddElement(3);
        myArray.AddElement(2);

        Console.WriteLine(myArray.GetLastElement()); 
        Console.WriteLine(myArray.GetElementAtIndex(0));
        Console.WriteLine(myArray.GetElementAtIndex(1));
        myArray.DeleteElement();
        Console.WriteLine(myArray.GetLastElement());
        myArray.DeleteElement();
        Console.WriteLine(myArray.GetLastElement());

        return 0;
    }
}

public class RingBufferInt
{
    private int length;

    public int Length
    {
        get { return length; }
    }

    private int[] localArray;
    private int currentWritePosition = 0;
    private int lastElementPosition = -1;

    public RingBufferInt(int length)
    {
        this.length = length;
        localArray = new int[length];
    }

    public void DeleteElement()
    {
        localArray[lastElementPosition] = 0;
        lastElementPosition = UpdatePosition(lastElementPosition);
    }

    public void AddElement(int element)
    {   
        if (currentWritePosition == lastElementPosition)
        {
            lastElementPosition = UpdatePosition(lastElementPosition);
        }

        if (lastElementPosition < 0)
            lastElementPosition = 0;

        localArray[currentWritePosition] = element;

        currentWritePosition = UpdatePosition(currentWritePosition);
    }

    public int GetLastElement()
    {
        return localArray[lastElementPosition];
    }

    public int GetElementAtIndex(int index)
    {
        return localArray[index];
    }

    private int UpdatePosition(int position)
    {
        if (position == length - 1)
        {
            return 0;
        }
        else return ++position;
    }
}
