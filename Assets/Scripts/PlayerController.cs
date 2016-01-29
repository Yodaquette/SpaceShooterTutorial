using UnityEngine;
using System.Collections;

[System.Serializable]
public class Boundary
{
	// Set the game window boundary coordinates
	public float xMin,xMax,zMin,zMax;
}

public class PlayerController : MonoBehaviour
{
	public Boundary boundary;

	private Rigidbody rb = null;
	private float speed = 10; // Make movement faster 
	private float tilt = 3; // Make ship tilt into X movement

	public float fireRate;
	public GameObject shot;
	public Transform shotSpawn;
	private float nextFire;


	void Start()
	{
		rb = GetComponent<Rigidbody>();
	}

	void Update()
	{
		// Create the bolt for the spacecraft cannon
		if (Input.GetButton("Fire1") && Time.time > nextFire)
		{
			nextFire = Time.time + fireRate;
			//GameObject clone =
			Instantiate(shot, shotSpawn.position, shotSpawn.rotation);// as GameObject;
		}
	}

	void FixedUpdate()
	{
		// Get player input for horizontal and vertical movement
		float moveHorizontal = Input.GetAxis("Horizontal"), moveVertical = Input.GetAxis("Vertical");

		// Set vector movement to the X, Y, and Z coordinates of the object to move
		Vector3 movement = new Vector3(moveHorizontal,0.0f,moveVertical);

		// Assign the movement to the RigidBody object
		rb.velocity = movement * speed;

		// Prevent player from leaving the game window
		rb.position = new Vector3
		(
			Mathf.Clamp(rb.position.x,boundary.xMin,boundary.xMax),
			0.0f,
			Mathf.Clamp(rb.position.z,boundary.zMin,boundary.zMax)
		);

		rb.rotation = Quaternion.Euler(0.0f,0.0f,rb.velocity.x * -tilt);
	}
}