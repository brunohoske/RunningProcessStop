using System.Text.Json.Serialization;

namespace RunningProcessStop.Models
{
    public class Authorization
    {
        [JsonPropertyName("token")]
        public string Token { get; set; }
    }
}
