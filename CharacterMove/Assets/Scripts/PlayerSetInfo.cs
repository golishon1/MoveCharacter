using System;
using System.IO;
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
        var f = File.ReadAllText(UnZipPath + "settings.json");
        var playerInfo = JsonUtility.FromJson<PlayerInfo>(f);
        playerInfo.ConvertFromBase();
        info = playerInfo;
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