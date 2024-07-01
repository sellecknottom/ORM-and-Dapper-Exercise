using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using Dapper;
using Mysqlx.Crud;

namespace ORM_Dapper
{
    public class DapperProductsRepository
    {
        private readonly IDbConnection _connection;
        //Constructor
        public DapperProductsRepository(IDbConnection connection)
        {
            _connection = connection;
        }
        public IEnumerable<Products> GetAllProducts()
        {
            return _connection.Query<Products>("SELECT * FROM Products;");
        }
        public void InsertProducts(string newProductsName)
        {
            _connection.Execute("INSERT INTO PRODUCTS (Name) VALUES (@productsName);",
             new { productsName = newProductsName });
        }
        public void DeleteProduct(string productsName)
        {
            _connection.Execute(@"BEGIN TRANSACTION;
            DELETE FROM Products WHERE ProductID = @ProductID;
            DELETE FROM Sales WHERE ProductID = @ProductID;
            DELETE FROM Reviews WHERE ProductID = @ProductID;
            COMMIT;");
        }
    }
}
