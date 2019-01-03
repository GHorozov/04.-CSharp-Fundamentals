using System;

public class PoisonPotion : Item
{
    private const int POTION_WEIGTH_CONST = 5;
    private const double REDUCE_HEALTH_CONST = 20;

    public PoisonPotion() 
        : base(POTION_WEIGTH_CONST)
    {
    }

    public override void AffectCharacter(Character character)
    {
        if (!character.IsAlive)
        {
            throw new InvalidOperationException(OutputMessage.CharacterMustBeAlive);
        }

        character.ReduceHealth(REDUCE_HEALTH_CONST);
    }
}

