using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class loadimg : MonoBehaviour
{
  public Sprite img1;
    public Image MyImage;
    private float spriteHeight;
    private float spritewidth;
    
   

    public void Start(){
        
      spriteHeight=img1.rect.height;
      spritewidth=img1.rect.width;
      
      MyImage.rectTransform.sizeDelta=new Vector2(spritewidth,spriteHeight);
        
      MyImage.GetComponent<Image>().sprite = img1;
       
    }
}


