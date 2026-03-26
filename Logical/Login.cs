using Projeto.Data;
using MySql.Data.MySqlClient;

namespace Projeto.Logical
{
    public class LoginService
    {
        private Database db = new Database();

        public bool ValidarLogin(string usuario, string senha)
        {
            using (var con = db.GetConnection())
            {
                con.Open();

                string query = "SELECT COUNT(*) FROM user_tb WHERE usuario = @user AND senha = @pass";

                using (var cmd = new MySqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@user", usuario);
                    cmd.Parameters.AddWithValue("@pass", senha);

                    return Convert.ToInt32(cmd.ExecuteScalar()) > 0;
                }
            }
        }
    }
}