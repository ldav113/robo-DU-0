using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Motor : MonoBehaviour
{
    public float speed;
    public float rotatespeed;

    public GameObject turret;



    void FixedUpdate()
    {
        float moveVector = Input.GetAxis("Horizontal");
        float rotateVector = Input.GetAxis("Vertical");

        this.transform.Translate(moveVector * speed * Time.deltaTime, 0f, 0f);
        this.transform.Translate(0f, rotateVector * speed * Time.deltaTime, 0f);


    }
    void Update()
    {
        TurretRotation();





    }

    void TurretRotation()
    {
        //Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        Vector3 direction = new Vector3(Input.mousePosition.x - turret.transform.position.x, Input.mousePosition.y - turret.transform.position.y);

        turret.transform.up = direction;
    }

}