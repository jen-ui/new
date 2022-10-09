using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.IO;
using UnityEngine.Networking;
using UnityEngine.UI;

public class FileManager : MonoBehaviour
{
    string path;
    string savePath;
    string fileName;

    
    //string ret;

    //public RawImage image;

    public void OpenExplorer()
    {
        path=EditorUtility.OpenFilePanel("Image Explorer","","mp4");
        fileName=Path.GetFileName(path);
        savePath=Application.dataPath+"/videos/"+fileName;
        // var strPath = $"Assets/videos/"+fileName;
        Save();
        // Debug.Log(fileName);
        // Debug.Log(savePath);
        // Debug.Log(path);

        


        // ret = AssetDatabase.RenameAsset(strPath, "MyMaterialNew");
        // if (ret == "")
        //     Debug.Log("Material asset renamed to MyMaterialNew");
        // else
        //     Debug.Log(ret);
        AssetDatabase.Refresh();
    }   


    // void Display(){
    //     if(path!=null){

    //     }
    // }

    // IEnumerator GetImage(){
    //     UnityWebRequest www = UnityWebRequestTexture.GetTexture("file:///" + path);
    //     yield return www.SendWebRequest();
    //     image.texture=((DownloadHandlerTexture)www.downloadHandler).texture;
    // }

   
    public void Save(){
        FileUtil.CopyFileOrDirectory(path,savePath);   
        print("file saved");
    }

     

}
