namespace AnimalCentre.Models.Contracts
{
    using global::AnimalCentre.Models.Procedures;
    using System;
    using System.Collections.Generic;
    using System.Text;
    public interface IProcedureFactory
    {
        Procedure CreateProcedure(string procedureType);
    }
}
