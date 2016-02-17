using UnityEngine;
using System.Collections;

public class WeaponController : MonoBehaviour
{
	public GameObject shot;
	public Transform shotSpawn;
	public float fireRate;
	public float delay;

	private AudioSource audioSource;

	void Start()
	{
		audioSource = GetComponent<AudioSource>();
		InvokeRepeating("fire",delay,fireRate);
	}

	void fire()
	{
		Instantiate(shot,shotSpawn.position,shotSpawn.rotation);
		audioSource.Play();
	}
}
