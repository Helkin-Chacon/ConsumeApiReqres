using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using UsingApi.Models;

namespace UsingApi.Services
{
	public class LocalDataBaseContext
	{
		public readonly SQLite.SQLiteAsyncConnection database;
		public LocalDataBaseContext(string dbPath)
		{
			database = new SQLite.SQLiteAsyncConnection(dbPath);
			database.CreateTableAsync<UserModel>().Wait();
			
		}
		public async Task<List<T>> GetAllAsync<T>() where T : new()
		{
			return await database.Table<T>().ToListAsync();
		}
		public async Task<T> GetItemAsync<T>(string id) where T : new()
		{
			return await database.FindAsync<T>(id);
		}
		public async Task<int> SaveItemAsync<T>(T item) where T : new()
		{
			return	await database.InsertAsync(item);
		}
		public async Task DeleteItemAsync<T>() where T : new()
		{
			 await database.DeleteAllAsync<T>();
		}

	}
}
