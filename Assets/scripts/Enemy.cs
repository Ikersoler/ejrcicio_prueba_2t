using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity;
public class Enemy : MonoBehaviour
{
    [SerializeField] private float speed = 1.5f;

    private Rigidbody enemyRigidbody;

    private GameObject playerGoal;

    private float lowerLimit = -3f;

    private SpawnManager spawnManager;

    private void Awake()
    {
        enemyRigidbody = GetComponent<Rigidbody>();
    }

    private void Start()
    {
        playerGoal = GameObject.Find("player");


        spawnManager = FindObjectOfType<SpawnManager>();



    }

    private void Update()
    {
        GoToPlayerGoal();

        if (transform.position.y < lowerLimit)
        {
            spawnManager.EnemyDestroy();
            Destroy(gameObject);
        }
    }

    private void GoToPlayerGoal()
    {
        Vector3 direction = playerGoal.transform.position - transform.position;

        direction = direction.normalized;

        enemyRigidbody.AddForce(direction * speed);
    }
}
