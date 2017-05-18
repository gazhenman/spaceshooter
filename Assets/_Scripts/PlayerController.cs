﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Boundary
{
    public float xMin, xMax, zMin, zMax;
}
public class PlayerController : MonoBehaviour
{
    public float titl;
    public float speed;
    
    private Rigidbody rb;
    public Boundary bounadary;

    public GameObject shot;
    public Transform shotSpawn;

    public float fireRate;
    private float nextFire;
    private AudioSource audioSource;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
    } 
     void Update() {
        if(Input.GetButton ("Fire1")&&Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            Instantiate(shot, shotSpawn.position, shotSpawn.rotation);
            audioSource.Play();
        }
    }

    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
        rb.velocity = movement * speed;
        
            rb.position = new Vector3( Mathf.Clamp(rb.position.x, bounadary.xMin, bounadary.xMax),0.0f,Mathf.Clamp(rb.position.z, bounadary.zMin, bounadary.zMax));
            rb.rotation = Quaternion.Euler(0.0f, 0.0f, rb.velocity.x * -titl);
        }
    }