using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public abstract class DataBoxEditor : EditorWindow
{
    protected ScriptableObject data;

    public void Init(ScriptableObject data)
    {
        this.data = data;
    }

    public abstract void ShowDataBox();
}
