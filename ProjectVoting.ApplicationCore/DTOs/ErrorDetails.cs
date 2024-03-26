using System.Diagnostics.CodeAnalysis;
using System.Text.Json;

namespace ProjectVoting.ApplicationCore.DTOs
{
    [ExcludeFromCodeCoverage]
    public class ErrorDetails
    {
        public int StatusCode { get; set; }
        public string Message { get; set; }
        public override string ToString()
        {
            return JsonSerializer.Serialize(this);
        }
    }
}
