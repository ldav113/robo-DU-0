using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossEnemy : MonoBehaviour
{
    public float speed;
    public Transform playerPos;
    public Animator animator;
    private  Player player;
    //private Transform healthBar;
    private Shooting shot;
    //public int health = 10;


    public float fireRate;

    float timeUntilFire;

    public Transform firePoint;
    public GameObject bullet;



    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        playerPos = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
      //  healthBar = GameObject.FindGameObjectWithTag("HealthBar").GetComponent<Transform>();
    }




     void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, playerPos.position,speed*Time.deltaTime);

        timeUntilFire = Time.time + 1 / fireRate;
        Shoot();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {

          //   player losing health;

            player.health-= 1;

            Debug.Log(player.health);
            //Destroy(gameObject);
            if (player.health == 0) 
           { Destroy(player); }  // kills the player 


        }


        if (other.CompareTag("Projectile"))  // Kills enemies
        {
            Destroy(other.gameObject);
            Destroy(gameObject);
          

        }

    }

    void Shoot()
    {
        Instantiate(bullet, firePoint.position, firePoint.rotation);
    }
}
