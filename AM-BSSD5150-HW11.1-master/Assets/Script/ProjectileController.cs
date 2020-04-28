using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ProjectileController : MonoBehaviour
{
    private int speed = 3;
    private int NoOfRicochets = 0;
    private int NoOfTress = 3;
    private int NoOfDestroyedTress = 0;
    private int NoOfenemies = 0;
    
    void Start()
    { GetComponent<Rigidbody2D>().velocity = transform.up * speed; }

    private void OnBecameInvisible()
    {
        Destroy(this.gameObject);
   
    }

    
    
    void OnEnable() {
        GameObject[] otherObjects = GameObject.FindGameObjectsWithTag("bullets");

        foreach (GameObject obj in otherObjects) {
            Physics2D.IgnoreCollision(obj.GetComponent<Collider2D>(), GetComponent<Collider2D>()); 
        }
        
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.tag == "enemy")
        {
            Destroy(GameObject.FindWithTag("enemy"));

        }

        if (collision.gameObject.tag == "enemyo")
        {
            Destroy(GameObject.FindWithTag("enemyo"));
            
        }

        if (collision.gameObject.tag == "enemyt")
        {
            Destroy(GameObject.FindWithTag("enemyt"));
           
        }

        if (collision.gameObject.tag == "enemyth")
        {
            Destroy(GameObject.FindWithTag("enemyth"));
          
        }

        if (collision.gameObject.tag == "wall")
        {
            NoOfDestroyedTress += 1;
            transform.up = Vector2.Reflect(transform.up, collision.contacts[0].normal);
            GetComponent<Rigidbody2D>().velocity = transform.up * speed;
            speed += 1;
            NoOfRicochets = NoOfRicochets + 1;
            
            //Destroy tress after 3 hits
            if (NoOfRicochets == 3)
            {
                Destroy(GameObject.FindWithTag("bullets"));
               
            }
            
          

        }
    }

}
    

    

