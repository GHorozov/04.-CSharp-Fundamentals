namespace AnimalCentre.Factories
{
    using global::AnimalCentre.Models.Contracts;
    using global::AnimalCentre.Models.Procedures;
    using System;

    public class ProcedureFactory :IProcedureFactory
    {
        public Procedure CreateProcedure(string procedureType)
        {
            Procedure procedure = null;
            switch (procedureType)
            {
                case "Chip":
                    procedure = new Chip();
                    break;
                case "DentalCare":
                    procedure = new DentalCare();
                    break;
                case "Fitness":
                    procedure = new Fitness();
                    break;
                case "NailTrim":
                    procedure = new NailTrim();
                    break;
                case "Play":
                    procedure = new Play();
                    break;
                case "Vaccinate":
                    procedure = new Vaccinate();
                    break;
                default:
                    throw new InvalidOperationException("Invalid procedure!");
            }

            return procedure;
        }
    }
}
