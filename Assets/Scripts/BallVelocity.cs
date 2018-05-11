using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallVelocity : MonoBehaviour {

    [SerializeField] Vector2 velocity;


    private void Start()
    {
        Invoke("StartCollisions", 2f);
    }

    
    private void StartCollisions()
    {
        GetComponent<Rigidbody2D>().velocity = velocity;
    }
}
