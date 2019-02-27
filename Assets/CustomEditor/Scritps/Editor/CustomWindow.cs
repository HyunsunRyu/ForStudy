using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

namespace Study
{
    public class CustomWindow : EditorWindow
    {
        private ScrollViewEditor scrollView;

        private List<DataBoxEditor> dataBoxList;

        [MenuItem("Study/Custom Editor Window")]
        private static void Init()
        {
            CustomWindow window = (CustomWindow)EditorWindow.GetWindow(typeof(CustomWindow));
            window.titleContent = new GUIContent("Custom Window");
            window.Show();
        }

        private void Awake()
        {
            scrollView = new ScrollViewEditor();
            scrollView.Init(GUILayout.Height(300f));

            dataBoxList = new List<DataBoxEditor>();
        }

        private void OnEnable()
        {
            InitData();
        }

        private void InitData()
        {
            dataBoxList.Clear();


            string[] guides = AssetDatabase.FindAssets("t:Data", new string[] { "Assets/CustomEditor/Data" });
            foreach (string guid in guides)
            {
                string path = AssetDatabase.GUIDToAssetPath(guid);
                Data data = AssetDatabase.LoadAssetAtPath<Data>(path);
                if (data != null)
                {
                    CustomDataBoxEditor dataBox = new CustomDataBoxEditor();
                    dataBox.Init(data);
                    dataBoxList.Add(dataBox);
                }
            }
        }

        private void OnGUI()
        {
            scrollView.ShowScrollView(dataBoxList);
        }
    }
}
