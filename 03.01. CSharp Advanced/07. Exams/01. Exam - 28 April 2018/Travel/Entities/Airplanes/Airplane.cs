namespace Travel.Entities.Airplanes
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Collections.Immutable;
    using System.Linq;
    using Entities.Contracts;
    using Travel.Entities.Airplanes.Contracts;

    // migrated from java. please do the needful kind sir
    public abstract class Airplane :IAirplane
    {
        private List<IBag> baggageCompartment;
        private List<IPassenger> passengers;

        public Airplane(int seats, int baggageCompartments)
        {
            this.Seats = seats;
            this.BaggageCompartments = baggageCompartments;
            this.baggageCompartment = new List<IBag>();
            this.passengers = new List<IPassenger>();
        }

        public int Seats { get; }
        public int BaggageCompartments { get; }
        public IReadOnlyCollection<IBag> BaggageCompartment => this.baggageCompartment;
        public IReadOnlyCollection<IPassenger> Passengers => this.passengers;
        public bool IsOverbooked => this.Passengers.Count > this.Seats;

        public void AddPassenger(IPassenger passenger)
        {
            this.passengers.Add(passenger);
        }

        public IPassenger RemovePassenger(int seatIndex)
        {
            var passenger = this.passengers[seatIndex];
            this.passengers.RemoveAt(seatIndex);

            return passenger;
        }

        public IEnumerable<IBag> EjectPassengerBags(IPassenger passenger)
        {
            var passengerBags = this.baggageCompartment
                .Where(b => b.Owner == passenger)
                .ToArray();

            foreach (var bag in passengerBags)
            {
                this.baggageCompartment.Remove(bag);
            }

            return passengerBags;
        }

        public void LoadBag(IBag bag)
        {
            var isBaggageCompartmentFull = this.baggageCompartment.Count > this.BaggageCompartments;
            if (isBaggageCompartmentFull)
                throw new InvalidOperationException($"No more bag room in {this.GetType().Name}!");

            this.baggageCompartment.Add(bag);
        }
    }
}