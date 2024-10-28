using MySql.Data.MySqlClient;

namespace RunningProcessStop.Data
{
    public static class ConnectionFactory
    {
        static MySqlConnection conexao = null;

        public static MySqlConnection Connect()
        {
            try
            {

                string conn = @"Persist Security info = false;
                                server = localhost;
                                database = teste;
                                uid = brunohoske;
                                port= 3307;
                                pwd =123";

                conexao = new MySqlConnection(conn);
                conexao.Open();
            }
            catch (MySqlException)
            {
                throw new Exception("An error occurred while connecting to the database.");
            }

            return conexao;
        }

        public static MySqlDataReader ExecuteCommandReader(string sql)
        {
            try
            {
                using MySqlCommand cmd = new MySqlCommand(sql, conexao = Connect());
                var reader = cmd.ExecuteReader();
                return reader;
            }
            catch (Exception ex)
            {
                return null;
            }


        }
        public static void CloseConnection()
        {
            if (conexao != null && conexao.State == System.Data.ConnectionState.Open)
            {
                conexao.Close();
            }


        }
    }
}
