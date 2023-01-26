using System;
using SQLite;
namespace DnavarreteS7
{
	public interface DataBase
	{
		SQLiteAsyncConnection GetConnection();

	}
}

