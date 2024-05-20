using System.Collections.Generic;
//using static DoubleLinkedList<T>;

//remove, addbefore, addafter, addfirst (addbefore head), removefirst, addlast (addafter tail), removelast (add and remove head/tail)

public class DoubleLinkedList<T> : IEnumerable<T> {
    public class DLLNode
    {
        public DLLNode next, prev;
        public T data;
    }

    DLLNode head;
    DLLNode tail;

    public DLLNode First
    {
        get
        {
            return head.next;
        }
    }

    public DLLNode Last
    {
        get
        {
            return tail.prev;
        }
    }

    public int Count
    {
        get
        {
            int n = 0;
            var it = head;
            while (it != null)
            {
                n++;
                it = it.next;
            }
            return n;
        }
    }

    public T GetValue(int i)
    {
        var it = GetNode(i);
        return it.data;
    }

    public DoubleLinkedList() 
    { 
        var sentinel1 = new DLLNode();
        var sentinel2 = new DLLNode();
    }

    public DoubleLinkedList(IEnumerable<T> collection)
    {
        var iter = collection.GetEnumerator();
        while (iter.MoveNext())
        {
            AddLast(iter.Current);
        }
    }

    //public void Insert(int index, T data)
    //{
    //    var newNode = new DLLNode();
    //    newNode.data = data;
    //    if (index == 0)
    //    {
    //        newNode.next = head;
    //        newNode.prev = null;
    //        head = newNode;
    //    }

    //    else
    //    {
    //        var left = GetNode(index - 1);
    //        var right = left.next;
    //        left.next = newNode;
    //        newNode.next = right;
    //        newNode.prev = left;
    //    }
    //}

    public void AddStart(T value)
    {
        var newNode = new DLLNode();
        newNode.data = value;
        newNode.next = head;
        head = newNode;
    }

    public void AddLast(T value)
    {
        var last = head;
        while (last.next != null)
        {
            last = last.next;
        }
        var newNode = new DLLNode();
        newNode.data = value;
        newNode.next = null;
        last.next = newNode;
    }

    public void AddAfter(DLLNode node, T value)
    {
        var newNode = new DLLNode();
        newNode.data = value;
        var it = FindNode(node);
        if (it != null)
        {
            newNode.next = it.next;
            it.next = newNode;
        }
        else
            throw new System.Exception("node not found");
    }

    public void AddBefore(DLLNode node, T value)
    {
        var newNode = new DLLNode();
        newNode.data = value;
        if (node == head)
        {
            newNode.next = head;
            head = newNode;
        }
        else
        {
            var it = FindPreviousNode(node);
            if (it != null)
            {
                newNode.next = it.next;
                it.next = newNode;
            }
            else
            {
                throw new System.Exception("node not found");
            }
        }
    }

    void Remove(DLLNode node)
    {
        if (node == head)
        {
            head = head.next;
        }
        else if (node == tail)
        {
            tail = tail.prev;
        }
        else
        {
            var iter = FindPreviousNode(node);
            if (iter != null)
            {
                iter.next = node.next;
            } 
            else
            {
                throw new System.InvalidOperationException("node not found");
            }
        }
    }
    public void Remove(T value)
    {
        if (head != null && head.data.Equals(value))
        {
            head = head.next;
        }
        else
        {
            var node = head.next;
            var left = head;
            while (node != null)
            {
                if (node.data.Equals(value))
                {
                    left.next = node.next;
                    return;
                }
                left = node;
                node = node.next;
            }
            throw new System.InvalidOperationException("node not found");
        }
    }

    #region IEnumerable implementation

    public IEnumerator<T> GetEnumerator()
    {
        if (head != null)
        {
            var node = head;
            while (node != null)
            {
                yield return node.data;
                node = node.next;
            }
        }

        if (tail != null)
        {
            var node = tail;
            while (node != null)
            {
                yield return node.data;
                node = node.prev;
            }
        }
    }

    #endregion

    #region IEnumerable implementation

    System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
    {
        return this.GetEnumerator();
    }

    #endregion

    public DLLNode Find(T data)
    {
        var it = head;
        while (it != null && !(it.data.Equals(data)))
        {
            it = it.next;
        }
        return it;
    }

    // not in C# LinkedList (not needed in DLL)
    public DLLNode FindNode(DLLNode node)
    {
        var it = head;
        while (it != null && it != node)
        {
            it = it.next;
        }
        return it;
    }

    // not in C# LinkedList (not needed in DLL)
    public DLLNode FindPreviousNode(DLLNode node)
    {
        var it = head;
        while (it != null && it.next != node)
        {
            it = it.next;
        }
        return (it != null && it.next == node) ? it : null;
    }

    public DLLNode GetNode(int i)
    {
        var it = head;
        while (i > 0)
        {
            it = it.next; //error
            i--;
        }
        return it;
    }
}
