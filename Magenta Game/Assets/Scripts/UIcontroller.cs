using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UIcontroller : MonoBehaviour
{
   public static UIcontroller instance; 

    public Image Heart_Full1,Heart_Full2,Heart_Full3,Heart_Full4,Heart_Backround;        
    public Sprite heart_Full,heart_Empty;
  
   public void Awake()
   {
       instance = this; 
   } 

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateHealthDisplay()
    {
        switch(PlayerHealth.instance.currentHealth)
        {
            case 4:
                Heart_Full1.sprite = heart_Full; 
                Heart_Full2.sprite = heart_Full; 
                Heart_Full3.sprite = heart_Full; 
                Heart_Full4.sprite = heart_Full; 

                break;

            case 3:
                Heart_Full1.sprite = heart_Full; 
                Heart_Full2.sprite = heart_Full; 
                Heart_Full3.sprite = heart_Full; 
                Heart_Full4.sprite = heart_Empty; 

                break;
                
            case 2:
                Heart_Full1.sprite = heart_Full; 
                Heart_Full2.sprite = heart_Full; 
                Heart_Full3.sprite = heart_Empty; 
                Heart_Full4.sprite = heart_Empty; 

                break;

            case 1:
                Heart_Full1.sprite = heart_Full; 
                Heart_Full2.sprite = heart_Empty; 
                Heart_Full3.sprite = heart_Empty; 
                Heart_Full4.sprite = heart_Empty; 

                break;
                   
            case 0:
                Heart_Full1.sprite = heart_Empty; 
                Heart_Full2.sprite = heart_Empty; 
                Heart_Full3.sprite = heart_Empty; 
                Heart_Full4.sprite = heart_Empty; 

                break;

            default:
                Heart_Full1.sprite = heart_Empty; 
                Heart_Full2.sprite = heart_Empty; 
                Heart_Full3.sprite = heart_Empty; 
                Heart_Full4.sprite = heart_Empty; 

                break;

        }
    }
}
