using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Packet Generator Class
public class PacketGenerator : MonoBehaviour
{
    public GameObject originalObject;
    GameObject clonedObject;
    public int tick;

    // Start is called before the first frame update
    void Start()
    {
        tick = 0;
    }

    // Update is called once per frame
    void Update()
    {
        // Create a new packet every 100 ticks
        if (++tick % 100 != 0) {
            return;
        }

        // Original object is set to the prefab for Packet 
        // Instantiate creates a new packet at position of packet generator object
        clonedObject = Instantiate(originalObject, 
                                    new Vector3(transform.position.x, 
                                                transform.position.y,
                                                transform.position.z),
                                    Quaternion.identity);            
    }
}
