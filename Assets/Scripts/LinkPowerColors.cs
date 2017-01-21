using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class LinkPowerColors : MonoBehaviour {

    public PowerColor[] powers;

    private Player link;

	// Use this for initialization
	void Start () {
        link = GetComponent<Player>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void SetColor(int index)
    {
        
    }
}

/*
[CustomEditor(typeof(LinkPowerColors))]
public class LinkPowerColorEditor : Editor
{


    public override void OnInspectorGUI()
    {

        LinkPowerColors lPC = target as LinkPowerColors;
        // Update the serializedProperty - always do this in the beginning of OnInspectorGUI.
        serializedObject.Update();

        lPC.normalMain = EditorGUILayout.ColorField("Normal: ", lPC.normalMain, GUILayout.Width(90));
        lPC.normalGems = EditorGUILayout.ColorField(lPC.normalGems);
        EditorGUILayout.Space();

        // Apply changes to the serializedProperty - always do this in the end of OnInspectorGUI.
        serializedObject.ApplyModifiedProperties();
    }

    void DoubleColor(Color c1, Color c2)
    {
        Rect rect = GUILayoutUtility.GetRect(18, 18);
        EditorGUI.ColorField(rect, c1);
        EditorGUILayout.Space();
        EditorGUI.ColorField(rect, c2);
        EditorGUILayout.Space();
    }
}
*/