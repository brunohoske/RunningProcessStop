using RunningProcessStop.Data.DAO;
using RunningProcessStop.DTO;
using RunningProcessStop.Models;
using System.Text.Json;
using System.Net.Mail;

namespace RunningProcessStop.Client
{
    public class ProcessClient : BaseClient
    {
        public ProcessClient() { }

        public async Task<List<User>> StopService()
        {
            UserDao userDao = new UserDao();
            List<User> StoppedUsers = new List<User>();
            var users = userDao.Get();

            foreach (var user in users)
            {
                var inProcess = await GetInProcess(user.Ip);
                foreach(var process in inProcess)
                {
                    if(process.UserId == user.UserId)
                    {
                        string jsonbody = JsonSerializer.Serialize(new RequestDto(_token));
                        HttpContent content = new StringContent(jsonbody, System.Text.Encoding.UTF8, "application/json");
                        HttpResponseMessage response = await _httpClient.PostAsync($"http://{user.Ip}:4242/MinecraftServer/Admin/Stop/{user.Username}", content);
                        
                        if(response.IsSuccessStatusCode)
                        {
                            MailMessage message = new MailMessage();
                            message.From = new MailAddress("brunohoske@gmail.com"); //Alterar aqui!!
                            message.To.Add(user.Email);
                            message.Subject = "Teste Email";
                            message.Body = "Teste";
                            EmailService.Send(message);
                            StoppedUsers.Add(user);
                        }
                    }
                }
            }
            return StoppedUsers;
        }

        public async Task<List<Process>> GetInProcess(string ip)
        {
            try
            {
                string jsonbody = JsonSerializer.Serialize(new RequestDto(_token));
                HttpContent content = new StringContent(jsonbody, System.Text.Encoding.UTF8, "application/json");
                HttpResponseMessage response = await _httpClient.PostAsync($"http://{ip}:4242/MinecraftServer/Admin/RunningProcesses", content);

                string responseContent = await response.Content.ReadAsStringAsync();
                var processes = JsonSerializer.Deserialize<List<Process>>(responseContent);
                return processes;
            }
            catch(Exception ex) 
            {
                Console.WriteLine($"Erro ao buscar os processos no ip: {ip}: {ex.Message}");
                return new List<Process>();
                
            }
           
        }
    }

 
}
