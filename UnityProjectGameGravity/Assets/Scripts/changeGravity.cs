using UnityEngine;
using System.Collections;

public class changeGravity : MonoBehaviour {

    public int valueGravity = 1;
    public float valueJump = 700f;
    public float valueForce = 0f;
    public bool flipTop = false;
    public bool flipBot = false;
    public float rotationZ = 0;
    public float valueMass = 0.8f;
    public float valueFallForce = 0f;

    void OnTriggerEnter2D(Collider2D col)
    {
        // If the player hits the trigger...
        if (col.gameObject.tag == "Player")
        {
            // Values
            GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody2D>().gravityScale = valueGravity;
            GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerControl>().jumpForce = valueJump;
            GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerControl>().valueForceLR = valueForce;
            GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody2D>().mass = valueMass;

            // Ajout force
            GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody2D>().rigidbody2D.AddForce(new Vector2(0f, valueFallForce));

            // Bool
            GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerControl>().toTop = flipTop;
            GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerControl>().toBot = flipBot;
        }
        else
        {
            //
        }
    }
    
}
