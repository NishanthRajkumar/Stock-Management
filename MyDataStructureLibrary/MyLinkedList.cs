namespace MyDataStructureLibrary;

/// <summary>
/// This is the base abstract class for all generic data structure lists
/// </summary>
public abstract class MyLinkedList<T> where T : IComparable
{
    // Declared Node Object
    protected Node<T> head;

    /// <summary>
    /// Initializes a new instance of the <see cref="UnOrderedLinkedList{T}"/> class.
    /// </summary>
    public MyLinkedList()
    {
        head = null;
    }

    /// <summary>
    /// Determines whether the list is empty.
    /// </summary>
    /// <returns>
    ///   <c>true</c> if this instance is empty; otherwise, <c>false</c>.
    /// </returns>
    public bool IsEmpty()
    {
        if (head == null)
            return true;
        return false;
    }

    /// <summary>
    /// Appends the specified data to end of list.
    /// </summary>
    protected void Append(T data)
    {
        Node<T> node = new Node<T>(data);
        if (IsEmpty())
            head = node;
        else
        {
            Node<T> temp = head;
            while (temp.next != null)
                temp = temp.next;
            temp.next = node;
        }
    }

    /// <summary>
    /// Displays the list.
    /// </summary>
    public void Display()
    {
        Node<T> temp = head;
        while (temp != null)
        {
            Console.Write(temp.data + "\n");
            temp = temp.next;
        }
    }

    /// <summary>
    /// Adds the specified data at the begining of the list.
    /// </summary>
    protected void Add(T data)
    {
        Node<T> node = new Node<T>(data);
        if (IsEmpty())
            head = node;
        else
        {
            node.next = head;
            head = node;
        }
    }

    /// <summary>
    /// Inserts data at the specified position.
    /// </summary>
    /// <param name="pos">The position.</param>
    /// <param name="data">The data.</param>
    protected void Insert(int pos, T data)
    {
        Node<T> temp = head;
        if (pos < 0)
        {
            Console.WriteLine("Invalid position");
            return;
        }
        if (pos == 0)
            Add(data);
        else
        {
            Node<T> node = new Node<T>(data);
            for (int i = 1; i < pos; i++)
                temp = temp.next;
            if (temp == null)
                return;
            node.next = temp.next;
            temp.next = node;
        }
    }

    /// <summary>
    /// Pops the first element in list.
    /// </summary>
    protected void Pop()
    {
        if (head == null)
            return;
        else
            head = head.next;
    }

    /// <summary>
    /// Pops the last element in list.
    /// </summary>
    protected void PopLast()
    {
        if (head == null)
            return;
        if (head.next == null)
            head = null;
        else
        {
            Node<T> temp = head;
            while (temp.next.next != null)
                temp = temp.next;
            temp.next = null;
        }
    }

    /// <summary>
    /// Searches the specified data.
    /// </summary>
    public bool Search(T data)
    {
        Node<T> temp = head;
        while (temp != null)
        {
            if (temp.data.CompareTo(data) == 0)
                return true;
            temp = temp.next;
        }
        return false;
    }

    /// <summary>
    /// Returns the index in the list where the data is found
    /// </summary>
    /// <param name="data">The data.</param>
    /// <returns></returns>
    public int Index(T data)
    {
        int index = 0;
        Node<T> temp = head;
        while (temp != null)
        {
            if (temp.data.CompareTo(data) == 0)
                return index;
            temp = temp.next;
            index++;
        }
        return -1;
    }

    /// <summary>
    /// Removes the specified data.
    /// </summary>
    /// <param name="data">The data.</param>
    public void Remove(T data)
    {
        if (IsEmpty())
            return;
        if (head.data.CompareTo(data) == 0)
            head = head.next;
        else
        {
            Node<T> temp = head;
            while (temp != null)
            {
                if (temp.next.data.CompareTo(data) == 0)
                {
                    temp.next = temp.next.next;
                    return;
                }
                temp = temp.next;
            }
        }
    }

    /// <summary>
    /// Returns the size of the list(No of elements in list)
    /// </summary>
    /// <returns></returns>
    public int Size()
    {
        int size = 0;
        Node<T> temp = head;
        while (temp != null)
        {
            size++;
            temp = temp.next;
        }
        return size;
    }
}
