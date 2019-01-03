using System;

public class CharacterFactory
{
    public Character CreateCharacter(string factionType, string characterType, string name)
    {
        if (!Enum.TryParse<Faction>(factionType, out var factionObj))
        {
            throw new ArgumentException(string.Format(OutputMessage.InvalidFaction, factionType));
        }

        Character character = null;
        switch (characterType)
        {
            case "Warrior":
                character = new Warrior(name, factionObj);
                break;
            case "Cleric":
                character = new Cleric(name, factionObj);
                break;
            default:
                throw new ArgumentException(string.Format(OutputMessage.InvalidCharacter, characterType));
        }

        return character;
    }
}

