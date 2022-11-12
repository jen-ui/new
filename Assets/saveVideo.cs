using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.IO;
using UnityEngine.Networking;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.Windows.WebCam;

public class saveVideo : MonoBehaviour
{
    string path;
    string savePath;
    string fileName;
    string relativePath;

    
    //string ret;

    //public RawImage image;

    public void OpenExplorer()
    {
        path=EditorUtility.OpenFilePanel("Image Explorer","","mp4");
        fileName=EventSystem.current.currentSelectedGameObject.name;
        savePath=Application.dataPath+"/"+fileName+".mp4";
        Save();
        

        AssetDatabase.Refresh();
    }   

    public void Save(){
          relativePath="Assets/"+fileName+".mp4";
        if(File.Exists(relativePath)){
           
            AssetDatabase.DeleteAsset(relativePath);
        }
        FileUtil.CopyFileOrDirectory(path,savePath);   
        print("file saved");
    }

     

}