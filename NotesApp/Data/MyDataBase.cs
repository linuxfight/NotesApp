using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.Sqlite;
using NotesApp.Models;
using System.Data;

namespace NotesApp.Data
{
	public class MyDataBase
	{
		private IConfiguration _configuration;

		public MyDataBase(IConfiguration configuration) 
		{
			_configuration = configuration;
		}

		public DataTable GetNotes()
		{
			using (var connection = new SqliteConnection(_configuration.GetConnectionString("SqliteConnection")))
			{
				connection.Open();
				var command = new SqliteCommand("SELECT * FROM Notes", connection);
				var reader = command.ExecuteReader();
				var table = new DataTable();
				table.Load(reader);
				connection.Close();
				return table;
			}
		}

		public void AddNote(string title, string message)
		{
			using (var connection = new SqliteConnection(_configuration.GetConnectionString("SqliteConnection")))
			{
				connection.Open();
				var command = new SqliteCommand($"INSERT INTO Notes (Title, Message) VALUES ('{title}', '{message}');", connection);
				command.ExecuteNonQuery();
				connection.Close();
			}
		}

		public DataRow? GetNote(int id)
		{
			using (var connection = new SqliteConnection(_configuration.GetConnectionString("SqliteConnection")))
			{
				connection.Open();
				var command = new SqliteCommand($"SELECT * FROM Notes WHERE Id = {id}", connection);
				var reader = command.ExecuteReader();
				var table = new DataTable();
				table.Load(reader);
				connection.Close();
				if (table.Rows.Count > 0)
				{
					return table.Rows[0];
				}
				return null;
			}
		}

		public void EditNote(int id, string title, string message)
		{
			using (var connection = new SqliteConnection(_configuration.GetConnectionString("SqliteConnection")))
			{
				connection.Open();
				var command = new SqliteCommand($"UPDATE Notes SET Title = '{title}', Message = '{message}' WHERE Id = {id}", connection);
				command.ExecuteNonQuery();
				connection.Close();

				/*
				 * OR
				 * var command = new SqliteCommand("UPDATE Notes SET Title = @Title, Message = @Message WHERE Id = @Id", connection);
				 * command.Parameters.AddWithValue("@Id", id);
				 * command.Parameters.AddWithValue("@Title", title);
				 * command.Parameters.AddWithValue("@Message", message);
				*/
			}
		}

		public void DeleteNote(int id)
		{
			using (var connection = new SqliteConnection(_configuration.GetConnectionString("SqliteConnection")))
			{
				connection.Open();
				var command = new SqliteCommand($"DELETE FROM Notes WHERE Id = {id}", connection);
				command.ExecuteNonQuery();
				connection.Close();
			}
		}
	}
}
