using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;

namespace DefineSwitchTool.Editor
{
    public class CustomDefines
    {
        public static readonly string DefineSymbolsDataPath =
            "Packages/com.agava.defineswitchtool/Editor/"
            + typeof(DefineSymbolsData).Name + ".asset";
        
        private DefineSymbolsData _defineSymbolsData;

        public static string VkGamesName => "VK_GAMES";
        public static string YandexGamesName => "YANDEX_GAMES";

        public DefineSymbolsData DefineSymbolsData => _defineSymbolsData;
        
        public CustomDefines()
        {
            _defineSymbolsData = LoadDefineSymbolsData();
            if (_defineSymbolsData == null)
            {
                _defineSymbolsData = CreateDefineSymbolsData();
            }
        }
        
        public IEnumerable<string> ExcludeCustomDefinesFrom(IEnumerable<string> defines)
        {
            return defines.Except(_defineSymbolsData.Symbols);
        }
        
        private DefineSymbolsData CreateDefineSymbolsData()
        {
            DefineSymbolsData asset =
                ScriptableObject.CreateInstance<DefineSymbolsData>();
            string uniqAssetPath =
                AssetDatabase.GenerateUniqueAssetPath(DefineSymbolsDataPath);
            AssetDatabase.CreateAsset(asset, uniqAssetPath);
            AssetDatabase.SaveAssets();
            AssetDatabase.Refresh();
            return AssetDatabase.LoadAssetAtPath<DefineSymbolsData>(DefineSymbolsDataPath);
        }

        private DefineSymbolsData LoadDefineSymbolsData()
        {
            return AssetDatabase.LoadAssetAtPath<DefineSymbolsData>(
                DefineSymbolsDataPath);
        }
    }
}