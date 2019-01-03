using System;

public class ArmorRepairKit : Item
{
    private const int POTION_WEIGTH_CONST = 10;

    public ArmorRepairKit() 
        : base(POTION_WEIGTH_CONST)
    {
    }

    public override void AffectCharacter(Character character)
    {
        if (!character.IsAlive)
        {
            throw new InvalidOperationException(OutputMessage.CharacterMustBeAlive);
        }

        character.RestoreArmor();
    }
}

