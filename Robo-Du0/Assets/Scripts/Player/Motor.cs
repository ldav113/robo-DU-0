using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Motor : MonoBehaviour
{
    public float speed;
    public float rotatespeed;
    public Animator animator;

    public GameObject turret;



    void FixedUpdate()
    {
        float hVector = Input.GetAxis("Horizontal");
        float vVector = Input.GetAxis("Vertical");

        this.transform.Translate(hVector * speed * Time.deltaTime, 0f, 0f);
        this.transform.Translate(0f, vVector * speed * Time.deltaTime, 0f);


    }
    void Update()
    {
        TurretRotation();
        if (Input.GetButton("down") == true)
        {
            animator.SetBool("IsMovingSouth", true);
        }
        if (Input.GetButton("up") == true)
        {
            animator.SetBool("IsMovingNorth", true);
        }
        if (Input.GetButton("left") == true)
        {
            animator.SetBool("IsMovingEast", true);
        }




    }

    void TurretRotation()
    {
        //Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        Vector3 direction = new Vector3(Input.mousePosition.x - turret.transform.position.x, Input.mousePosition.y - turret.transform.position.y);

        turret.transform.up = direction;
    }

}