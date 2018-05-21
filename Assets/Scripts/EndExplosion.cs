using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndExplosion : MonoBehaviour {


    private void Start()
    {
        Invoke("DestroyExplosionInstance", 0.5f);
    }

    private void DestroyExplosionInstance () {
        Destroy(gameObject);
	}
}
