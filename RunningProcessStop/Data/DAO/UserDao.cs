using RunningProcessStop.Models;
namespace RunningProcessStop.Data.DAO
{
    public class UserDao
    {
        
        public List<User> Get()
        {
           
            List<User> users = new List<User>();
            string sql = "SELECT a.user_id, ip, c.username, c.email FROM hoster_dedicated_users a \r\nLEFT JOIN hoster_payments b ON a.user_id = b.user_id\r\nLEFT JOIN hoster_users c ON a.user_id = c.id\r\nWHERE next_confirm < NOW() ORDER BY next_confirm DESC;";
            try
            {
                var reader = ConnectionFactory.ExecuteCommandReader(sql);
                while (reader.Read())
                {
                   User user = new User()
                    {
                        UserId = int.Parse(reader["user_id"].ToString()!),
                        Ip = reader["ip"].ToString()!,
                        Username = reader["username"].ToString(),
                        Email = reader["email"].ToString()
                    };
                    users.Add(user);
                }
            }
            catch
            {
                return null;
            }
           

            return users;
        }
    }
}
