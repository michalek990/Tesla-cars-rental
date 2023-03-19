using System.Net;

namespace backend.Models;

public record ErrorMessage(HttpStatusCode StatusCode, string Title, string Details, DateTime Timestamp);