﻿namespace _04.Recharge
{
    using System;

    public class Robot : Worker
    {
        private int capacity;
        private int currentPower;

        public Robot(string id, int capacity) : base(id)
        {
           this.capacity = capacity;
        }

        public int Capacity
        {
            get { return this.capacity; }
        }

        public int CurrentPower
        {
            get { return this.currentPower; }
            set { this.currentPower = value; }
        }

        public void Work(int hours)
        {
            if (hours > this.currentPower)
            {
                hours = currentPower;
            }

            base.Work(hours);
            this.currentPower -= hours;
        }
   
        public void Recharge()
        {
            this.CurrentPower = this.Capacity;
        }
    }
}