namespace DungeonsAndCodeWizards.Models.Characters
{
    using System;
    using System.Linq;
    using DungeonsAndCodeWizards.Models.Bags;
    using DungeonsAndCodeWizards.Models.Enums;
    using DungeonsAndCodeWizards.Models.Items;
    using OutputMessages;

    public class Character
    {
        private const double ConstRestHealMultiplier = 0.2;
        private string name;
        private double health;
        private double armor;
        private double restHealMultiplier;
        private bool isAlive;

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
            this.RestHealMultiplier = ConstRestHealMultiplier;
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
                if (string.IsNullOrWhiteSpace(value) || value == "null")
                {
                    throw new ArgumentException(OutputMessages.NameCannotBeNullOrWhiteSpace);
                }

                this.name = value;
            }
        }

        public double BaseHealth { get; private set; }
        public double Health
        {
            get
            {
                return this.health;
            }
            private set
            {
                this.health = Math.Min(value, this.BaseHealth);
            }
        }
        public double BaseArmor { get; private set; }
        public double Armor
        {
            get
            {
                return this.armor;
            }
            private set
            {
                this.armor = Math.Min(value, this.BaseArmor);
            }
        }
        public double AbilityPoints { get; private set; }
        public Bag Bag { get; private set; }
        public Faction Faction { get; private set; }
        public bool IsAlive
        {
            get
            {
                return this.isAlive;
            }
            private set
            {
                this.isAlive = value;
            }
        }
        public virtual double RestHealMultiplier
        {
            get
            {
                return this.restHealMultiplier;
            }
            protected set
            {
                this.restHealMultiplier = value;
            }
        }

        public void TakeDamage(double hitPoints)
        {
            if (!this.IsAlive)
            {
                throw new InvalidOperationException(OutputMessages.CharacterMustBeAlive);
            }

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

        public void Rest()
        {
            if (!this.IsAlive)
            {
                throw new InvalidOperationException(OutputMessages.CharacterMustBeAlive);
            }

            this.Health += (this.BaseHealth * this.RestHealMultiplier);
        }

        public void UseItem(Item item)
        {
            if (!this.IsAlive)
            {
                throw new InvalidOperationException(OutputMessages.CharacterMustBeAlive);
            }

            item.AffectCharacter(this);
        }

        public void UseItemOn(Item item, Character character)
        {
            if (!this.IsAlive)
            {
                throw new InvalidOperationException(OutputMessages.CharacterMustBeAlive);
            }

            if (!character.IsAlive)
            {
                throw new InvalidOperationException(OutputMessages.CharacterMustBeAlive);
            }

            item.AffectCharacter(character);
        }

        public void GiveCharacterItem(Item item, Character character)
        {
            if (!this.IsAlive)
            {
                throw new InvalidOperationException(OutputMessages.CharacterMustBeAlive);
            }

            if (!character.IsAlive)
            {
                throw new InvalidOperationException(OutputMessages.CharacterMustBeAlive);
            }

            character.ReceiveItem(item);
        }

        public void ReceiveItem(Item item)
        {
            if (!this.IsAlive)
            {
                throw new InvalidOperationException(OutputMessages.CharacterMustBeAlive);
            }

            this.Bag.AddItem(item);
        }

        public void IncreaseCharacterHealth(double number)
        {
            if (!this.IsAlive)
            {
                throw new InvalidOperationException(OutputMessages.CharacterMustBeAlive);
            }

            this.Health += number;
        }

        public void DecreaseCharacterHealth(double number)
        {
            if (!this.IsAlive)
            {
                throw new InvalidOperationException(OutputMessages.CharacterMustBeAlive);
            }

            this.Health -= number;
            if (this.Health <= 0)
            {
                this.Health = 0;
                this.IsAlive = false;
            }
        }

        public void RestoreCharacterBaseArmour()
        {
            if (!this.IsAlive)
            {
                throw new InvalidOperationException(OutputMessages.CharacterMustBeAlive);
            }

            this.Armor = this.BaseArmor;
        }
    }
}
