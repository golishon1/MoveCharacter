using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mirror : MonoBehaviour
{

    [SerializeField] private Camera mirrorCamera;
    [SerializeField] private MeshRenderer meshMirror;
    
    void Start()
    {
        var mat = meshMirror.materials[0];
        var renderTexture = new RenderTexture(512,512,16,RenderTextureFormat.Default);
        mirrorCamera.targetTexture = renderTexture;
        mat.SetTexture("_MainTex",renderTexture);
    }

}
