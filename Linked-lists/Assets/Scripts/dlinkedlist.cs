using System;
using System.Collections.Generic;
//using static DoubleLinkedList<T>;

//remove, addbefore, addafter, addfirst (addbefore head), removefirst, addlast (addafter tail), removelast (add and remove head/tail)

public class DoubleLinkedList<T> : IEnumerable<T> {
    public class DLLNode
    {
        public DLLNode next, prev;
        public T data;
    }

    DLLNode head = new DLLNode();
    DLLNode tail = new DLLNode();

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
            var it = head.next;
            while (it != tail)
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
        head.next = tail;
        tail.prev = head;
    }

    public DoubleLinkedList(IEnumerable<T> collection)
    {
        head.next = tail;
        tail.prev = head;
        var iter = collection.GetEnumerator();
        while (iter.MoveNext())
        {
            AddLast(iter.Current);
        }
    }

    public void AddLast(T value)
    {
        AddBefore(tail, value);
    }

    public void AddFirst(T value)
    {
        AddAfter(head, value);
    }

    public void AddAfter(DLLNode node, T value)
    {
        var newNode = new DLLNode();
        newNode.data = value;
        newNode.next = node.next;
        newNode.prev = node;
        node.next.prev = newNode;
        node.next = newNode;
    }

    public void AddBefore(DLLNode node, T value)
    {
        var newNode = new DLLNode();
        newNode.data = value;
        newNode.next = node;
        newNode.prev = node.prev;
        node.prev.next = newNode;
        node.prev = newNode;
    }

    void Remove(DLLNode node)
    {
        node.prev.next = node.next;
        node.next.prev = node.prev;
    }

    public void Remove(T value)
    {
        var removeNode = Find(value);
        Remove(removeNode);
    }

    #region IEnumerable implementation

    public IEnumerator<T> GetEnumerator()
    {
        var node = head.next;
        while (node != tail)
        {
            yield return node.data;
            node = node.next;
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
        var it = head.next;
        while (it != tail && !(it.data.Equals(data)))
        {
            it = it.next;
        }
        return it;
    }

    public DLLNode GetNode(int i)
    {
        var it = head.next;
        while (i > 0)
        {
            it = it.next; //error
            i--;
        }
        return it;
    }
}
