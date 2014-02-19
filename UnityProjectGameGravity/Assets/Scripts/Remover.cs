using UnityEngine;
using System.Collections;

public class Remover : MonoBehaviour
{
	public GameObject splash;
    public bool animation;
    public AudioClip[] cry;
    public Vector3 positionBase = new Vector3(669, 6.5f, 0);
    //private int cryIndex = 0;

	void OnTriggerEnter2D(Collider2D col)
	{
        positionBase = new Vector3(669, 6.5f, 0);
		// If the player hits the trigger...
        if (col.gameObject.tag == "Player")
        {
            // .. stop the camera tracking the player
            GameObject.FindGameObjectWithTag("MainCamera").GetComponent<CameraFollow>().enabled = false;

            int i = Random.Range(0, cry.Length);
            AudioSource.PlayClipAtPoint(cry[i], transform.position);


            // ... instantiate the splash where the player falls in.
            if (animation)
                Instantiate(splash, col.transform.position, transform.rotation);
            // ... destroy the player.
            Destroy(col.gameObject);
            // ... reload the level.
            StartCoroutine("ReloadGame");

            /* Initialisation Grvaity
            GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody2D>().gravityScale = 1;
            GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerControl>().jumpForce = 700;
            GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerControl>().valueForceLR = 0;
            GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody2D>().mass = 0.8f;
            GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerControl>().toTop = false;
            GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerControl>().toBot = false;*/

            // Position
            //GameObject.FindGameObjectWithTag("Player").transform.localPosition = positionBase;
            //GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody2D>().velocity = new Vector3(0,0,0);
        }/*
        else
        {
            // ... instantiate the splash where the enemy falls in.
            if (animation)
                Instantiate(splash, col.transform.position, transform.rotation);

            // Destroy the enemy.
            Destroy(col.gameObject);
        }*/
	}

	IEnumerator ReloadGame()
	{			
		// ... pause briefly
		yield return new WaitForSeconds(4);
		// ... and then reload the level.
		Application.LoadLevel(Application.loadedLevel);
	}
}

