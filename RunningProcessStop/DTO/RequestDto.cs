using System.Text.Json.Serialization;
using RunningProcessStop.Models;

namespace RunningProcessStop.DTO
{
    public class RequestDto
    {
  
        [JsonPropertyName("authorization")]
        public Authorization Authorization { get; set; }

        public RequestDto() { }
        public RequestDto(string token)
        {
            Authorization = new Authorization { Token = token };
        }

    }

}
