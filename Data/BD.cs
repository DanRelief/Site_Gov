namespace Projeto.Data
{
    using MySql.Data.MySqlClient;

    public class Database
    {
        private string connectionString = "server=localhost;database=registro;uid=root;pwd=1234;";

        public MySqlConnection GetConnection()
        {
            return new MySqlConnection(connectionString);
        }
    }
}