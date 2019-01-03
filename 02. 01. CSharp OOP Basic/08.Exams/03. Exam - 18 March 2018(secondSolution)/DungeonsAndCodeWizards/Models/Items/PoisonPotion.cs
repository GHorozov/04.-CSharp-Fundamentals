namespace DungeonsAndCodeWizards.Models.Items
{
    using System;
    using DungeonsAndCodeWizards.Models.Characters;

    public class PoisonPotion :Item
    {
        private double ConstToDecreaseHealth = 20;
        private const int ConstWeight = 5;

        public PoisonPotion() 
            : base(ConstWeight)
        {
        }

        public override void AffectCharacter(Character character)
        {
            character.DecreaseCharacterHealth(ConstToDecreaseHealth);
        }
    }
}
