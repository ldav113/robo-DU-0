using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    private Vector2 target;
    public float speed;
    private Shooting shot;
    // private float timeBtwProjectile;

    void Start()

    {

        target = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        //target = Camera.main.ScreenToWorldPoint(new Vector2(Input.mousePosition.x, Input.mousePosition.y) ); // its not work for mouse postion
       // timeBtwProjectile = Time.deltaTime;
    }

     void Update() 
    {


        // target = Input.mousePosition;
        transform.position = Vector2.MoveTowards(transform.position, target, speed * Time.deltaTime);


        if (Vector2.Distance(transform.position, target) < 0.2f)
        {

            Destroy(gameObject);  // projectile disappers

        }

       /* if (timeBtwProjectile < 10)
        {

            Destroy(gameObject);  // projectile disappers

        }
        */       
    }
}
