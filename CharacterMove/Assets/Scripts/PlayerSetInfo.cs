using System;
using System.IO;
using UnityEditor;
using UnityEngine;

[ExecuteInEditMode]
public class PlayerSetInfo : MonoBehaviour
{
    private static readonly string UnZipPath = "Assets/UnZip/";
    [SerializeField] private PlayerInfo info;

    public PlayerInfo Info => info;

    private void Awake()
    {
        ConvertToJson();
    }

    

    public void ConvertToJson()
    {
        try
        {
            throw new DirectoryNotFoundException();
            var f = File.ReadAllText(UnZipPath + "settings.json");
            var playerInfo = JsonUtility.FromJson<PlayerInfo>(f);
            playerInfo.ConvertFromBase();
            info = playerInfo;
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

[Serializable]
public class PlayerInfo
{
    public float speed;
    public int health;
    public string fullName;
    public string base64Texture;
    public Texture2D texture;

    public void ConvertFromBase()
    {
        var base64 = base64Texture;
        var bytes = Convert.FromBase64String(base64);
        var texture2D = new Texture2D(2, 2);
        if (texture2D.LoadImage(bytes)) texture = texture2D;
    }
}