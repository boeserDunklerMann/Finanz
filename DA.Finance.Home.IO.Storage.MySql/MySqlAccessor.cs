using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace DA.Finance.Home.IO.Storage.MySql
{
	public sealed class MySqlAccessor : Contracts.IDataAccessor
	{
#if DEBUG
		private const string CONNECTIONSTRING = @"server=Meereen;User Id=finance;database=DA_Finance_Home;Password=finance;Allow Zero Datetime=True;pooling=False; Ssl Mode = Preferred;";
#else
#endif
		private MySqlConnection _conn;

		public MySqlAccessor()
		{
			_conn = new MySqlConnection(CONNECTIONSTRING);
		}

		public string ConnectedDatasource => $"{_conn.DataSource}.{_conn.Database}";

		private string LoadData(string tableName, string dataColumn, string idColumn)
		{
			string retval = "";
			_conn.Open();
			try
			{
				using (MySqlCommand cmd = new MySqlCommand($"Select {dataColumn} from {tableName} where " +
					$"{idColumn}=1", _conn))
				{
					using (MySqlDataReader rdr = cmd.ExecuteReader())
					{
						while (rdr.Read())
						{
							retval = rdr[dataColumn].ToString();
						}
					}
				}
			}
			catch
			{
				throw;
			}
			finally
			{
				_conn.Close();
			}
			return retval;
		}

		public string LoadArtikelKategorien()
		{
			return LoadData("ArtikelKategorien", "AK_Data", "AK_ID");
		}

		public string LoadEinkaufs()
		{
			return LoadData("Einkaufs", "E_Data", "E_ID");
		}

		public string LoadShopKategorien()
		{
			return LoadData("ShopKategorien", "SK_Data", "SK_ID");
		}

		public string LoadZahlungsmittels()
		{
			return LoadData("Zahlungsmittel", "Z_Data", "Z_ID");
		}

		public void WriteArtikelKategorien(string data)
		{
			WriteData("ArtikelKategorien", "AK_Data", "AK_ID", data);
		}

		public void WriteEinkaufs(string data)
		{
			WriteData("Einkaufs", "E_Data", "E_ID", data);
		}

		public void WriteShopKatekorien(string data)
		{
			WriteData("ShopKategorien", "SK_Data", "SK_ID", data);
		}

		public void WriteZahlungsmittels(string data)
		{
			WriteData("Zahlungsmittel", "Z_Data", "Z_ID", data);
		}

		private void WriteData(string tableName, string dataColumn, string idColumn, string data)
		{
			MySqlParameter dataParam = new MySqlParameter("@data", MySqlDbType.Text);
			dataParam.Value = data;
			_conn.Open();
			try
			{
				using (MySqlCommand cmd = new MySqlCommand())
				{
					cmd.Connection = _conn;
					cmd.Parameters.Add(dataParam);
					cmd.CommandText = $"Update {tableName} Set {dataColumn} = @data where {idColumn}=1";
					cmd.ExecuteNonQuery();
				}
			}
			catch
			{
				throw;
			}
			finally
			{
				_conn.Close();
			}
		}
	}
}
