using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//Kinematic pour faire bouger par script et pas par force
// is trigger pour savoir si il y a collision et non pas arreter si collision

public class Player : MonoBehaviour {

    public float moveSpeed = 600f;
    float movement = 0f;
	
	// Update is called once per frame
	void Update () {
        //getaxisRaw car pas besoin de smoothing
        movement = Input.GetAxisRaw("Horizontal"); //Horizontal q et d 
	}

    private void FixedUpdate()
    {
        //RotateAround the center, forward = axe z, - pour inverser les touches
        transform.RotateAround(Vector3.zero, Vector3.forward, movement * Time.fixedDeltaTime * -moveSpeed);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //reload la scene active
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
