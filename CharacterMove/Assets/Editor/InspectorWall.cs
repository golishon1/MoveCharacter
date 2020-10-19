using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(Wall))]
public class InspectorWall : Editor
{
   
   public override void OnInspectorGUI()
   {
      base.OnInspectorGUI();
      Wall myTarget = (Wall)target;
      
      if (GUILayout.Button("Return color"))
      {
         myTarget.ReturnColor();
      }
   }
}
