using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// PacketQueue Class
public class PacketQueue : MonoBehaviour
{
    // Logical Attributes
    public int MaxLength;
    public int NumPackets;

    // Display Attributes
    public GameObject OriginalObject;
    public GameObject ClonedObject;
    public Shader Shader;
    public Renderer Rend;
    public BoundedQueue Queue;

    public void InitPacketQueue() {
        Queue = new BoundedQueue(MaxLength);
    }

    // Init is called right after Instantiate is done
    void Init(int[] arr) {
        // Instantiate max length and num packets, called by TopoGenerator
        MaxLength = arr[0];
        NumPackets = arr[1];

        // Initialize a bounded queue to hold packets
        InitPacketQueue();
    }

    // Start is called before the first frame update
    void Start()
    {
        try {
            // Create a few packets and set position to show on the queue - This code is temporary. Will fix it in next rev
            for (int i = 0; i < NumPackets; i++) {
                ClonedObject = Instantiate(OriginalObject, transform.position + new Vector3(i*(-1.0f), 0,0), Quaternion.identity);
                ClonedObject.GetComponent<Packet>().InQueue = true;

                // Store them in the queue's BoundedQueue object - Doesn't work, getting error on enqueue line
                Queue.Enqueue(ClonedObject);

                //Debug.Log("Enqueued Element " + ClonedObject.GetComponent<Packet>().GetId() + " in Queue");
            }
        } catch(InvalidOperationException e) {
            // Debug.Log("{0} Exception caught", e);
        }
        
        // Set values for the background of the queue
        Rend = GetComponent<Renderer>();
        Rend.material = new Material(Shader);
        Rend.material.color = Color.white;

        // Scale background of queue based on MaxLength of queue
        Vector3 objectScale = transform.localScale;
        transform.localScale = new Vector3((objectScale.x) * (MaxLength),  objectScale.y+0.1f, objectScale.z);

        // Move the background to align properly with the packets
        transform.position -= new Vector3(objectScale.x/2 + (MaxLength * 0.5f) - 1, 0, 0);
    }


    // Update is called once per frame
    void Update()
    {

    }   
}

