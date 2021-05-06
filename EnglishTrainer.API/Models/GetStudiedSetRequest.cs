using System;

namespace EnglishTrainer.API.Models
{
    public class GetStudiedSetRequest
    {
        public GetStudiedSetRequest(Guid userId, Guid setId)
        {
            UserId = userId;
            SetId = setId;
        }
        public Guid UserId { get; set; }
        public Guid SetId { get; set; }
    }
}
