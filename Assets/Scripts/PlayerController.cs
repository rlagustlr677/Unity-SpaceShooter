using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class Boundary
{
    public float xMin, xMax, zMin, zMax;
}

public class PlayerController : MonoBehaviour {

    private Rigidbody rig;
    public float speed;
    public Boundary boundary;
    public float tilt;
    public GameObject shot;
    public Transform shotSpawn;
    private AudioSource aud;

    public float fireRate;
    private float nextFire;

    void Start() //이부분 보고한것임!!
    {
        rig = GetComponent<Rigidbody>();
        aud= GetComponent<AudioSource>();
    }
    void Update()
    {
        if (Input.GetButton("Fire1") && Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            //GameObject clone = 
            Instantiate(shot, shotSpawn.position, shotSpawn.rotation);// as GameObject;
            aud.Play();
        }
    }
    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movemonet=new Vector3(moveHorizontal, 0.0f, moveVertical);
        rig.velocity = movemonet*speed;

        rig.position = new Vector3
            (
            Mathf.Clamp(rig.position.x,boundary.xMin, boundary.xMax),
            0.0f,
            Mathf.Clamp(rig.position.z, boundary.zMin, boundary.zMax)
            );


        rig.rotation = Quaternion.Euler(0.0f,0.0f,rig.velocity.x * -tilt);   
    }
}
