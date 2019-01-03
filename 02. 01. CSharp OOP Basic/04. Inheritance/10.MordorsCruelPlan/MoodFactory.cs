using System;

public class MoodFactory
{
    private int points;

    public MoodFactory(int points)
    {
        this.Points = points;
    }

    protected int Points
    {
        get { return points; }
        set { points = value; }
    }

    public string GetMood()
    {
        if (this.Points < -5)
        {
            return "Angry";
        }
        else if (this.Points >= -5 && this.Points <= 0)
        {
            return "Sad";
        }
        else if (this.Points >= 1 && this.Points <= 15)
        {
            return "Happy";
        }
        else
        {
            return "JavaScript";
        }
    }
}

