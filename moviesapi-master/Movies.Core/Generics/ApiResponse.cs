using System.Collections.Generic;
using System.Text.Json;

namespace Movies.Core.Generics
{
    public class ApiResponse
    {
        public bool Success { get; set; }
        public string Message { get; set; }
    }
    public class ApiResponse<T> : ApiResponse
    {
        public T Data { get; set; }
    }
    public class ApiErrorResponse : ApiResponse
    {
        public string InnerMessage { get; set; }

        public override string ToString()
        {
            return JsonSerializer.Serialize(this, new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase, DictionaryKeyPolicy = JsonNamingPolicy.CamelCase });
        }
    }
    public class ApiValidationErrorResponse : ApiResponse
    {
        public List<ErrorModel> Errors { get; set; } = new List<ErrorModel>();
    }
    public class ErrorModel
    {
        public string FieldName { get; set; }
        public string Message { get; set; }
    }
}
