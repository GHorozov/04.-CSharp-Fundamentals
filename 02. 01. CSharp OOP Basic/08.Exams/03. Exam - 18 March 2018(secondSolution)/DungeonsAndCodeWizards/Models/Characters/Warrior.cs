namespace DungeonsAndCodeWizards.Models.Characters
{
    using System;
    using DungeonsAndCodeWizards.Core.Interfaces;
    using DungeonsAndCodeWizards.Models.Bags;
    using DungeonsAndCodeWizards.Models.Enums;
    using OutputMessages;
    
    public class Warrior : Character, IAttackable
    {
        private const double ConstBaseHealth = 100;
        private const double ConstBaseArmour = 50;
        private const double ConstAbilityPoint = 40;

        public Warrior(string name, Faction faction) 
            : base(name, ConstBaseHealth, ConstBaseArmour, ConstAbilityPoint, new Satchel(), faction)
        {
        }

        public void Attack(Character character)
        {
            if (!this.IsAlive)
            {
                throw new InvalidOperationException(OutputMessages.CharacterMustBeAlive);
            }

            if (!character.IsAlive)
            {
                throw new InvalidOperationException(OutputMessages.CharacterMustBeAlive);
            }

            if(this.Name == character.Name)
            {
                throw new InvalidOperationException(OutputMessages.CannotAttackItSelf);
            }

            if(this.Faction == character.Faction)
            {
                throw new ArgumentException(string.Format(OutputMessages.FriendlyFire, this.Faction));
            }

            character.TakeDamage(this.AbilityPoints);
        }
    }
}
