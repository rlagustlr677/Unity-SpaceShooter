using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour {

    private Rigidbody rig;
    public float speed;

    void Start()
    {
        rig = GetComponent<Rigidbody>();
        rig.velocity = transform.forward*speed;
    }

}
