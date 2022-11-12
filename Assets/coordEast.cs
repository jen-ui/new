using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class coordEast : MonoBehaviour
{
  public Image MyImage;
    private float spriteHeight;
    private float spritewidth;
                
    

    void Update()
    {
        if(MyImage.GetComponent<Image>().sprite){
            spriteHeight=MyImage.GetComponent<Image>().sprite.rect.height;
            spritewidth=MyImage.GetComponent<Image>().sprite.rect.width;
            float upperBound=transform.position.y+spriteHeight/2;
            float leftBound=transform.position.x-spritewidth/2;
        
            if (Input.GetMouseButtonDown(1)){
            
                Debug.Log(((int)(Input.mousePosition.x-leftBound))+","+((int)(upperBound-Input.mousePosition.y)));
                //writer.WriteLine(((int)(Input.mousePosition.x-leftBound))+","+((int)(upperBound-Input.mousePosition.y)));
            
            }
        }
       
    }
}
