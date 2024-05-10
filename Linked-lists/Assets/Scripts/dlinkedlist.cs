using System.Collections.Generic;

//Insert, remove, addfirst, removefirst, addlast, removelast (add and remove head/tail)

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
    }

    #endregion

    #region IEnumerable implementation

    System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
    {
        return this.GetEnumerator();
    }

    #endregion
}
