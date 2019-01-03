using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class DungeonMaster
{
    private IList<Character> characters;
    private IList<Item> items;
    private CharacterFactory characterFactory;
    private ItemFactory itemFactory;
    private int lastSurvivorRounds;

    public DungeonMaster()
    {
        this.items = new List<Item>();
        this.characters = new List<Character>();
        this.characterFactory = new CharacterFactory();
        this.itemFactory = new ItemFactory();
        this.lastSurvivorRounds = 0;
    }

    public string JoinParty(string[] args)
    {
        string faction = args[0];
        string type = args[1];
        string name = args[2];

        var newCharacter = this.characterFactory.CreateCharacter(faction, type, name);
        this.characters.Add(newCharacter);
        return string.Format(OutputMessage.CharacterJoinsParty, args[2]);
    }

    public string AddItemToPool(string[] args)
    {
        string name = args[0];
        var newItem = this.itemFactory.CreateItem(name);
        this.items.Add(newItem);
        return string.Format(OutputMessage.ItemAddedToPool, args[0]);
    }

    public string PickUpItem(string[] args)
    {
        var characterName = args[0];

        var currentCharacter = IsCharacterExist(characterName);
        var currentItem = this.items.LastOrDefault();
        if (currentItem == null)
        {
            throw new InvalidOperationException(string.Format(OutputMessage.NoItemLeftInThePool));
        }

        currentCharacter.Bag.AddItem(currentItem);
        this.items.Remove(currentItem);

        return string.Format(OutputMessage.CharacterPickedUpItem, currentCharacter.Name, currentItem.GetType().Name);
    }

    public string UseItem(string[] args)
    {
        var charName = args[0];
        var itemName = args[1];

        var currentCharacter = IsCharacterExist(charName);
        var currentItem = currentCharacter.Bag.GetItem(itemName);

        currentCharacter.UseItem(currentItem);

        return string.Format(OutputMessage.CharacterUseItem, charName, itemName);
    }

    public string UseItemOn(string[] args)
    {
        var giverName = args[0];
        var receiverName = args[1];
        var itemName = args[2];

        var giverCharacter = IsCharacterExist(giverName);
        var receiverCharacter = IsCharacterExist(receiverName);

        var itemFromGiverBag = giverCharacter.Bag.GetItem(itemName);
        if (itemFromGiverBag == null)
        {
            throw new ArgumentException(string.Format(OutputMessage.ItemNotFound, itemName));
        }

        giverCharacter.UseItemOn(itemFromGiverBag, receiverCharacter);

        return string.Format(OutputMessage.UseItemOnCharacter, giverName, itemName, receiverName);
    }

    public string GiveCharacterItem(string[] args)
    {
        var giverName = args[0];
        var receiverName = args[1];
        var itemName = args[2];

        var giverCharacter = IsCharacterExist(giverName);
        var receiverCharacter = IsCharacterExist(receiverName);

        var itemFromGiverBag = giverCharacter.Bag.GetItem(itemName);
        if (itemFromGiverBag == null)
        {
            throw new ArgumentException(string.Format(OutputMessage.ItemNotFound, itemName));
        }

        giverCharacter.GiveCharacterItem(itemFromGiverBag, receiverCharacter);

        return string.Format(OutputMessage.GiveItemToCharacter, giverName, receiverName, itemName);
    }

    public string GetStats()
    {
        var sb = new StringBuilder();
        var sortedCharacters = this.characters
            .OrderByDescending(x => x.IsAlive)
            .ThenByDescending(x => x.Health)
            .ToArray();

        foreach (var character in sortedCharacters)
        {
            sb.AppendLine(string.Format(OutputMessage.GetStats, character.Name, character.Health, character.BaseHealth, character.Armor, character.BaseArmor, (character.IsAlive ? "Alive" : "Dead")));
        }

        return sb.ToString().TrimEnd();
    }

    public string Attack(string[] args)
    {
        var sb = new StringBuilder();
        var attackerName = args[0];
        var receiverName = args[1];

        var attackerCharacter = IsCharacterExist(attackerName);
        var receiverCharacter = IsCharacterExist(receiverName);


        if (!(attackerCharacter is IAttackable attacker))
        {
            throw new ArgumentException(string.Format(OutputMessage.CharacterCannotAttack, attackerName));
        }


        attacker.Attack(receiverCharacter);

        sb.AppendLine(string.Format(OutputMessage.AttackSucceed, attackerName, receiverName,
                      attackerCharacter.AbilityPoints, receiverName, receiverCharacter.Health,
                      receiverCharacter.BaseHealth, receiverCharacter.Armor,
                      receiverCharacter.BaseArmor));

        if (!receiverCharacter.IsAlive)
        {
            sb.AppendLine($"{string.Format(OutputMessage.CharacterIsDead, receiverName)}");
        }

        return sb.ToString().TrimEnd();
    }

    public string Heal(string[] args)
    {
        var healerName = args[0];
        var healingReceiverName = args[1];

        var healerCharacter = IsCharacterExist(healerName);
        var healingReceiverCharacter = IsCharacterExist(healingReceiverName);

        if (!(healerCharacter is IHealable healer))
        {
            throw new ArgumentException(string.Format(OutputMessage.CannotHeal, healerName));
        }

        healer.Heal(healingReceiverCharacter);

        return string.Format(OutputMessage.Heal, healerName, healingReceiverName,
            healerCharacter.AbilityPoints, healingReceiverName, healingReceiverCharacter.Health);
    }

    public string EndTurn(string[] args)
    {
        var sb = new StringBuilder();
        var aliveCharacters = this.characters.Where(x => x.IsAlive).ToArray();
        foreach (var character in aliveCharacters)
        {
            var beforeRestHealth = character.Health;
            character.Rest();
            sb.AppendLine(string.Format(OutputMessage.Rest, character.Name, beforeRestHealth, character.Health));
        }

        if (aliveCharacters.Length == 1 || aliveCharacters.Length == 0)
        {
            this.lastSurvivorRounds++;
        }

        return sb.ToString().TrimEnd();
    }

    public bool IsGameOver()
    {
        if (this.lastSurvivorRounds > 1)
        {
            return true;
        }

        return false;
    }

    private Character IsCharacterExist(string characterName)
    {
        var currentCharacter = this.characters.FirstOrDefault(x => x.Name == characterName);
        if (currentCharacter == null)
        {
            throw new ArgumentException(string.Format(OutputMessage.CharacterNotFound, characterName));
        }

        return currentCharacter;
    }

    private Item IsItemExist(string itemName)
    {
        var currentItem = this.items.FirstOrDefault(x => x.GetType().Name == itemName);
        if (currentItem == null)
        {
            throw new ArgumentException(string.Format(OutputMessage.ItemNotFound, itemName));
        }

        return currentItem;
    }
}

