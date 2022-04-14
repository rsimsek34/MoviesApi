using System.Text.Json.Serialization;

namespace Movies.Core.Generics
{
    public class Result
    {
        [JsonPropertyName("isSuccess")]
        public bool Success { get; set; }

        [JsonPropertyName("message")]
        public string Message { get; set; }
    }
}
