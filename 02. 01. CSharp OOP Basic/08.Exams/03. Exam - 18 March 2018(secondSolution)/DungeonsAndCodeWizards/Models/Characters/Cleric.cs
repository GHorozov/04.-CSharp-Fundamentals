namespace DungeonsAndCodeWizards.Models.Characters
{
    using System;
    using DungeonsAndCodeWizards.Core.Interfaces;
    using DungeonsAndCodeWizards.Models.Bags;
    using DungeonsAndCodeWizards.Models.Enums;
    using OutputMessages;

    public class Cleric : Character, IHealable
    {
        private const double ConstBaseHealth = 50;
        private const double ConstBaseArmour = 25;
        private const double ConstAbilityPoint = 40;
        private const double ConstRestHealMultiplier = 0.5;

        public Cleric(string name, Faction faction) 
            : base(name, ConstBaseHealth, ConstBaseArmour, ConstAbilityPoint, new Backpack(), faction)
        {
            this.RestHealMultiplier = ConstRestHealMultiplier;
        }

        public void Heal(Character character)
        {
            if (!this.IsAlive)
            {
                throw new InvalidOperationException(OutputMessages.CharacterMustBeAlive);
            }

            if (!character.IsAlive)
            {
                throw new InvalidOperationException(OutputMessages.CharacterMustBeAlive);
            }

            if(this.Faction != character.Faction)
            {
                throw new InvalidOperationException(OutputMessages.CannotHealEnemy);
            }

            character.IncreaseCharacterHealth(this.AbilityPoints);
        }
    }
}
