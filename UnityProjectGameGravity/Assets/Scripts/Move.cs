using UnityEngine;
using System.Collections;

public class Move : MonoBehaviour {
    private int i = 0;
    public float valueX = 0.4f;
    public float valueY = 0f;
    public int max = 30;
    public bool test = true;
    private bool grounded;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        this.GetComponent<Transform>().Translate(valueX, valueY, 0, Space.World);
        i++;
        if (i > max)
        {
            valueX = valueX*-1;
            valueY = valueY * -1;
            i = 0;
        }

        if (test && Physics2D.Linecast(GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>().position, GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>().Find("groundCheck").position, 1 << LayerMask.NameToLayer("Move")))
            GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>().Translate(valueX, valueY, 0, Space.World);
	}

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            //GameObject go = col.gameObject;
            grounded = Physics2D.Linecast(GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>().position, GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>().Find("groundCheck").position, 1 << LayerMask.NameToLayer("Move"));

            if (grounded)
                GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>().Translate(valueX, valueY, 0, Space.World);
        }
    }
}
