using System.Collections.Generic;
using StructureMap;
using StructureMap.Pipeline;

namespace ThinController.UnitOfWork
{
    public class PrimaryUnitOfWork : AbstractUnitOfWork
    {
        // TODO: Add Entity Framework for your repositories
        // private readonly DbContext _context;

        // public PrimaryUnitOfWork(): this(new DbContext()) { }

        // public PrimaryUnitOfWork(DbContext context)
        // {
        //     _context = context;
        // }

        public T GetRepository<T>() where T : class
        {
            // var result = null;

            var container = new Container(_ =>
                _.Scan(e =>
                {
                    e.AssembliesFromApplicationBaseDirectory();
                    e.AddAllTypesOf<AbstractUnitOfWork>();
                }));

            var args = new ExplicitArguments();
            // args.Set<DbContext>(_context);

            return container.GetInstance<T>(args);

            // Optional: return an error instead of a null?
            //var msg = typeof (T).FullName + " doesn't implement the IBlogModule.";
            //throw new Exception(msg);
        }

        public void Commit()
        {
            // _context.SaveChanges();
        }
        public void Rollback()
        {
            //_context
            //    .ChangeTracker
            //    .Entries()
            //    .ToList()
            //    .ForEach(x => x.Reload());
        }

        public void Dispose()
        {
            //if (_context != null)
            //{
            //    _context.Dispose();
            //}
        }
    }
}