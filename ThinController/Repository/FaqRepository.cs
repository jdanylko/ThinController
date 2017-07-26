using System.Data.Entity;
using ThinController.EntityFramework;
using ThinController.Infrastructure;

namespace ThinController.Repository
{
    public class FaqRepository: Repository<FAQ>
    {
        public FaqRepository(DbContext context) : base(context)
        {
        }
    }
}