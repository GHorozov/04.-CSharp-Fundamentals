using System;

public abstract class Character
{
    private const double REST_HEAL_MULTIPLIER_CONST = 0.2;

    private string name;
    private double health;
    private double armor;

    public Character(string name, double health, double armor, double abilityPoints, Bag bag, Faction faction)
    {
        this.Name = name;
        this.BaseHealth = health;
        this.Health = health;
        this.BaseArmor = armor;
        this.Armor = armor;
        this.AbilityPoints = abilityPoints;
        this.Bag = bag;
        this.Faction = faction;
        this.IsAlive = true;
    }

    public string Name
    {
        get
        {
            return this.name;
        }
        protected set
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException(OutputMessage.InvalidName);
            }

            this.name = value;
        }
    }

    public double BaseHealth { get; protected set; }

    public double Health
    {
        get
        {
            return this.health;
        }
        protected set
        {
            this.health = Math.Min(value, this.BaseHealth);
        }
    }

    public double BaseArmor { get; protected set; }

    public double Armor
    {
        get
        {
            return this.armor;
        }
        protected set
        {
            this.armor = Math.Min(value, this.BaseArmor);
        }
    }

    public double AbilityPoints { get; protected set; }

    public Bag Bag { get; protected set; }

    public Faction Faction { get; protected set; }

    public bool IsAlive { get; protected set; }

    public virtual double RestHealMultiplier => REST_HEAL_MULTIPLIER_CONST;

    public void TakeDamage(double hitPoints)
    {
        if (this.IsAlive)
        {
            var leftHitPoints = hitPoints - this.Armor;
            this.Armor -= hitPoints;
            if (this.Armor <= 0 && leftHitPoints > 0)
            {
                this.Armor = 0;
                this.Health -= leftHitPoints;
                if (this.Health < 0)
                {
                    this.Health = 0;
                    this.IsAlive = false;
                }
            }
        }
    }

    public void Rest()
    {
        if (!this.IsAlive)
        {
            throw new InvalidOperationException(OutputMessage.CharacterMustBeAlive);
        }

        this.Health += (this.BaseHealth * this.RestHealMultiplier);

    }

    public void UseItem(Item item)
    {
        if (!this.IsAlive)
        {
            throw new InvalidOperationException(OutputMessage.CharacterMustBeAlive);
        }

        item.AffectCharacter(this);
    }

    public void UseItemOn(Item item, Character character)
    {
        if (!this.IsAlive || !character.IsAlive)
        {
            throw new InvalidOperationException(OutputMessage.CharacterMustBeAlive);
        }

        item.AffectCharacter(character);
    }

    public void GiveCharacterItem(Item item, Character character)
    {
        if (!this.IsAlive || !character.IsAlive)
        {
            throw new InvalidOperationException(OutputMessage.CharacterMustBeAlive);
        }

        character.ReceiveItem(item);
    }

    public void ReceiveItem(Item item)
    {
        if (!this.IsAlive)
        {
            throw new InvalidOperationException(OutputMessage.CharacterMustBeAlive);
        }

        this.Bag.AddItem(item);
    }

    public void AddHealth(double health)
    {
        this.Health += health;
    }

    public void ReduceHealth(double health)
    {
        if (!this.IsAlive)
        {
            throw new InvalidOperationException(OutputMessage.CharacterMustBeAlive);
        }

        this.Health -= health;

        if (this.Health <= 0)
        {
            this.IsAlive = false;
            this.Health = 0;
        }
    }

    public void RestoreArmor()
    {
        if (!this.IsAlive)
        {
            throw new InvalidOperationException(OutputMessage.CharacterMustBeAlive);
        }

        this.Armor = this.BaseArmor;
    }

    public void IsBagEmpty()
    {
        if (this.Bag.Items.Count == 0)
        {
            throw new InvalidOperationException(string.Format(OutputMessage.BagIsEmpty));
        }
    }
}

