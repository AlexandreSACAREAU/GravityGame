using UnityEngine;
using System.Collections;

public class Scrolling : MonoBehaviour
{
    private int i = 0;
    public float valueX = -0.4f;
    public float valueY = 0f;
    public int max = 100;
    public bool reset = true;
    private bool grounded;
    private Vector3 positionBase;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (i > max && reset)
        {
            this.transform.position = positionBase;
            i = 0;
        }
        if (i == 0)
        {
            positionBase = this.transform.position;
        }
        this.GetComponent<Transform>().Translate(valueX, valueY, 0, Space.World);
        i++;
    }
}