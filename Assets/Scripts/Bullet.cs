﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

    public float speed { get; set; }
    public float damage { get; set; }
    public SoldierController owner { get; set; }

    private int soldiersLayer;
    private int wallsLayer;
    private LayerMask layerMask;

	// Use this for initialization
	void Start () {
        soldiersLayer = LayerMask.NameToLayer("Soldiers");
        wallsLayer = LayerMask.NameToLayer("Walls");
        layerMask = LayerMask.GetMask("Soldiers", "Walls");
	}
	
	// Update is called once per frame
	void Update () {
        transform.position += transform.forward * speed * Time.deltaTime;
	}

    private void OnTriggerEnter(Collider other)
    {
        if ((layerMask.value & (1 << other.gameObject.layer)) == 0)
        {
            return;
        }
        if (other.gameObject.layer == soldiersLayer)
        {
            OnCollisionWithSoldier(other.gameObject);
        }
        if (other.gameObject.layer == wallsLayer)
        {
            OnCollisionWithWall(other.gameObject);
        }
    }

    private void OnCollisionWithWall(GameObject wall)
    {
        Destroy(gameObject);
    }

    private void OnCollisionWithSoldier(GameObject soldier)
    {
        SoldierController sc = soldier.GetComponent<SoldierController>();
        sc.OnHit(damage);
        Destroy(gameObject);
    }

}
