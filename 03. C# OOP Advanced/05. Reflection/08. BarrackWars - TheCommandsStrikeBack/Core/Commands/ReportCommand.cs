using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using _03BarracksFactory.Contracts;

public class ReportCommand : Command
{
    [Inject]
    private IRepository repository;

    public ReportCommand(string[] data) : base(data)
    {
    }

    public override string Execute() => this.repository.Statistics;
}
