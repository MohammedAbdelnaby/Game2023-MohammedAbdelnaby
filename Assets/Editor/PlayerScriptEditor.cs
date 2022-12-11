using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(PlayerMovement))]
public class PlayerScriptEditor : Editor
{
    public override void OnInspectorGUI()
    {
        PlayerMovement player = (PlayerMovement)target;
        DrawDefaultInspector();
        EditorGUILayout.LabelField("Direction", player.Direction.ToString());
        if (GUILayout.Button("Travel to saved poistion"))
        {
            player.TravelToSavedPoistion();
        }
        EditorGUILayout.LabelField("Saved Position", new Vector3(PlayerPrefs.GetFloat("X"), PlayerPrefs.GetFloat("Y"), PlayerPrefs.GetFloat("Z")).ToString());
    }
}


