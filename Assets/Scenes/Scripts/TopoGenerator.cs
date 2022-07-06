using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopoGenerator : MonoBehaviour
{
    public int numGenerators;
    public GameObject generatorPrefab;

    public int numQueues;
    public GameObject queuePrefab;

    public int maxLength;
    public int numPackets;

    // This constructor is overriden by Unity, params are set in Unity Inspector
    public TopoGenerator(int numOfGenerators, int numOfQueues) {
        numGenerators= numOfGenerators;
        numQueues = numOfQueues;
    }

    // Start is called before the first frame update
    void Start()
    {
        // Create packet generators based on number of packet generators set through Unity Inspector
        for (var i = 0; i < numGenerators; i++) {
            // Instantiate a queue and position it appropriately based on the queue number
            GameObject go = Instantiate(generatorPrefab, transform.position+ new Vector3(0, i* (-2.0f),0), Quaternion.identity);
        }

        // Store init params in an array
        int[] initQueueParams = new int[2];
        initQueueParams[0] = maxLength;
        initQueueParams[1] = numPackets;

        // Create queues based on number of queues set in TopoGenerator constructor
        for (var i = 0; i < numQueues; i++) {
            // Instantiate a queue and position it appropriately based on the queue number
            GameObject go = Instantiate(queuePrefab, transform.position+ new Vector3(0, (-2.0f * numGenerators) + i* (-2.0f),0), Quaternion.identity);
            
            // Init the max length of the queue and the num of packets in each queue
            go.SendMessage("Init", initQueueParams);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
