using System.Collections.Generic;
using System.Linq;

namespace DefineSwitchTool.Editor
{
    public class CustomDefines
    {
        private static readonly string[] _defineSymbols = new[]
        {
            "VK_GAMES",
            "VK_GAMES_MOBILE",
            "YANDEX_GAMES",
            "CRAZY_GAMES",
        };

        public static string VkGamesName => _defineSymbols[0];
        public static string YandexGamesName => _defineSymbols[2];

        public static IEnumerable<string> ExcludeCustomDefinesFrom(IEnumerable<string> defines)
        {
            return defines.Except(_defineSymbols);
        }
    }
}