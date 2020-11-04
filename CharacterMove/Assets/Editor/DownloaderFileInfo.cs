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