using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Player : MonoBehaviour
{
    public float speed;

    public int health = 5;
    public GameObject turret;


    private Rigidbody2D rb;

    private Vector2 moveVelocity;

    private void Start()
    {
        rb = GetComponent< Rigidbody2D>();
       rb.constraints = RigidbodyConstraints2D.FreezeRotation;
    }

    void Update()
    {

        if (health == 0)
        {

            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

        Vector2 moveInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxis("Vertical"));
        moveVelocity = moveInput.normalized * speed;

        //if  (health == 0) { Destroy(this); }
        TurretRotation();



    }

     void FixedUpdate()
    {
        rb.MovePosition(rb.position + (moveVelocity * Time.fixedDeltaTime));
        //if (health <= 0)
        //{

        //    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        //}

    }

    void TurretRotation()
    {
        Vector3 mousePosition = Input.mousePosition;
        mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);

        Vector2 direction = new Vector2(mousePosition.x - turret.transform.position.x, mousePosition.y - turret.transform.position.y);

        turret.transform.up = direction;
    }



}
