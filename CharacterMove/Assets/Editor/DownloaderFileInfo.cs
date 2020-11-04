using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;
using UnityEngine.Networking;
using System.IO.Compression;

public class DownloaderFileInfo : Editor
{
   
   private static string path = "Assets/settings.zip";
   private static string UnZipPath = "Assets/UnZip/";

   
   [MenuItem("Tools/Download")]
   public static void Download()
   {
      string url = "https://dminsky.com/settings.zip";
      UnityWebRequest uwr = UnityWebRequest.Get(url);
      var asq = uwr.SendWebRequest();
      asq.completed += operation =>
      {
         File.WriteAllBytes(path,uwr.downloadHandler.data);
         Debug.Log("Comlete");
        
      };
      AssetDatabase.Refresh();
   }
   
   [MenuItem("Tools/UnZip")]
   public static void UnZip()
   {
      ZipFile.ExtractToDirectory(path, UnZipPath);
      AssetDatabase.Refresh();
   }
   
   [MenuItem("Tools/ConvertToJson")]
   public static void ConvertToJson()
   {
      var f = File.ReadAllText(UnZipPath + "settings.json");
      var info = JsonUtility.FromJson<PlayerInfo>(f);
   }
   
}



