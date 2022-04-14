using System.Text.Json.Serialization;

namespace Movies.Core.Generics
{
    public class Result<T> :Result
    {
        [JsonPropertyName("data")]
        public T Data { get; set; }
    }
}
