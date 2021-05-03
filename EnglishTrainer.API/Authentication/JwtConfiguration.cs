using System;

namespace EnglishTrainer.API.Authentication
{
    public class JwtConfiguration
    {
        public string Secret { get; set; }
        
        public TimeSpan ExpiresAfter { get; set; }
    }
}