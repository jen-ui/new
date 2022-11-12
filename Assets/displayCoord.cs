using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using UnityEditor;

public class displayCoord : MonoBehaviour
{
  public Image MyImage;
    private float spriteHeight;
    private float spritewidth;
                
    public string fileName;

    List<Vector2> coord=new List<Vector2>();

    public void createFile(){
        //Debug.Log(east.coord.Count);
        Debug.Log(coord.Count);
        //var temp=(str)coord;
        //Debug.Log(temp);
        string x = string.Join( ",", coord);
        File.WriteAllText(Application.dataPath+"/"+fileName+".txt",x);
        AssetDatabase.Refresh();
        
    }

    void Update()
    {
        if(MyImage.GetComponent<Image>().sprite){
            spriteHeight=MyImage.GetComponent<Image>().sprite.rect.height;
            spritewidth=MyImage.GetComponent<Image>().sprite.rect.width;
            float upperBound=transform.position.y+spriteHeight/2;
            float leftBound=transform.position.x-spritewidth/2;
        
            if (Input.GetMouseButtonDown(1)){
                var x=(int)(Input.mousePosition.x-leftBound);
                var y=(int)(upperBound-Input.mousePosition.y);
            
                Vector2 temp=new Vector2(x,y);
                coord.Add(temp);
            }
        }
       
    }
}