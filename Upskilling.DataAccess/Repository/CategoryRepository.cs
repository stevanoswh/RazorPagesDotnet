using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Upskilling.DataAccess.Data;
using Upskilling.DataAccess.Repository.IRepository;
using Upskilling.Models;

namespace Upskilling.DataAccess.Repository
{
    internal class CategoryRepository : Repository<Category>, ICategoryRepository
    {
        private ApplicationDbContext _db;
        public CategoryRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(Category obj)
        {
            throw new NotImplementedException();
        }
    }
}
