using _02BlackBoxInteger;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

public class StartUp
{
    public static void Main(string[] args)
    {
        Type classType = typeof(BlackBoxInt);

        //ConstructorInfo blackBoxCtor = classType.GetConstructor(
        //BindingFlags.Instance | BindingFlags.NonPublic, Type.DefaultBinder, new Type[] {}, null); // I -way -> Take the empty constr of class BlackBoxInt.

        BlackBoxInt blackBoxCtor = (BlackBoxInt)Activator.CreateInstance(classType, true); // II-way -> take emty ctor of class BlackBoxInt.

        string input;
        while ((input = Console.ReadLine()) != "END")
        {
            var tokens = input.Split('_');
            var methodName = tokens[0];
            var value = int.Parse(tokens[1]);

            classType.GetMethod(methodName, BindingFlags.Instance | BindingFlags.NonPublic).Invoke(blackBoxCtor, new object[] { value });
            //Call current method and invoke him with current value


            //Take value of field after above method invoked.
            string innerStateValue = classType.GetFields(BindingFlags.Instance | BindingFlags.NonPublic)
                .First()
                .GetValue(blackBoxCtor)
                .ToString();

            Console.WriteLine(innerStateValue);
        }
    }
}