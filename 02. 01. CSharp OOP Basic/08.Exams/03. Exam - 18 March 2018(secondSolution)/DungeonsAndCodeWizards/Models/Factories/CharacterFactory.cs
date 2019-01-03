namespace DungeonsAndCodeWizards.Models.Factories
{
    using System;
    using System.Linq;
    using DungeonsAndCodeWizards.Models.Characters;
    using DungeonsAndCodeWizards.Models.Enums;
    using OutputMessages;

    public class CharacterFactory
    {
        public Character CreateCharacter(string faction, string characterType, string name)
        {
            if (!Enum.TryParse<Faction>(faction, out var parsedFaction))
            {
                throw new ArgumentException(string.Format(OutputMessages.InvalidFaction, faction));
            }

            Character character = null;
            switch (characterType)
            {
                case "Warrior":
                    character = new Warrior(name, parsedFaction);
                    break;
                case "Cleric":
                    character = new Cleric(name, parsedFaction);
                    break;
                default:
                    throw new ArgumentException(string.Format(OutputMessages.InvalidCharacterType, characterType));
            }

            return character;

            //Second way - Reflection: 
            //Faction currentFaction;
            //var isValid = Enum.TryParse<Faction>(faction, out currentFaction);
            //if (!isValid)
            //{
            //    throw new ArgumentException(string.Format(OutputMessages.InvalidFaction, faction));
            //}

            //var type = this.GetType()
            //.Assembly
            //.GetTypes()
            //.FirstOrDefault(x => x.Name == characterType);

            //if (type == null || characterType == "Character")
            //{
            //    throw new ArgumentException(string.Format(OutputMessages.InvalidCharacterType, characterType));
            //}

            //try
            //{
            //    var character = (Character)Activator.CreateInstance(type, new object[] { name, currentFaction });
            //    return character;
            //}
            //catch (Exception ex)
            //{
            //    throw new InvalidOperationException(ex.Message);
            //}
        }
    }
}
