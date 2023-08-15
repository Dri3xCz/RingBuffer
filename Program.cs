namespace RingBufferNamespace;

class Program
{
    static int Main()
    {
        RingBuffer<int> myArray = new RingBuffer<int>(2);
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

public class RingBuffer<T>
{
    private int length;

    public int Length
    {
        get { return length; }
    }

    private T[] localArray;
    private int currentWritePosition = 0;
    private int lastElementPosition = -1;

    public RingBuffer(int length)
    {
        this.length = length;
        localArray = new T[length];
    }

    public void DeleteElement()
    {
        localArray[lastElementPosition] = default;
        lastElementPosition = UpdatePosition(lastElementPosition);
    }

    public void AddElement(T element)
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

    public T GetLastElement()
    {
        return localArray[lastElementPosition];
    }

    public T GetElementAtIndex(int index)
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
