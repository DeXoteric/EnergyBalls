using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndSparks : MonoBehaviour {

    private void Start()
    {
        Invoke("DestroySparksInstance", 3f);
    }

    private void DestroySparksInstance()
    {
        Destroy(gameObject);
    }
}
