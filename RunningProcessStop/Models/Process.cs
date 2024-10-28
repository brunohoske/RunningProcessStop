using System.Text.Json.Serialization;

namespace RunningProcessStop.Models
{
    public class Process
    {
        [JsonPropertyName("game")]
        public int Game { get; set; }
        [JsonPropertyName("process_id")]
        public int ProcessId { get; set; }
        [JsonPropertyName("user_id")]
        public int UserId { get; set; }
    }
}
