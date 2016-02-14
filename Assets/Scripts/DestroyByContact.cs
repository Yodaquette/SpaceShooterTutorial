using UnityEngine;
using System.Collections;

public class DestroyByContact : MonoBehaviour
{
	// Add reference to explosion for the asteroid and player
	public GameObject explosion;
	public GameObject playerExplosion;

	// Reference to GameController
	private GameController gc;

	// The score value for an asteroid
	public int scoreValue;

	void Start()
	{
		GameObject gameControllerObject = GameObject.FindWithTag("GameController");

		if(gameControllerObject != null)
		{
 			gc = gameControllerObject.GetComponent<GameController>();
		}

		// Log error, if game controller instance is not found
		if(gc == null)
		{
			Debug.Log("Cannot find 'GameController' script.");
		}
	}

	void OnTriggerEnter(Collider other)
	{
		// Debug was used to determine what game object was destroying the asteroid
		//Debug.Log(other.name);

		// Return control to the caller
		if(other.tag == "Boundary")
		{
			return;
		}

		// Show explosion at the position and with the rotation of the asteroid
		Instantiate(explosion,transform.position,transform.rotation);

		// Show player explosion if the player is detected
		// End game when player is destroyed
		if(other.tag == "Player")
		{
			Instantiate(playerExplosion,other.transform.position,other.transform.rotation);

			gc.GameOver();
		}

		// Increase score
		gc.addScore(scoreValue);

		// Destroy the asteroid game object
		Destroy(other.gameObject);
		Destroy(gameObject);
	}
}
