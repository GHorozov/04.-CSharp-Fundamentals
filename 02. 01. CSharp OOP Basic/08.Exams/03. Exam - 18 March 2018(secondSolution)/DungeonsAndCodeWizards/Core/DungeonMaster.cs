namespace DungeonsAndCodeWizards.Core
{
    using DungeonsAndCodeWizards.Core.Interfaces;
    using DungeonsAndCodeWizards.Models.Characters;
    using DungeonsAndCodeWizards.Models.Enums;
    using DungeonsAndCodeWizards.Models.Factories;
    using DungeonsAndCodeWizards.Models.Items;
    using DungeonsAndCodeWizards.Models.OutputMessages;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class DungeonMaster
    {
        private List<Character> characterPool;
        private List<Item> itemPool;
        private CharacterFactory characterFactory;
        private ItemFactory itemFactory;
        private int lastSurvivorRounds;

        public DungeonMaster()
        {
            this.characterPool = new List<Character>();
            this.itemPool = new List<Item>();
            this.characterFactory = new CharacterFactory();
            this.itemFactory = new ItemFactory();
            this.lastSurvivorRounds = 0;
        }

        public string JoinParty(string[] args)
        {
            var faction = args[0];
            var characterType = args[1];
            var name = args[2];

            var character = this.characterFactory.CreateCharacter(faction, characterType, name);
            this.characterPool.Add(character);

            return $"{name} joined the party!";
        }

        public string AddItemToPool(string[] args)
        {
            var itemName = args[0];

            var item = this.itemFactory.CreateItem(itemName);
            this.itemPool.Add(item);

            return $"{itemName} added to pool.";
        }

        public string PickUpItem(string[] args)
        {
            var characterName = args[0];
            Character character = CheckCharacter(characterName);
            if (!this.itemPool.Any())
            {
                throw new InvalidOperationException(string.Format(OutputMessages.NoItemLeftInThePool));
            }

            var item = this.itemPool.Last();
            this.itemPool.Remove(item);
            character.ReceiveItem(item);

            return $"{characterName} picked up {item.GetType().Name}!";
        }

        public string UseItem(string[] args)
        {
            var characterName = args[0];
            var itemName = args[1];

            Character character = CheckCharacter(characterName);
            var item = character.Bag.GetItem(itemName);
            character.UseItem(item);

            return $"{character.Name} used {itemName}.";
        }

        public string UseItemOn(string[] args)
        {
            var giverName = args[0];
            var receiverName = args[1];
            var itemName = args[2];

            Character giverCharacter = CheckCharacter(giverName);
            Character receiverCharacter = CheckCharacter(receiverName);
            var item = giverCharacter.Bag.GetItem(itemName);
            giverCharacter.UseItemOn(item, receiverCharacter);

            return $"{giverName} used {itemName} on {receiverName}.";
        }

        public string GiveCharacterItem(string[] args)
        {
            var giverName = args[0];
            var receiverName = args[1];
            var itemName = args[2];

            Character giverCharacter = CheckCharacter(giverName);
            Character receiverCharacter = CheckCharacter(receiverName);
            var item = giverCharacter.Bag.GetItem(itemName);
            receiverCharacter.GiveCharacterItem(item, receiverCharacter);

            return $"{giverName} gave {receiverName} {itemName}.";
        }

        public string GetStats()
        {
            var orderCharacters = this.characterPool
                .OrderByDescending(x => x.IsAlive)
                .ThenByDescending(x => x.Health).ToArray();

            var sb = new StringBuilder();
            foreach (var ch in orderCharacters)
            {
                var isDeadOrAlive = ch.IsAlive ? "Alive" : "Dead";
                sb.AppendLine($"{ch.Name} - HP: {ch.Health}/{ch.BaseHealth}, AP: {ch.Armor}/{ch.BaseArmor}, Status: {isDeadOrAlive}");
            }

            return sb.ToString().TrimEnd();
        }

        public string Attack(string[] args)
        {
            var attackerName = args[0];
            var receiverName = args[1];

            Character attackerCharacter = CheckCharacter(attackerName);
            Character receiverCharacter = CheckCharacter(receiverName);

            var sb = new StringBuilder();
            if(!(attackerCharacter is IAttackable attacker))
            {
                throw new ArgumentException(string.Format(OutputMessages.AttackerCannotAttack, attackerName));
            }

            attacker.Attack(receiverCharacter);

            sb.AppendLine(string.Format(OutputMessages.AttackerSuccess, attackerName,
                receiverName, attackerCharacter.AbilityPoints, receiverName,
                receiverCharacter.Health, receiverCharacter.BaseHealth,
                receiverCharacter.Armor, receiverCharacter.BaseArmor));

            if (!receiverCharacter.IsAlive)
            {
                sb.AppendLine(string.Format(OutputMessages.ReceiverIsDead, receiverName));
            }

            return sb.ToString().TrimEnd();
        }

        public string Heal(string[] args)
        {
            var healerName = args[0];
            var healingReceiverName = args[1];

            Character healerCharacter = CheckCharacter(healerName);
            Character receiveHealCharacter = CheckCharacter(healingReceiverName);

            if(!(healerCharacter is IHealable healer))
            {
                throw new ArgumentException(string.Format(OutputMessages.HealerConnotHeal, healerName));
            }

            healer.Heal(receiveHealCharacter);

            var sb = new StringBuilder();
            sb.AppendLine(string.Format(OutputMessages.HealSeccess, healerName,
                healingReceiverName, healerCharacter.AbilityPoints,
                receiveHealCharacter.Name, receiveHealCharacter.Health));

            return sb.ToString().TrimEnd();
        }

        public string EndTurn(string[] args)
        {
            var aliveCharacters = this.characterPool.Where(x => x.IsAlive).ToArray();

            var sb = new StringBuilder();
            foreach (var ch in aliveCharacters)
            {
                var healthBeforeRest = ch.Health;
                ch.Rest();
                sb.AppendLine(string.Format(OutputMessages.Rest, ch.Name, healthBeforeRest, ch.Health));
            }

            if(aliveCharacters.Length == 1 || aliveCharacters.Length == 0)
            {
                this.lastSurvivorRounds++;
            }

            return sb.ToString().TrimEnd();
        }

        public bool IsGameOver()
        {
            if(this.lastSurvivorRounds > 1)
            {
                return true;
            }

            return false;
        }

        private Character CheckCharacter(string characterName)
        {
            var character = this.characterPool.FirstOrDefault(x => x.Name == characterName);
            if (character == null)
            {
                throw new ArgumentException(string.Format(OutputMessages.CharacterNotFound, characterName));
            }

            return character;
        }
    }
}
