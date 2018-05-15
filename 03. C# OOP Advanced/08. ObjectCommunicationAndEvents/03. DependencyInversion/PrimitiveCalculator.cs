using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class PrimitiveCalculator
{
    private IStartegy strategy;

    private Dictionary<char, IStartegy> strategies = new Dictionary<char, IStartegy>()
    {
        {'+', new AdditionStrategy()},
        {'-', new SubtractionStrategy()},
        {'/', new DevideStrategy()},
        {'*', new MultiplyStrategy()}
    };

    public PrimitiveCalculator()
    {
        this.strategy = this.strategies['+'];
    }

    public PrimitiveCalculator(IStartegy strategy) //II-way to set operator. Just add in defald startegy when  I make instance.
    {
        this.strategy = strategy;
    }

    public void ChangeStrategy(char @operator)
    {
        this.strategy = this.strategies[@operator];
    }

    public int PerformCalculation(int firstOperand, int secondOperand)
    {
        return this.strategy.Calculate(firstOperand, secondOperand);
    }
}

