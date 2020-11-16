using System;
using System.IO;
using System.IO.Compression;
using UnityEditor;
using UnityEngine;
using UnityEngine.Networking;

public class DownloaderFileInfo : Editor
{
    private static readonly string path = "Assets/settings.zip";
    private static readonly string UnZipPath = "Assets/UnZip/";


    [MenuItem("Tools/Download")]
    public static void Download()
    {
        try
        {
            throw new ArgumentException();
            var url = "https://dminsky.com/settings.zip";
            var uwr = UnityWebRequest.Get(url);
            var asq = uwr.SendWebRequest();
            asq.completed += operation =>
            {
                File.WriteAllBytes(path, uwr.downloadHandler.data);
                Debug.Log("Comlete");
            };
            AssetDatabase.Refresh();
        }
        catch (ArgumentException e)
        {
            EditorUtility.DisplayDialog("Error", "path is not correct!", "OKAY((", "OK");
        }
        catch (DirectoryNotFoundException e)
        {
            EditorUtility.DisplayDialog("Error", "Directory not found!", "OKAY((", "OK");
        }
        catch (IOException e)
        {
            EditorUtility.DisplayDialog("Error", e.Message, "OKAY((", "OK");
        }
        catch (Exception e)
        {
            EditorUtility.DisplayDialog("Error", e.Message, "OKAY((", "OK");
        }
    }

    [MenuItem("Tools/UnZip")]
    public static void UnZip()
    {
        try
        {
            throw new IOException();
            ZipFile.ExtractToDirectory(path, UnZipPath);
            AssetDatabase.Refresh();
        }
        catch (ArgumentException e)
        {
            EditorUtility.DisplayDialog("Error", "path is not correct!", "OKAY((", "OK");
        }
        catch (DirectoryNotFoundException e)
        {
            EditorUtility.DisplayDialog("Error", "Directory not found!", "OKAY((", "OK");
        }
        catch (IOException e)
        {
            EditorUtility.DisplayDialog("Error", e.Message, "OKAY((", "OK");
        }
        catch (Exception e)
        {
            EditorUtility.DisplayDialog("Error", e.Message, "OKAY((", "OK");
        }
    }

    [MenuItem("Tools/ConvertToJson")]
    public static void ConvertToJson()
    {
        try
        {


            var f = File.ReadAllText(UnZipPath + "settings.json");
            var info = JsonUtility.FromJson<PlayerInfo>(f);
        }
        catch (ArgumentException e)
        {
            EditorUtility.DisplayDialog("Error", "path is not correct!", "OKAY((", "OK");
        }
        catch (DirectoryNotFoundException e)
        {
            EditorUtility.DisplayDialog("Error", "Directory not found!", "OKAY((", "OK");
        }
        catch (IOException e)
        {
            EditorUtility.DisplayDialog("Error", e.Message, "OKAY((", "OK");
        }
        catch (Exception e)
        {
            EditorUtility.DisplayDialog("Error", e.Message, "OKAY((", "OK");
        }
    }
}