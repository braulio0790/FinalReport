using System;
using System.Collections.Generic;

namespace FinalWeek10
{
    // This is a simple generic queue (can store string, int, etc.)
    public class LQueue<T>
    {
        // Internal list that holds the data
        private List<T> _list = new List<T>();

        // Property to get the number of items in the queue
        public int Size
        {
            get
            {
                return _list.Count;
            }
        }

        // Property to get how much the list can hold before growing
        public int Capacity
        {
            get
            {
                return _list.Capacity;
            }
        }

        // This method adds a new item at the end of the queue
        public void Enqueue(T item)
        {
            // Add item to the end
            _list.Add(item); // fast unless list grows
        }

        // This method removes and returns the first item in the queue
        public T Dequeue()
        {
            // If queue is empty, we can't remove anything
            if (_list.Count == 0)
            {
                throw new InvalidOperationException("Queue is empty");
            }

            // Save the first item
            T item = _list[0];

            // Remove that item (will shift the rest)
            _list.RemoveAt(0);

            // Return the removed item
            return item;
        }

        // This method shows the first item without removing it
        public T Peek()
        {
            // If queue is empty, there's nothing to see
            if (_list.Count == 0)
            {
                throw new InvalidOperationException("Queue is empty");
            }

            // Return the first item
            return _list[0];
        }

        // This method checks if a value exists in the queue
        public bool Contains(T item)
        {
            // Looks for the item in the list
            return _list.Contains(item);
        }
    }
}



    
