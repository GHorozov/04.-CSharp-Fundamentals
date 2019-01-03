namespace DungeonsAndCodeWizards.Models.Items
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using DungeonsAndCodeWizards.Models.Characters;

    public class ArmorRepairKit :Item
    {
        private const int ConstWeight = 10;

        public ArmorRepairKit() 
            : base(ConstWeight)
        {
        }

        public override void AffectCharacter(Character character)
        {
            character.RestoreCharacterBaseArmour();
        }
    }
}
