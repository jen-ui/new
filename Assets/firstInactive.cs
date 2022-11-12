using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class firstInactive : MonoBehaviour
{
    public GameObject canvas2;// Start is called before the first frame update
    public GameObject canvas3;
    public GameObject canvas4;
    public GameObject canvas5;
    public GameObject canvas6;
    void Start()
    {
        
        canvas2.SetActive(false);
        canvas3.SetActive(false);
        canvas4.SetActive(false);
        canvas5.SetActive(false);
        canvas6.SetActive(false);
   }
}

