using System; // Using System namespace for exceptions
using System.Collections.Generic; // Using generic collections for LinkedList

namespace Week12_Final_Project
{
    // Generic queue implemented with LinkedList<T>
    public class LLQueue<T>
    {
        private LinkedList<T> _list = new LinkedList<T>(); // Create a LinkedList to hold the queue items
        
        // Property to get how many items are currently in the queue
        public int Size => _list.Count; // LinkedList already provides Count, we use it here

        // Method to add an item to the back of the queue
        public void Enqueue(T item)
        {
            _list.AddLast(item); // Add item at the end of the linked list (back of the queue)
        }

        // Method to remove and return the first item in the queue
        public T Dequeue()
        {
            if (_list.Count == 0) // Check if there are no items
                throw new InvalidOperationException("Queue is empty."); // Throw exception if empty
            T value = _list.First.Value; // Store the value of the first item
            _list.RemoveFirst(); // Remove the first item from the list
            return value; // Return the stored value
        }

        // Method to return the first item without removing it
        public T Peek()
        {
            if (_list.Count == 0) // Again, check if queue is empty
                throw new InvalidOperationException("Queue is empty."); // Throw if empty
            return _list.First.Value; // Return the value of the first item
        }

        // Method to check if a specific item is inside the queue
        public bool Contains(T item)
        {
            return _list.Contains(item); // Use built-in Contains method from LinkedList
        }
    }
} 