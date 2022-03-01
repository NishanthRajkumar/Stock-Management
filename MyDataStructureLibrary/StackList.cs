namespace MyDataStructureLibrary;

/// <summary>
/// Handles stack operations
/// </summary>
public class StackList<T> : MyLinkedList<T> where T : IComparable
{
    /// <summary>
    /// Default constructor
    /// </summary>
    /// <returns></returns>
    public static StackList<T> Stack()
    {
        return new StackList<T>();
    }

    /// <summary>
    /// Pushes the specified data to stack
    /// </summary>
    /// <param name="data">The data.</param>
    public void Push(T data)
    {
        Add(data);
    }

    /// <summary>
    /// Peeks the top element
    /// </summary>
    /// <returns></returns>
    public T Peek()
    {
        return head.data;
    }

    /// <summary>
    /// Pops the first element in stack.
    /// </summary>
    public new void Pop()
    {
        base.Pop();
    }
}
