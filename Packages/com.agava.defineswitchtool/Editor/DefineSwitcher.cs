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
            AddDefineSymbols(new []{"VK_GAMES"});
            Debug.Log("ToVkGames!");
        }
        
        [MenuItem("Tools/DefineSwitcher/ToYandexGames")]
        public static void ToYandexGames()
        {
            AddDefineSymbols(new []{"YANDEX_GAMES"});
            Debug.Log("ToYandexGames!");
        }
        
        private static void AddDefineSymbols(string[] symbols)
        {
            string definesString = PlayerSettings.GetScriptingDefineSymbolsForGroup(_buildTargetGroup);
            List<string> allDefines = definesString.Split(';').ToList();
            allDefines.AddRange(symbols.Except(allDefines));
            PlayerSettings.SetScriptingDefineSymbolsForGroup (
                _buildTargetGroup, string.Join(";", allDefines.ToArray()));
        }
    }
}
