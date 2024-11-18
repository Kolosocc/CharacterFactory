using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace CharacterFactoryNameSpace
{
    public static class CharacterFactory
    {
        private static readonly Dictionary<string, Character> _characterCache = new Dictionary<string, Character>();
        private static readonly Dictionary<string, (string Image, int Level)> _attributesCache = new Dictionary<string, (string, int)>();

        public static readonly char[] BrightnessMap =
        {
            ' ', '.', ':', '-', '=', '+', '*', '#', '%', '8', '&', '@',
            '$', '0', 'O', '8'
        };

        public static Character CreateCharacter(string name, string role)
        {
            string key = $"{name}_{role}";

            if (!_characterCache.ContainsKey(key))
            {
                _characterCache[key] = new Character(name, role);
            }

            return _characterCache[key];
        }

        public static void SetCharacterAttributes(string name, string role, string image, int level)
        {
            string key = $"{name}_{role}";
            _attributesCache[key] = (image, level);
        }

        public static (string Image, int Level) GetCharacterAttributes(string name, string role)
        {
            string key = $"{name}_{role}";
            if (_attributesCache.ContainsKey(key))
            {
                return _attributesCache[key];
            }

            return (null, 0);
        }

        public static ICollection<Character> GetAllCharacters() => _characterCache.Values;
    }
}