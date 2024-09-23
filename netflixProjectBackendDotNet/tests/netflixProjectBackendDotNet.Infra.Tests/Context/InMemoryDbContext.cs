using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using netflixProjectBackendDotNet.Infra.Context;

namespace netflixProjectBackendDotNet.Infra.Tests.Context;

public abstract class InMemoryDbContext
{
    protected readonly ContextDB Database;
    public InMemoryDbContext()
    {
        var contextOptions = new DbContextOptionsBuilder<ContextDB>()
            .UseInMemoryDatabase("NetflixDatabaseTest")
            .ConfigureWarnings(b => b.Ignore(InMemoryEventId.TransactionIgnoredWarning))
            .Options;

        using var context = new ContextDB(contextOptions);

        context.Database.EnsureDeleted();
        context.Database.EnsureCreated();

        Database = context;
    }
}
