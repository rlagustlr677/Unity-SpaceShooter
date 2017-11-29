using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomRotate : MonoBehaviour {
    private Rigidbody rig;
    public float tumble;

    void Start()
    {
        rig = GetComponent<Rigidbody>();
        rig.angularVelocity = Random.insideUnitSphere*tumble;

    }
}
