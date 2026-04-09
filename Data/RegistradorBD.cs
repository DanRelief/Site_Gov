using MySql.Data.MySqlClient;

namespace Projeto.Data
{
    public class RegisterService
    {
        private Database db = new Database();

        public bool UsuarioExiste(string usuario)
        {
            using (var con = db.GetConnection())
            {
                con.Open();

                string query = "SELECT COUNT(*) FROM user_tb WHERE usuario = @user";

                using (var cmd = new MySqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@user", usuario);
                    return Convert.ToInt32(cmd.ExecuteScalar()) > 0;
                }
            }
        }

        public void CriarUsuario(string user, string senha, string email, string doc)
        {
            using (var con = db.GetConnection())
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