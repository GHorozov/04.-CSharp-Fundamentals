namespace DungeonsAndCodeWizards.Models.Items
{
    using System;
    using DungeonsAndCodeWizards.Models.Characters;

    public class HealthPotion : Item
    {
        private double ConstToIncreaseHealth = 20;
        private const int ConstWeight = 5;

        public HealthPotion() 
            : base(ConstWeight)
        {
        }

        public override void AffectCharacter(Character character)
        {
            character.IncreaseCharacterHealth(ConstToIncreaseHealth);
        }
    }
}
