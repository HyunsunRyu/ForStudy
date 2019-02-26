using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

namespace Study
{
    public class CustomWindow : EditorWindow
    {
        private Vector2 scrollPos;

        private List<Data> dataList;
        private List<DisplayData> displayDataList;

        [MenuItem("Study/Custom Editor Window")]
        private static void Init()
        {
            CustomWindow window = (CustomWindow)EditorWindow.GetWindow(typeof(CustomWindow));
            window.titleContent = new GUIContent("Custom Window");
            window.Show();
        }

        private void OnEnable()
        {
            InitData();
        }

        private void InitData()
        {
            if (dataList == null || displayDataList == null)
            {
                dataList = new List<Data>();
                displayDataList = new List<DisplayData>();
            }
            dataList.Clear();
            displayDataList.Clear();

            string[] guides = AssetDatabase.FindAssets("t:CustomWindow", new string[] { "Assets/CustomEditor/Data" });
            foreach (string guid in guides)
            {
                Data data = AssetDatabase.LoadAssetAtPath<Data>(guid);
                if (data != null)
                {
                    dataList.Add(data);
                    displayDataList.Add(new DisplayData());
                }
            }
        }

        private void OnGUI()
        {
            scrollPos = EditorGUILayout.BeginScrollView(scrollPos, GUILayout.Height(300f));

            foreach (Data data in dataList)
            {
                
            }

            EditorGUILayout.EndScrollView();
        }
    }
}
