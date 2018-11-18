using ChefBox.SqlServer.Database;

namespace ChefBox.SharedBoundedContext.Repositories
{
    public abstract class ChefBoxRepository
    {
        public ChefBoxDbContext Context { get; }

        protected ChefBoxRepository(ChefBoxDbContext context)
        {
            Context = context;
        }

    }
}
