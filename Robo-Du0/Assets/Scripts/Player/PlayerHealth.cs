using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
   
    public int health;
    public int numOfHearts;

    public Image[] hearts;
    public Sprite fullHealth;
    public Sprite emptyHealth;



    // From DamageHandler

    public float receiveDamage = 1;
    public float invulnPeriod = 0;

    float invulnTimer = 0;
    int correctLayer;

    SpriteRenderer spriteRend;

    void Start()
    {
        correctLayer = gameObject.layer;

        // NOTE!  This only get the renderer on the parent object.
        // In other words, it doesn't work for children. I.E. "enemy01"
        spriteRend = GetComponent<SpriteRenderer>();

        if (spriteRend == null)
        {
            spriteRend = transform.GetComponentInChildren<SpriteRenderer>();

            if (spriteRend == null)
            {
                Debug.LogError("Object '" + gameObject.name + "' has no sprite renderer.");
            }
        }
    }

    void OnTriggerEnter2D()
    {
        if (receiveDamage == 1)
        {
            health--;

            if (invulnPeriod > 0)
            {
                invulnTimer = invulnPeriod;
                gameObject.layer = 10;
            }
        }
    }






    private void Update()
    {

       
        // from DamageHandler
        if(invulnTimer > 0) {
            invulnTimer -= Time.deltaTime;

            if(invulnTimer <= 0) {
                gameObject.layer = correctLayer;
                if(spriteRend != null) {
                    spriteRend.enabled = true;
                }
            }
            else {
                if(spriteRend != null) {
                    spriteRend.enabled = !spriteRend.enabled;
                }
            }
        }

        if(health <= 0) {
            Die();
        }


        // to here


      


        if (health> numOfHearts)
        {
            health = numOfHearts;
        }

        for (int i = 0; i < hearts.Length; i++)
        {

            if (i< health)
            {
                hearts[i].sprite = fullHealth;
            }
            else
            {
                hearts[i].sprite = emptyHealth;
            }


            if (i< numOfHearts)
            {
                hearts[i].enabled = true;
            }
            else
            {
                hearts[i].enabled = false;
            }
        }

    }

    // From DamageHandler

    void Die()
    {
        Destroy(gameObject);
    }




}
