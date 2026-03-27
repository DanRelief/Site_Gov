using MySql.Data.MySqlClient;
using Projeto.Data;
using Projeto.Models;

namespace Projeto.Logical
{
	public class PontoDoacaoService
	{
		private Database db = new Database();

		public void Criar(PontoDoacao ponto)
		{
			using (var con = db.GetConnection())
			{
				con.Open();

				string query = @"INSERT INTO ponto_doacao 
                (rua, numero, cep, itens, quantidades) 
                VALUES (@rua, @numero, @cep, @itens, @quantidades)";

				using (var cmd = new MySqlCommand(query, con))
				{
					cmd.Parameters.AddWithValue("@rua", ponto.Rua);
					cmd.Parameters.AddWithValue("@numero", ponto.Numero);
					cmd.Parameters.AddWithValue("@cep", ponto.CEP);
					cmd.Parameters.AddWithValue("@itens", ponto.Itens);
					cmd.Parameters.AddWithValue("@quantidades", ponto.Quantidades);

					cmd.ExecuteNonQuery();
				}
			}
		}
	}
}