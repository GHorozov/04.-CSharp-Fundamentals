namespace DungeonsAndCodeWizards.Core.Interfaces
{
    using DungeonsAndCodeWizards.Models.Characters;
    using System;

    public interface IHealable
    {
        void Heal(Character character);
    }
}
