using System.Collections.Generic;
using SQLite;
using Proiect_Telefon.Models;
using System.Collections;

namespace Proiect_Telefon.Data
{
    public class ShoppingCartDatabase
    {
        readonly SQLiteAsyncConnection _database;

        public ShoppingCartDatabase(string dbPath)
        {
            _database = new SQLiteAsyncConnection(dbPath);
            _database.CreateTableAsync<ProductList>().Wait();
            _database.CreateTableAsync<Produs>().Wait();
            _database.CreateTableAsync<ListaProdus>().Wait();
        }

        // Renamed GetProductListsAsync to GetShopListsAsync
        public Task<List<ProductList>> GetShopListsAsync()
        {
            return _database.Table<ProductList>().ToListAsync();
        }

        public Task<ProductList> GetProductListAsync(int id)
        {
            return _database.Table<ProductList>()
                            .Where(i => i.ID == id)
                            .FirstOrDefaultAsync();
        }

        public Task<int> SaveProductListAsync(ProductList plist)
        {
            if (plist.ID != 0)
            {
                return _database.UpdateAsync(plist);
            }
            else
            {
                return _database.InsertAsync(plist);
            }
        }

        public Task<int> DeleteProductListAsync(ProductList plist)
        {
            return _database.DeleteAsync(plist);
        }
        public Task<int> SaveProductAsync(Produs produs)
        {
            if (produs.ID != 0)
            {
                return _database.UpdateAsync(produs);
            }
            else
            {
                return _database.InsertAsync(produs);
            }
        }
        public Task<int> DeleteProductAsync(Produs produs)
        {
            return _database.DeleteAsync(produs);
        }
        public Task<List<Produs>> GetProductsAsync()
        {
            return _database.Table<Produs>().ToListAsync();
        }

        public Task SaveProductListAsync(ListaProdus listp)
        {
            if (listp.ID != 0)
            {
                return _database.UpdateAsync(listp);
            }
            else
            {
                return _database.InsertAsync(listp);
            }
        }
        public Task<int> SaveListProductAsync(ListaProdus listp)
        {
            if (listp.ID != 0)
            {
                return _database.UpdateAsync(listp);
            }
            else
            {
                return _database.InsertAsync(listp);
            }
        }
        public Task<List<Produs>> GetListProductsAsync(int shoplistid)
        {
            return _database.QueryAsync<Produs>(
            "select P.ID, P.Description from Produs P"
            + " inner join ListaProdus LP"
            + " on P.ID = LP.ProductID where LP.ShopListID = ?",
            shoplistid);
        }
        public Task<int> DeleteItemFromShopListAsync(int productId, int shopListId)
        {
            return _database.Table<ListaProdus>()
                .Where(lp => lp.ProductID == productId && lp.ShopListID == shopListId)
                .DeleteAsync();
        }

    }
}
 
