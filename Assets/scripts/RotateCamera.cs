using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity;
public class RotateCamera : MonoBehaviour
{
    [SerializeField] private float speed = 10f;
    private float Horizontalimput;

    [SerializeField] private GameObject player;

    private void Start()
    {
        player = GameObject.Find("Player");
    }




    void Update()
    {
        Horizontalimput = Input.GetAxis("Horizontal");
        transform.Rotate(Vector3.up, speed * Time.deltaTime * Horizontalimput);

        transform.position = new Vector3(player.transform.position.x,player.transform.position.y + 3, player.transform.position.z);
    }
}
