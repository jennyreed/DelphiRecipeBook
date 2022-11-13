using System;
using System.Collections.Generic;
using System.Text;
using SQLite;
using System.Threading.Tasks;
using System.Collections;

namespace DelphiRecipeBook
{
    public class Database
    {
      private readonly SQLiteAsyncConnection _database;

      public Database(string dbPath)
        {
            _database = new SQLiteAsyncConnection(dbPath);
            _database.CreateTableAsync<Recipe>();
        }

        public Task<List<Recipe>> GetRecipeAsync()
        {
            return _database.Table<Recipe>().ToListAsync();
        }

        public Task<int> SaveRecipeAsync(Recipe recipe)
        {
            return _database.InsertAsync(recipe);
        }

       public Task<int> UpdateRecipeAsync(Recipe recipe)
        { 
            return _database.UpdateAsync(recipe); 
        }

        public Task<int> DeleteRecipeAsync(Recipe recipe)
        {
            return _database.DeleteAsync(recipe);
        }
    }
}
