using System;
using System.Collections.Generic;

public abstract class Command : ICommand
{
    private IHarvesterController harvesterController;
    private IProviderController providerController;

    protected Command(IList<string> args, IHarvesterController harvesterController, IProviderController providerController)
    {
        this.Arguments = args;
        this.harvesterController = harvesterController;
        this.providerController = providerController;
    }

    public IList<string> Arguments { get; protected set; }
    protected IHarvesterController HarvesterController => this.harvesterController;
    protected IProviderController ProviderController => this.providerController;

    public abstract string Execute();
}

