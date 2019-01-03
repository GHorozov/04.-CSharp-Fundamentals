using System;

class HealthPotion : Item
{
    private const int POTION_WEIGTH_CONST = 5;
    private const double ADD_HEALTH_CONST = 20;

    public HealthPotion() 
        : base(POTION_WEIGTH_CONST)
    {
    }

    public override void AffectCharacter(Character character)
    {
        if (!character.IsAlive)
        {
            throw new InvalidOperationException(OutputMessage.CharacterMustBeAlive);
        }

        character.AddHealth(ADD_HEALTH_CONST);
    }
}

