using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public static PlayerHealth instance; 
    
    public float invincibleLength; 
    private float invincibleCounter;
    
private SpriteRenderer theSR;



    public int currentHealth, maxHealth;

    private void Awake()
    {
        instance = this;
    }


void Start()
    {
        currentHealth = maxHealth;
        theSR = GetComponent<SpriteRenderer>();
    }

    
    void Update()
    {
        if(invincibleCounter > 0)
        {
            invincibleCounter -= Time.deltaTime;
            if(invincibleCounter <= 0)
            {
                theSR.color = new Color(theSR.color.r, theSR.color.g, theSR.color.b, 1f);   
            }
        }

    }

    public void DealDamage()
    {
        if(invincibleCounter <= 0)
    {    
        currentHealth --; 

        if(currentHealth <= 0)
        {
            currentHealth = 0;
            gameObject.SetActive(false);
        }else
        {
            invincibleCounter = invincibleLength;
            
            theSR.color = new Color(theSR.color.r, theSR.color.g, theSR.color.b, .6f);

            PlayerController.instance.knockBack(); 
            }

        UIcontroller.instance.UpdateHealthDisplay();
        }
    }
}