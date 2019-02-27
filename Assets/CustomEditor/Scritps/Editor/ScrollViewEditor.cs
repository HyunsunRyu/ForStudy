using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class ScrollViewEditor : EditorWindow
{
    private Vector2 scrollPos;
    private GUILayoutOption[] options;

    public void Init(params GUILayoutOption[] options)
    {
        this.options = options;
    }

    public void ShowScrollView(List<DataBoxEditor> dataBoxList)
    {
        if (options != null)
        {
            scrollPos = EditorGUILayout.BeginScrollView(scrollPos, options);
        }
        else
        {
            scrollPos = EditorGUILayout.BeginScrollView(scrollPos);
        }

        foreach (DataBoxEditor dataBox in dataBoxList)
        {
            dataBox.ShowDataBox();
        }

        EditorGUILayout.EndScrollView();
    }
}
