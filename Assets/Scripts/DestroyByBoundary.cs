using UnityEngine;
using System.Collections;

public class DestroyByBoundary : MonoBehaviour
{
	// Destroy any object that leaves the Boundary volume
	void OnTriggerExit(Collider other)
	{
		Destroy(other.gameObject);
	}
}