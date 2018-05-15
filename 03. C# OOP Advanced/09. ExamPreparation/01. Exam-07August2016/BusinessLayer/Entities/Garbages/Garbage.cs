namespace _01.Exam_07August2016.BusinessLayer.Entities.Garbages
{
    using System;
    using RecyclingStation.WasteDisposal.Interfaces;

    public abstract class Garbage : IWaste
    {
        private string name;
        private double volumePerKg;
        private double weight;

        public Garbage(string name, double weight, double volumePerKg)
        {
            this.Name = name;
            this.VolumePerKg = volumePerKg;
            this.Weight = weight;
        }

        public string Name { get => name; set => name = value; }

        public double VolumePerKg
        {
            get
            {
                return this.volumePerKg;
            }
            set
            {
                this.volumePerKg = value;
            }
        }

        public double Weight
        {
            get
            {
                return this.weight;
            }
            set
            {
                this.weight = value;
            }

        }      
    }
}
