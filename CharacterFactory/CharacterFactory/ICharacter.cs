namespace CharacterFactoryNameSpace
{
    public interface ICharacter
    {
        string Name { get; }
        string Role { get; }
        void DisplayInfo();
    }
}
