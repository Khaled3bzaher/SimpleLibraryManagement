namespace SimpleLibraryManagement.Application.Shared.Response
{
    public class AuthResponse
    {
        public string? Token { get; set; }
        public bool Result { get; set; }
        public List<string> Errors { get; set; } = [];
    }
}
