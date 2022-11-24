using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;

namespace DefineSwitchTool.Editor
{
    public class DefineSwitcher : MonoBehaviour
    {
        private static readonly BuildTargetGroup _buildTargetGroup =
            EditorUserBuildSettings.selectedBuildTargetGroup;
        
        [MenuItem("Tools/DefineSwitcher/ToVkGames")]
        public static void ToVkGames()
        {
            AddDefineSymbols(CustomDefines.VkGamesName);
        }
        
        [MenuItem("Tools/DefineSwitcher/ToYandexGames")]
        public static void ToYandexGames()
        {
            AddDefineSymbols(CustomDefines.YandexGamesName);
        }

        public static List<string> GetCurrentDefineSymbols()
        {
            string definesString = PlayerSettings.GetScriptingDefineSymbolsForGroup(_buildTargetGroup);
            return definesString.Split(';').ToList();
        }

        public static void AddDefineSymbols(string symbol)
        {
            AddDefineSymbols(new []{symbol});
        }
        
        public static void AddDefineSymbols(string[] symbols)
        {
            var _defineSymbols = new CustomDefines();
            List<string> allDefines = GetCurrentDefineSymbols();
            allDefines = _defineSymbols.ExcludeCustomDefinesFrom(allDefines).ToList();
            allDefines.AddRange(symbols.Except(allDefines));
            PlayerSettings.SetScriptingDefineSymbolsForGroup (
                _buildTargetGroup, string.Join(";", allDefines.ToArray()));

            var symbolsString = string.Join(" ", symbols);
            Debug.Log($"Switch to {symbolsString}!");
        }
    }
}
