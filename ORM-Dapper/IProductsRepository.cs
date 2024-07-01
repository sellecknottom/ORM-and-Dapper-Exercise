using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;

namespace ORM_Dapper
{
    public interface IProductsRepository
    {
        public IEnumerable<Products> GetAllProducts(); //Stubbed out method
    }
}
