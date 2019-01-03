using System;

public static class OutputMessage
{
    public static string InvalidName => "Name cannot be null or whitespace!";
    
    public static string  CharacterMustBeAlive => "Must be alive to perform this action!";

    public static string BagIsFull => "Bag is full!";

    public static string BagIsEmpty => "Bag is empty!";

    public static string NoItemWithName => "No item with name {0} in bag!";

    public static string CannotAttackItSelf => "Cannot attack self!";

    public static string FrendlyFire => "Friendly fire! Both characters are from {0} faction!";

    public static string CannotHealEnemy => "Cannot heal enemy character!";

    public static string InvalidFaction => "Invalid faction \"{0}\"!";

    public static string InvalidCharacter => "Invalid character type \"{0}\"!";

    public static string CharacterJoinsParty => "{0} joined the party!";

    public static string InvalidItem => "Invalid item \"{0}\"!";

    public static string ItemAddedToPool => "{0} added to pool.";

    public static string CharacterNotFound => "Character {0} not found!";

    public static string NoItemLeftInThePool => "No items left in pool!";

    public static string CharacterPickedUpItem => "{0} picked up {1}!";

    public static string CharacterUseItem => "{0} used {1}.";

    public static string ItemNotFound => "{0} not found!";

    public static string UseItemOnCharacter => "{0} used {1} on {2}.";

    public static string GiveItemToCharacter => "{0} gave {1} {2}.";

    public static string CharacterCannotAttack => "{0} cannot attack!";

    public static string CharacterIsDead => "{0} is dead!";

    public static string AttackSucceed => "{0} attacks {1} for {2} hit points! {3} has {4}/{5} HP and {6}/{7} AP left!";

    public static string Heal => "{0} heals {1} for {2}! {3} has {4} health now!";

    public static string CannotHeal => "{0} cannot heal!";

    public static string Rest => "{0} rests ({1} => {2})";

    public static string FinalStats => "Final stats:";

    public static string GetStats => "{0} - HP: {1}/{2}, AP: {3}/{4}, Status: {5}";
}

