using System;

public class Warrior : Character, IAttackable
{
    private const double BASE_HEALTH_CONST = 100;
    private const double BASE_ARMOR_CONST = 50;
    private const double BASE_ABILITY_POINTS_CONST = 40;

    public Warrior(string name, Faction faction)
            : base(name, health: BASE_HEALTH_CONST, armor: BASE_ARMOR_CONST, abilityPoints: BASE_ABILITY_POINTS_CONST, bag: new Satchel(), faction: faction)
    {
    }

    public void Attack(Character character)
    {
        if(!this.IsAlive || !character.IsAlive)
        {
            throw new InvalidOperationException(OutputMessage.CharacterMustBeAlive);
        }

        if(this == character)
        {
            throw new InvalidOperationException(OutputMessage.CannotAttackItSelf);
        }

        if(this.Faction == character.Faction)
        {
            throw new ArgumentException(string.Format(OutputMessage.FrendlyFire, this.Faction));
        }

        character.TakeDamage(this.AbilityPoints);
    }
}

