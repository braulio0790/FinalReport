using System;

namespace Week11FinalApp
{
    // This class defines a generic queue using a circular buffer
    public class AQueue<T>
    {
        private T[] _array; // This array holds the queue items
        private int _front; // Points to the front item
        private int _rear;  // Points to the rear item
        private int _capacity; // Maximum size + 1 to handle full vs empty easily

        // Constructor to set the size of the queue
        public AQueue(int capacity)
        {
            _capacity = capacity + 1; // One extra space to differentiate full/empty
            _array = new T[_capacity]; // Create the array
            _front = 0; // Initialize front pointer. the recorded value will change with each dequeue
            _rear = 0;  // Initialize rear pointer. the recorded value will change with each enqueue
        }

        // Adds an item to the queue
        public void Enqueue(T item)
        {
            // Check if queue is full
            if ((_rear + 1) % _capacity == _front) 
            {
                throw new InvalidOperationException("Queue is full!"); // If full, throw exception
            }
            else
            {
                _array[_rear] = item; // Indicates what is the current rear position
                _rear = (_rear + 1) % _capacity; // The rear value increase 1 with each enqueue to move through the list
            }
        }

        // Removes and returns the front item from the queue
        public T Dequeue()
        {
            // Check if queue is empty
            if (_front == _rear) 
            {
                throw new InvalidOperationException("Queue is empty!"); // If empty, throw exception
            }
            else
            {
                T value = _array[_front]; // Indicates what is the current front position
                _front = (_front + 1) % _capacity; // The front value increase 1 with each dequeue to move through the list
                return value; // Return the removed item
            }
        }

        // Returns the front item only
        public T Peek()
        {
            // Check if queue is empty
            if (_front == _rear) 
            {
                throw new InvalidOperationException("Queue is empty!"); // If empty, throw exception
            }
            return _array[_front]; // Return front item only
        }

        // Checks if the queue contains a specific item
        public bool Contains(T item)
        {
            int i = _front; // Start from the front position
            while (i != _rear) // Loop will not run if list is empty or is done
            {
                if (_array[i].Equals(item)) // Search for the item
                {
                    return true; // If found, return true
                }
                else
                {
                    i = (i + 1) % _capacity; // Move forward circularly
                }
            }
            return false; // Item not found
        }

        // Property to return the current size of the queue
        public int Size
        {
            get
            {
                return (_rear - _front + _capacity) % _capacity; // Calculate current size using circular logic
            }
        }

        // Property to return the capacity without counting the extra slot
        public int Capacity
        {
            get
            {
                return _capacity - 1; // Real capacity (excluding extra slot)
            }
        }
    }
}