using System;

public class Player
{
    private string name;
    private double stats;
    private double endurance;
    private double sprint;
    private double dribble;
    private double passing;
    private double shooting;


    public Player(string name, double endurance, double sprint, double dribble, double passing, double shooting)
    {
        this.Name = name;
        this.Endurance = endurance;
        this.Sprint = sprint;
        this.Dribble = dribble;
        this.Passing = passing;
        this.Shooting = shooting;
    }

    public double Stats
    {
        get
        {
            var totalStats = (endurance + sprint + dribble + passing + shooting) / 5;
            return totalStats;
        }
    }

    public string Name
    {
        get
        {
            return name;
        }

        private set
        {
            if (value.Length == 0 || value == " ")
            {
                throw new ArgumentException("A name should not be empty.");
            }

            this.name = value;
        }
    }

    private double Endurance
    {
        get
        {
            return endurance;
        }

        set
        {
            if (IsValidSkill(value))
            {
                throw new ArgumentException($"{nameof(this.Endurance)} should be between 0 and 100.");
            }

            this.endurance = value;
        }
    }

    private double Sprint
    {
        get
        {
            return sprint;
        }

        set
        {
            if (IsValidSkill(value))
            {
                throw new ArgumentException($"{nameof(this.Sprint)} should be between 0 and 100.");
            }

            this.sprint = value;
        }
    }

    private double Dribble
    {
        get
        {
            return dribble;
        }

        set
        {
            if (IsValidSkill(value))
            {
                throw new ArgumentException($"{nameof(this.Dribble)} should be between 0 and 100.");
            }

            this.dribble = value;
        }
    }

    private double Passing
    {
        get
        {
            return passing;
        }

        set
        {
            if (IsValidSkill(value))
            {
                throw new ArgumentException($"{nameof(Passing)} should be between 0 and 100.");
            }

            this.passing = value;
        }
    }

    private double Shooting
    {
        get
        {
            return shooting;
        }

        set
        {
            if (IsValidSkill(value))
            {
                throw new ArgumentException($"{nameof(Shooting)} should be between 0 and 100.");
            }

            this.shooting = value;
        }
    }

    private bool IsValidSkill(double value)
    {
        return value < 0 || value > 100;
    }
}