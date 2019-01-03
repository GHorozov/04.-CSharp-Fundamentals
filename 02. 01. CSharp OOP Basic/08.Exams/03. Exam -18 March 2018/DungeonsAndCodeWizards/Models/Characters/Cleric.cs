using System;

public class Cleric : Character, IHealable
{
    private const double BASE_HEALTH_CONST = 50;
    private const double BASE_ARMOR_CONST = 25;
    private const double BASE_ABILITY_POINTS_CONST = 40;
    private const double REST_HEAL_MULTIPLIER_CONST = 0.5;

    public Cleric(string name, Faction faction)
           : base(name, health: BASE_HEALTH_CONST, armor: BASE_ARMOR_CONST, abilityPoints: BASE_ABILITY_POINTS_CONST, bag: new Backpack(), faction: faction)
    {
    }

    public override double RestHealMultiplier => REST_HEAL_MULTIPLIER_CONST;

    public void Heal(Character character)
    {
        if(!this.IsAlive || !character.IsAlive)
        {
            throw new InvalidOperationException(OutputMessage.CharacterMustBeAlive);
        }

        if(this.Faction != character.Faction)
        {
            throw new InvalidOperationException(OutputMessage.CannotHealEnemy);
        }

        character.AddHealth(this.AbilityPoints);
    }
}

