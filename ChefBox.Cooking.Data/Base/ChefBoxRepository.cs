using ChefBox.SqlServer.Database;

namespace ChefBox.Cooking.Data.Base
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
