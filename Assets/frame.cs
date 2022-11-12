using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEditor;
using UnityEngine.Video;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class frame : MonoBehaviour
{
    // Start is called before the first frame update
   

    public void onClick()
    {
        
        var videoPlayer = GetComponent<VideoPlayer>();
        videoPlayer.clip=(VideoClip)AssetDatabase.LoadAssetAtPath("Assets/"+EventSystem.current.currentSelectedGameObject.name+".mp4", typeof(VideoClip));
        videoPlayer.Stop();
        videoPlayer.renderMode = VideoRenderMode.APIOnly;
        videoPlayer.prepareCompleted += Prepared;
        videoPlayer.sendFrameReadyEvents = true;
        videoPlayer.frameReady += FrameReady;
        videoPlayer.Prepare();
        //Debug.Log(mySprite.rect.height);
 
        void Prepared(VideoPlayer vp) => vp.Pause();
    
        void FrameReady(VideoPlayer vp, long frameIndex)
        {
            Debug.Log("FrameReady " + frameIndex);
            var textureToCopy = vp.texture;
            // Perform texture copy here ...
            vp.frame = frameIndex + (long)vp.frameCount;
            Texture2D myTexture2D=textureToTexture2D(textureToCopy);
            byte[] bytes = myTexture2D.EncodeToPNG();
            Object.Destroy(myTexture2D);
    

        // For testing purposes, also write to a file in the project folder
            File.WriteAllBytes(Application.dataPath +"/"+EventSystem.current.currentSelectedGameObject.name+".png", bytes);

            //mySprite = Sprite.Create(myTexture2D, new Rect(0.0f, 0.0f, myTexture2D.width, myTexture2D.height), new Vector2(0.5f, 0.5f), 100.0f);
            //myImage.sprite=mySprite;
            //AssetDatabase.CreateAsset(mySprite,"Assets/Resources/image.png");

        }
       

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    Texture2D textureToTexture2D(Texture mainTexture){
        Texture2D texture2D = new Texture2D(mainTexture.width, mainTexture.height, TextureFormat.RGBA32, false);
  
        RenderTexture currentRT = RenderTexture.active;
  
        RenderTexture renderTexture = new RenderTexture(mainTexture.width, mainTexture.height, 32);
        Graphics.Blit(mainTexture, renderTexture);
  
        RenderTexture.active = renderTexture;
        texture2D.ReadPixels(new Rect(0, 0, renderTexture.width, renderTexture.height), 0, 0);
        texture2D.Apply();
  
        Color[] pixels = texture2D.GetPixels();
  
        RenderTexture.active = currentRT;
        return texture2D;
    }
}

//EventSystem.current.currentSelectedGameObject.name