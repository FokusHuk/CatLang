namespace EnglishTrainer.API.Models
{
    public class SignInResponse
    {
        public SignInResponse(string username, string accessToken)
        {
            Username = username;
            AccessToken = accessToken;
        }

        public string Username { get; }
        public string AccessToken { get; }
    }
}
