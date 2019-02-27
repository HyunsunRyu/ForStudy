using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

namespace Study
{
    public class CustomDataBoxEditor : DataBoxEditor
    {
        public override void ShowDataBox()
        {
            Data customData = data as Data;

            GUILayout.BeginVertical();
            GUILayout.Label(customData.name);

            GUILayout.BeginHorizontal();
            if (customData.resourceList != null && customData.checkList != null)
            {
                for (int i = 0; i < customData.resourceList.Count; i++)
                {
                    EditorGUILayout.ObjectField(customData.resourceList[i], typeof(Object), true);
                    bool check = EditorGUILayout.Toggle(customData.checkList[i]);
                    if (check != customData.checkList[i])
                    {
                        customData.checkList[i] = check;
                    }
                }
            }
            GUILayout.EndHorizontal();
            if (GUILayout.Button("Add"))
            {
                if (customData.resourceList == null)
                {
                    customData.resourceList = new List<Object>();
                }
                if (customData.checkList == null)
                {
                    customData.checkList = new List<bool>();
                }

                int minCount = Mathf.Min(customData.resourceList.Count, customData.checkList.Count);
                customData.resourceList.RemoveRange(minCount, customData.resourceList.Count - minCount);
                customData.checkList.RemoveRange(minCount, customData.checkList.Count - minCount);

                customData.resourceList.Add(new Object());
                customData.checkList.Add(true);
            }
            

            GUILayout.EndVertical();
        }
    }
}