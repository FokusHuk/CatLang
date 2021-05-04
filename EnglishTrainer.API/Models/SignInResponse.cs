namespace EnglishTrainer.API.Models
{
    public class SignInResponse
    {
        public SignInResponse(string accessToken)
        {
            AccessToken = accessToken;
        }

        public string AccessToken { get; }
    }
}
