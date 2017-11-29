using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByContact : MonoBehaviour {

    public GameObject explosion;
    public GameObject playerExplosion;
    public int scoreValue;
    private Gamecontroller gameController;

    void Start()
    {
        GameObject gamceControllerObject = GameObject.FindWithTag("GameController");
        if(gameController==null)
        {
            gameController = gamceControllerObject.GetComponent<Gamecontroller>();
        }
        /*if (gameController != null)
        {
            Debug.Log("Connot find 'Gamecontroller' script");
        }*/
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Boundary")
        {
            return;
        }
        Instantiate(explosion, transform.position, transform.rotation);
        if (other.tag=="Player")
        {
            Instantiate(playerExplosion, other.transform.position, other.transform.rotation);
            gameController.GameOver();
        }

        gameController.AddScore(scoreValue);
        Destroy(other.gameObject);
        Destroy(gameObject);


    }
}
