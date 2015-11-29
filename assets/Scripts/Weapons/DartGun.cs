﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using PhotonHashtable = ExitGames.Client.Photon.Hashtable;

public class DartGun : WeaponBase {


	// DL - This script is responsible for: 1) Graphical Effects of Shooting 2) Physics of shooting 3) Impacts, etc.

	// Animator anim;
	[SerializeField] string dartPrefab;
	[SerializeField] bool shooting = false;
	[SerializeField] bool loaded = true;
	[SerializeField] float shotTime;
	public float loadTime = 2;	
	public float ammo = 3;
	public GameObject ammoCount;



	// Use this for initialization
	void Start () 
	{
		//anim = GetComponentInChildren<Animator> ();
		ammoCount = this.transform.parent.parent.transform.Find("VitalsCanvas/VitalsBar/AmmoCount").gameObject;
	}
	
	// Update is called once per frame
	void Update (){
		//Shoot if we hit fire, aren't running, have ammo, and round is loaded
		if(Input.GetButtonDown ("Fire1") && !Input.GetKey(KeyCode.LeftShift)){
			if(loaded == true && ammo > 0){
				SoundCenter.instance.PlayClipOn(
					SoundCenter.instance.dartShoot,transform.position);
				shooting = true;
				shotTime = Time.time;
				Debug.Log ("It's firing");
			} else {
				SoundCenter.instance.PlayClipOn(
					SoundCenter.instance.playerNoAmmoTriedToFire,transform.position);
			}
		}

		//Reload if the cooldown has happened
		if(loaded == false && Time.time >= (shotTime + loadTime)){
			loaded = true;
		}

		if (shooting){
			//stop shooting and unload
			shooting = false;
			loaded = false;
			ammo -= 1;
			//instantiate the dart
			GameObject dartInstance;
			dartInstance = PhotonNetwork.Instantiate(dartPrefab, transform.position, transform.rotation, 0) as GameObject;
		}

		
	}

	void FixedUpdate ()
	{
		ammoCount.GetComponent<Text>().text = ammo.ToString();
	}



}