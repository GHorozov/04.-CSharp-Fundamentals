using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class Tomcat : Animal
{
    public Tomcat(string name, int age, string gender) : base(name, age, "Male")
    {

    }

    public override string ProduceSound()
    {
        return "Give me one million b***h";
    }
}

