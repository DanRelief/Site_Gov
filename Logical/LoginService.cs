namespace MCMV.Logical
{
    public class LoginService
    {
        private readonly Data.Database _db;

        public LoginService(Data.Database db)
        {
            _db = db;
        }

        public bool ValidarLogin(string documento, string senha)
        {
            using (var con = _db.GetConnection())
            {
                con.Open();
                string query = "SELECT COUNT(*) FROM user_tb WHERE documento = @doc AND senha = @pass";
                using (var cmd = new MySql.Data.MySqlClient.MySqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@doc", documento);
                    cmd.Parameters.AddWithValue("@pass", senha);
                    return Convert.ToInt32(cmd.ExecuteScalar()) > 0;
                }
            }
        }
        public string ObterTipoUsuario(string documento)
        {
            // Remove pontos/traços para contar apenas números
            var apenasNumeros = new string(documento.Where(char.IsDigit).ToArray());

            if (apenasNumeros.Length == 11) return "CPF";
            if (apenasNumeros.Length == 14) return "CNPJ";
            return "Desconhecido";
        }

    }
}