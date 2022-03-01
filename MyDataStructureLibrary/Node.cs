namespace MyDataStructureLibrary;

/// <summary>
/// Node class encapsulates the node for the linked list
/// </summary>
/// <typeparam name="T"></typeparam>
public class Node<T> where T : IComparable
{
    public T data;
    public Node<T> next;
    public Node(T data)
    {
        this.data = data;
    }
}
