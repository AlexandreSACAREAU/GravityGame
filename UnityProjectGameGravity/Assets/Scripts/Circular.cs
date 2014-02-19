using UnityEngine;
using System.Collections;

public class Circular : MonoBehaviour {
    public int rotate = 7;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        //GameObject.FindGameObjectWithTag("Circular").GetComponent<Transform>().Rotate(0, 0, 7);
        this.GetComponent<Transform>().Rotate(0, 0, rotate);
	}
}
