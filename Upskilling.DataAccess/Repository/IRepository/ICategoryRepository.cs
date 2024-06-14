using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Upskilling.Models;

namespace Upskilling.DataAccess.Repository.IRepository
{
	public interface ICategoryRepository: IRepository<Category>
	{
		void Update(Category obj);
	}
}
