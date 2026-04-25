using MySql.Data.MySqlClient;
using MCMV.Data;

namespace MCMV.Logical
{
    public class RegisterService
    {
        private readonly Database _db;

        // Construtor: O ASP.NET vai entregar o Database configurado aqui
        public RegisterService(Database db)
        {
            _db = db;
        }

        public bool UsuarioExiste(string documento)
        {
            using (var con = _db.GetConnection())
            {
                con.Open();
                string query = "SELECT COUNT(*) FROM user_tb WHERE documento = @doc";

                using (var cmd = new MySqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@doc", documento);
                    return Convert.ToInt32(cmd.ExecuteScalar()) > 0;
                }
            }
        }

        public void CriarUsuario(string user, string senha, string email, string doc)
        {
            using (var con = _db.GetConnection())
            {
                con.Open();
                string query = "INSERT INTO user_tb (usuario, senha, email, documento) VALUES (@user, @pass, @mail, @doc)";

                using (var cmd = new MySqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@user", user);
                    cmd.Parameters.AddWithValue("@pass", senha);
                    cmd.Parameters.AddWithValue("@mail", email);
                    cmd.Parameters.AddWithValue("@doc", doc);

                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}