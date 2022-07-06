using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// BoundedQueue Class - Queue with a limit
public class BoundedQueue {
    public Queue MyQueue;
    private int MaxElements;
    private int NumElements;
    
    // BoundedQueue Constructor
    public BoundedQueue(int num) {
        MaxElements = num;
        NumElements = 0;
        MyQueue = new Queue(MaxElements);
    }
    
    // Enqueue into BoundedQueue
    public void Enqueue(object n) {
        // Check to see if queue is full
        if (MyQueue.Count >= MaxElements) {
            //Debug.Log("Cannot enqueue when queue is full");
            throw new InvalidOperationException("Cannot enqueue when queue is full");
        }

        // Enqueue given object into queue
        MyQueue.Enqueue(n);
        NumElements++;
        return;
    }
    
    // Dequeue from BoundedQueue
    public object Dequeue() {
        // Dequeue value from queue and return dequeued value
        object dequeued = MyQueue.Dequeue();
        NumElements--;
        return dequeued;
    }

    // Dump the elements in the BoundedQueue
    public void DumpQueue() {

        // Store queue elements in array
        object[] arr = MyQueue.ToArray();

        //For each packet in the array, dump the id
        foreach (object obj in arr)
        {
            // Debug.Log(((Packet)obj).GetId() + " ");
        }
    }
    
    // Return max number of elements of queue
    public int QueueMax() {
        return MaxElements;
    }
    
    // Return number of elements in queue
    public int QueueLen() {
        return NumElements;
    }

}