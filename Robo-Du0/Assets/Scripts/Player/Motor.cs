using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Motor : MonoBehaviour
{
    public float speed;
    public float rotatespeed;
    public Animator anim;

    public GameObject turret;

    void Start()
    {
        anim = GetComponent<Animator> ();
    }

    // Player move in X and Y direction
    void FixedUpdate()
    {
        float hVector = Input.GetAxis("Horizontal");
        float vVector = Input.GetAxis("Vertical");

        this.transform.Translate(hVector * speed * Time.deltaTime, 0f, 0f);
        this.transform.Translate(0f, vVector * speed * Time.deltaTime, 0f);

    }

    // update is called once per frame
    void Update()
    {
        TurretRotation();

        // State changes from walking south-west to standing south-west
        if ((Input.GetKeyDown(KeyCode.S) && Input.GetKeyDown(KeyCode.A)) || (Input.GetKeyDown(KeyCode.DownArrow) && Input.GetKeyDown(KeyCode.LeftArrow)))
        {
            anim.SetBool("IsMovingSouthWest", true);
        }
        else if ((Input.GetKeyUp(KeyCode.S) && Input.GetKeyUp(KeyCode.A)) || (Input.GetKeyUp(KeyCode.DownArrow) && Input.GetKeyUp(KeyCode.LeftArrow)))
        {
            anim.SetBool("IsMovingSouthWest", false);
        }

        // State changes from walking south-east to standing south-east
        else if ((Input.GetKeyDown(KeyCode.S) && Input.GetKeyDown(KeyCode.D)) || (Input.GetKeyDown(KeyCode.DownArrow) && Input.GetKeyDown(KeyCode.RightArrow)))
        {
            anim.SetBool("IsMovingSouthEast", true);
        }
        else if ((Input.GetKeyUp(KeyCode.S) && Input.GetKeyUp(KeyCode.D)) || (Input.GetKeyUp(KeyCode.DownArrow) && Input.GetKeyUp(KeyCode.RightArrow)))
        {
            anim.SetBool("IsMovingSouthEast", false);
        }

        // State changes from walking north-east to standing north-east
        else if ((Input.GetKeyDown(KeyCode.W) && Input.GetKeyDown(KeyCode.D)) || (Input.GetKeyDown(KeyCode.UpArrow) && Input.GetKeyDown(KeyCode.RightArrow)))
        {
            anim.SetBool("IsMovingNorthEast", true);
        }
        else if ((Input.GetKeyUp(KeyCode.W) && Input.GetKeyUp(KeyCode.D)) || (Input.GetKeyUp(KeyCode.UpArrow) && Input.GetKeyUp(KeyCode.RightArrow)))
        {
            anim.SetBool("IsMovingNorthEast", false);
        }

        // State changes from walking north-west to standing north-west
        else if ((Input.GetKeyDown(KeyCode.A) && Input.GetKeyDown(KeyCode.W)) || (Input.GetKeyDown(KeyCode.UpArrow) && Input.GetKeyDown(KeyCode.LeftArrow)))
        {
            anim.SetBool("IsMovingNorthWest", true);
        }
        else if ((Input.GetKeyUp(KeyCode.A) && Input.GetKeyUp(KeyCode.W)) || (Input.GetKeyUp(KeyCode.UpArrow) && Input.GetKeyUp(KeyCode.LeftArrow)))
        {
            anim.SetBool("IsMovingNorthWest", false);
        }

        else 
        {
            // State changes from walking south to standing south
            if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
            {
                anim.SetBool("IsMovingSouth", true);
            }
            if (Input.GetKeyUp(KeyCode.S) || Input.GetKeyUp(KeyCode.DownArrow))
            {
                anim.SetBool("IsMovingSouth", false);
            }

            // State changes from walking north to standing north
            if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
            {
                anim.SetBool("IsMovingNorth", true);
            }
            if (Input.GetKeyUp(KeyCode.W) || Input.GetKeyUp(KeyCode.UpArrow))
            {
                anim.SetBool("IsMovingNorth", false);
            }

            // State changes from walking west to standing west
            if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
            {
                anim.SetBool("IsMovingWest", true);
            }
            if (Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.LeftArrow))
            {
                anim.SetBool("IsMovingWest", false);
            }

            // State changes from walking east to standing east
            if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
            {
                anim.SetBool("IsMovingEast", true);
            }
            if (Input.GetKeyUp(KeyCode.D) || Input.GetKeyUp(KeyCode.RightArrow))
            {
                anim.SetBool("IsMovingEast", false);
            }

        }


        // if no button pressed, back to default state
        /*if ((Input.GetKeyUp(KeyCode.A) && Input.GetKeyUp(KeyCode.W) && Input.GetKeyUp(KeyCode.S) && Input.GetKeyUp(KeyCode.D)) || (Input.GetKeyUp(KeyCode.UpArrow) && Input.GetKeyUp(KeyCode.LeftArrow) && Input.GetKeyUp(KeyCode.DownArrow) && Input.GetKeyUp(KeyCode.RightArrow)))
        {
            anim.SetBool("IsMovingSouth", false);
        }*/

    }

    void TurretRotation()
    {
        //Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        Vector3 direction = new Vector3(Input.mousePosition.x - turret.transform.position.x, Input.mousePosition.y - turret.transform.position.y);

        turret.transform.up = direction;
    }

}