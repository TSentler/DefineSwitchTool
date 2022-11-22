using System;
using NUnit.Framework;
using UnityEditor;

namespace DefineSwitchTool.Editor.Tests
{
    public class DefineSwitcherTests
    {
        [Test]
        public void Can_Switch_To_Vk_Games()
        {
            Can_Switch(CustomDefines.VkGamesName, DefineSwitcher.ToVkGames);
        }
        
        [Test]
        public void Can_Switch_To_Vk_Games_Without_Duplicate()
        {
            Can_Switch_Without_Duplicate(CustomDefines.VkGamesName, DefineSwitcher.ToVkGames);
        }
        
        [Test]
        public void Can_Switch_To_Yandex_Games()
        {
            Can_Switch(CustomDefines.YandexGamesName, DefineSwitcher.ToYandexGames);
        }
        
        [Test]
        public void Can_Switch_To_Yandex_Games_Without_Duplicate()
        {
            Can_Switch_Without_Duplicate(CustomDefines.YandexGamesName, DefineSwitcher.ToYandexGames);
        }

        [Test]
        public void Switch_To_Vk_Remove_Yandex_Symbol_Pass()
        {
            //Assign
            
            //Act
            DefineSwitcher.ToYandexGames();
            DefineSwitcher.ToVkGames();
            
            //Assert
            string definesString = PlayerSettings.GetScriptingDefineSymbolsForGroup(
                EditorUserBuildSettings.selectedBuildTargetGroup);
            Assert.False(definesString.Contains(CustomDefines.YandexGamesName));
        }

        private void Can_Switch(string symbol, Action action)
        {
            //Assign
            
            //Act
            action.Invoke();
        
            //Assert
            string definesString = PlayerSettings.GetScriptingDefineSymbolsForGroup(
                EditorUserBuildSettings.selectedBuildTargetGroup);
            Assert.True(definesString.Contains(symbol));
        }
        
        private void Can_Switch_Without_Duplicate(string symbol, Action action)
        {
            //Assign
            
            //Act
            action.Invoke();
            action.Invoke();
        
            //Assert
            string definesString = PlayerSettings.GetScriptingDefineSymbolsForGroup(
                EditorUserBuildSettings.selectedBuildTargetGroup);
            Assert.AreEqual(definesString.LastIndexOf(symbol),
                definesString.IndexOf(symbol));
        }
    }
}
