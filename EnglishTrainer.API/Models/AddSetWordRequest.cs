using System;

namespace EnglishTrainer.API.Models
{
    public class AddSetWordRequest
    {
        public AddSetWordRequest(Guid setId, int wordId)
        {
            SetId = setId;
            WordId = wordId;
        }
        public Guid SetId {get;set;}
        public int WordId {get;set;}
    }
}
