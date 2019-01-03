using System;
using System.Collections.Generic;
using System.Text;

namespace DungeonsAndCodeWizards.Models.OutputMessages
{
    public static class OutputMessages
    {
        public static string CharacterMustBeAlive => "Must be alive to perform this action!";
        public static string NameCannotBeNullOrWhiteSpace => "Name cannot be null or whitespace!";
        public static string BagIsFull => "Bag is full!";
        public static string BagIsEmpty => "Bag is empty!";
        public static string NoItemWithThisNameInTheBag => "No item with name {0} in bag!";
        public static string InvalidFaction => "Invalid faction \"{0}\"!";
        public static string InvalidCharacterType => "Invalid character type \"{0}\"!";
        public static string IvalidItemType => "Invalid item \"{0}\"!";
        public static string CharacterNotFound => "Character {0} not found!";
        public static string NoItemLeftInThePool => "No items left in pool!";
        public static string CannotAttackItSelf => "Cannot attack self!";
        public static string FriendlyFire => "Friendly fire! Both characters are from {0} faction!";
        public static string AttackerCannotAttack => "{0} cannot attack!";
        public static string AttackerSuccess => "{0} attacks {1} for {2} hit points! {3} has {4}/{5} HP and {6}/{7} AP left!";
        public static string ReceiverIsDead  => "{0} is dead!";
        public static string CannotHealEnemy => "Cannot heal enemy character!";
        public static string HealerConnotHeal => "{0} cannot heal!";
        public static string HealSeccess => "{0} heals {1} for {2}! {3} has {4} health now!";
        public static string Rest => "{0} rests ({1} => {2})"; 
    }
}
