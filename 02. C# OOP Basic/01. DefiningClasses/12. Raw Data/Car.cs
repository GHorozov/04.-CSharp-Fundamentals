using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class Car
{
    private string model;
    private Engine engine;
    private Cargo cargo;
    private Tire[] tires;

    public Car(string model, Engine engine, Cargo cargo, Tire[] tires)
    {
        if(tires.Length != 4)
        {
            throw new Exception("Tire should be 4!");
        }
        this.model = model;
        this.engine = engine;
        this.cargo = cargo;
        this.tires = tires;
    }

    public string Model
    {
        get { return this.model; }
        set { this.model = value; }
    }
    public Engine Engine
    {
        get { return this.engine; }
        set { this.engine = value; }
    }
    public Cargo Cargo
    {
        get { return this.cargo; }
        set { this.cargo = value; }
    }
    public Tire[] Tires
    {
        get { return this.tires; }
        set { this.tires = value; }
    }
}

