using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Packet Class
public class Packet : MonoBehaviour
{
    // Logical Attributes
    public static int GlobalPacketId = 0;
    private int Id; // Packet ID
    public bool InQueue;

    // Display Attributes
    public Vector3 Vector = new Vector3(1,0,0);
    public float MoveSpeed = 10f;
    public Renderer Rend;
    public bool IsDummy;

    // Packet Constructor
    public Packet() {
        // Setting an individual id for each packet
        GlobalPacketId++;
        Id = GlobalPacketId;
        InQueue = false;
        IsDummy = false;
        // Debug.Log("Creating packet " + id);
    }
    
    // Return Packet ID
    public int GetId() {
        return Id;
    }
    
    // Start is called before the first frame update
    void Start()
    {
        // Assigning random color to new packet game object
        Rend = gameObject.GetComponent<Renderer>();
        Rend.material.color = new Color(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f));
    }

    // Update is called once per frame
    void Update()
    {
        // A Dummy packet is not displayed on the screen (used to insert bubbles)
        if (IsDummy) {
            Rend.material.color = Color.white;
        }
        // If packet isn't in a queue, packet is moving right
        if (InQueue == false) {
            transform.Translate(Vector * MoveSpeed * Time.deltaTime);
        }
    }
}
