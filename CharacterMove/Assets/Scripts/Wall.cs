using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : MonoBehaviour
{
    [SerializeField] private Color _color;

    private void Reset()
    {
        _color = GetComponent<MeshRenderer>().material.color;
    }
    
    public void ReturnColor()
    {
        GetComponent<MeshRenderer>().material.color = _color;
    }
}
