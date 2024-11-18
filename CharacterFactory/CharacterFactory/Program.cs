using System;
using CharacterFactoryNameSpace;

namespace CharacterFactoryApp
{
    class Program
    {
        static void Main()
        {
            ICharacter admin1 = CharacterFactory.CreateCharacter("Иван", "sysadmin");
            ICharacter admin2 = CharacterFactory.CreateCharacter("Иван", "sysadmin");
            ICharacter user1 = CharacterFactory.CreateCharacter("Анна", "user");

            CharacterFactory.SetCharacterAttributes("Иван", "sysadmin", "admin2.png", 1);
            CharacterFactory.SetCharacterAttributes("Анна", "user", "user.png", 1);

            admin1.DisplayInfo();
            admin2.DisplayInfo();
            user1.DisplayInfo();

            CharacterFactory.SetCharacterAttributes("Иван", "sysadmin", "admin_updated.png", 5);
            admin1.DisplayInfo();

            Console.WriteLine(object.ReferenceEquals(admin1, admin2));
            Console.WriteLine(object.ReferenceEquals(admin1, user1));
        }
    }
}
