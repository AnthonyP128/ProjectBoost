using System;using System.Collections;using System.Collections.Generic;using UnityEngine;public class Rocket : MonoBehaviour{    [SerializeField]float rcsThrust = 100f;    [SerializeField] float thrustSpeed = 100f;    Rigidbody rigidBody;    AudioSource engineNoise;    // Start is called before the first frame update    void Start()    {        rigidBody = GetComponent<Rigidbody>();        engineNoise = GetComponent<AudioSource>();    }    // Update is called once per frame    void Update()    {        Thrust();        Rotate();    }    void OnCollisionEnter(Collision collision)
    {
        switch (collision.gameObject.tag)
        {
            case "Friendly":
                print("Friendly");
                break;
            case "Fuel":
                print("Fuel");
                break;
            default:
                print("Dead");
                //kill the player
                break;
        }
    }    private void Thrust()    {        if (Input.GetKey(KeyCode.Space)) //can thrust while rotating        {            rigidBody.AddRelativeForce(Vector3.up * thrustSpeed);            if (!engineNoise.isPlaying)            {                engineNoise.Play();            }        }        else        {            engineNoise.Stop();        }    }    private void Rotate()    {        rigidBody.freezeRotation = true; //manual control of rotation        float rotationThisFrame = rcsThrust * Time.deltaTime;        if (Input.GetKey(KeyCode.A))        {            transform.Rotate(Vector3.forward * rotationThisFrame);        }        else if (Input.GetKey(KeyCode.D))        {            transform.Rotate(-Vector3.forward * rotationThisFrame);        }        rigidBody.freezeRotation = false; //resume physics control    }}