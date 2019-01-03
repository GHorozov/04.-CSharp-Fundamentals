using System;

public class Mission : IMission
{
    private string state;

    public Mission(string codeName, string state)
    {
        this.CodeName = codeName;
        this.State = state;
    }

    public string CodeName { get; set; }

    public string State
    {
        get
        {
            return state;
        }

        set
        {
            if(value != "inProgress" && value != "Finished")
            {
                throw new ArgumentException("Invalid Mission.");
            }
            state = value;
        }
    }

    public void CompleteMission()
    {
        //to do...
    }

    public override string ToString()
    {
        return $"  Code Name: {CodeName} State: {State}";
    }

}