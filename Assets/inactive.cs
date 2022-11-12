using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class inactive : MonoBehaviour
{
    public GameObject canvas;
    
   public void onClick(){
          AssetDatabase.Refresh();
        canvas.SetActive(false);
        
   }
}
