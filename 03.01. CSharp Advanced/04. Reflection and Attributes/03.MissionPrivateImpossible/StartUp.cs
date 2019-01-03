namespace _03.MissionPrivateImpossible
{
    using System;

    class StartUp
    {
        static void Main(string[] args)
        {
            var spy = new Spy();
            var result = spy.RevealPrivateMethods("Hacker");
            Console.WriteLine(result);
        }
    }
}
