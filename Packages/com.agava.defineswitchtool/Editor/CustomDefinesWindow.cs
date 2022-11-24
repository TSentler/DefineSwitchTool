using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace DefineSwitchTool.Editor
{
    public class CustomDefinesWindow : EditorWindow
    {
        private CustomDefines _customDefines;
        private List<string> _checkedSymbols;

        private void Awake()
        {
            _customDefines = new CustomDefines();

            if (_customDefines.DefineSymbolsData == null)
            {
                Debug.LogError("Can`t find " 
                               + CustomDefines.DefineSymbolsDataPath);
                Close();
            }
            else
            {
                Selection.activeObject = _customDefines.DefineSymbolsData;
                _checkedSymbols = DefineSwitcher.GetCurrentDefineSymbols();
            }
        }

        [MenuItem("Tools/DefineSwitcher/CustomDefines")]
        public static void ShowWindow()
        {
            GetWindow<CustomDefinesWindow>(nameof(CustomDefinesWindow));
        }

        private void OnGUI()
        {
            GUILayout.Label("DefineSymbols", EditorStyles.boldLabel);
            SerializedObject serializedObject = 
                new SerializedObject(_customDefines.DefineSymbolsData);
            SerializedProperty stringsProperty = serializedObject.FindProperty(
                nameof(_customDefines.DefineSymbolsData.Symbols));
            EditorGUILayout.PropertyField(stringsProperty, true);
            serializedObject.ApplyModifiedProperties();

            foreach (var symbol in _customDefines.DefineSymbolsData.Symbols)
            {
                var isChecked = _checkedSymbols.Contains(symbol);
                var isCheckedNow = EditorGUILayout.Toggle(symbol, isChecked);
                if (isChecked && isCheckedNow == false)
                {
                    _checkedSymbols.Remove(symbol);
                }
                else if (isChecked == false && isCheckedNow)
                {
                    _checkedSymbols.Add(symbol);
                }
            }
            
            Debug.Log( string.Join(",", _checkedSymbols));
        }
    }
}