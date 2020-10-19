using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;

public class MenuColorFills : EditorWindow
{
   public Color color;
   
   [MenuItem("MyWindow/ColorFill")]
   public static void ShowMenu()
   {
      MenuColorFills window = (MenuColorFills)GetWindow(typeof( MenuColorFills));
      window.Show();
   }

   private void FillsColor()
   {
      var listRenders = FindObjectsOfType<MeshRenderer>().ToList();
      
      foreach (var item in listRenders)
      {
         if(item!=null)
         item.material.color = color;
      }
   }
   private void OnGUI()
   {
      color = EditorGUILayout.ColorField("Color", color);

      if (GUILayout.Button("Fill"))
      {
         FillsColor();
      }
   }
}
