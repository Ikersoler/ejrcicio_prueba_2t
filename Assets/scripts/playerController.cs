using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity;

public class playerController : MonoBehaviour
{
    private Rigidbody playerRigidbody;
    [SerializeField] private float speed = 30f;
    private float forwardInput;

    

    [SerializeField] private GameObject focalPointGameObject;

    public bool hasPowerup;
    [SerializeField] private float powerupForce = 10f;

    [SerializeField] private GameObject[] powerupIndicators;

   


    

    private void Awake()
    {
        playerRigidbody = GetComponent<Rigidbody>();
        hasPowerup = false;
        

    }



   
   

    private void Update()
    {

        



        forwardInput = Input.GetAxis("Vertical");
        playerRigidbody.AddForce(focalPointGameObject.transform.forward * speed * forwardInput);


        


    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Enemy") && hasPowerup)
        {
            Rigidbody enemyRigidbody = other.gameObject.
                 GetComponent<Rigidbody>();

            Vector3 direction = (other.transform.position -
                                 transform.position).normalized;

            enemyRigidbody.AddForce(direction * powerupForce,
                ForceMode.Impulse);

        }
    }

 

   


   
}
