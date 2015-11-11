﻿using UnityEngine;
using System.Collections;

public class DartAmmoBoxScript : MonoBehaviour {

	// Use this for initialization
	void OnTriggerEnter (Collider other)
	{
		other.GetComponentInChildren<DartGun>().ammo = 3;
		Destroy(gameObject);
	}
}
