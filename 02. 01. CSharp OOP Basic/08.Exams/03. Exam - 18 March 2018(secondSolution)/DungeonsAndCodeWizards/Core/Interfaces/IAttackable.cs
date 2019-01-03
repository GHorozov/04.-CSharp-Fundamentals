namespace DungeonsAndCodeWizards.Core.Interfaces
{
    using DungeonsAndCodeWizards.Models.Characters;
    using System;
    using System.Collections.Generic;
    using System.Text;

    public interface IAttackable
    {
        void Attack(Character character);
    }
}
