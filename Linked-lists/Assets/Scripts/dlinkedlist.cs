using System.Collections.Generic;

//Insert, remove, addfirst, removefirst, addlast, removelast (add and remove head/tail), addbefore, addafter

public class DoubleLinkedList<T> : IEnumerable<T> {
    public class DLLNode
    {
        public DLLNode next;
        public DLLNode prev;
        public T data;
    }

    DLLNode head;
    DLLNode tail;

    public DLLNode First
    {
        get
        {
            return head;
        }
    }

    public DLLNode Last
    {
        get
        {
            return tail;
        }
    }

    public void Insert(int index, T data)
    {
        var newNode = new DLLNode();
        newNode.data = data;
        if (index == 0)
        {
            newNode.next = head;
            newNode.prev = null;
            head = newNode;
        }

        else
        {
            var left = GetNode(index - 1);
            var right = left.next;
            left.next = newNode;
            newNode.next = right;
            newNode.prev = left;
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

    public DLLNode GetNode(int i)
    {
        var it = head;
        while (i > 0)
        {
            it = it.next;
            i--;
        }
        return it;
    }
}
