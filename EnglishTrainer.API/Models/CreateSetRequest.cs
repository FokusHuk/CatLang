using System;
using System.Collections.Generic;

namespace EnglishTrainer.API.Models
{
    public class CreateSetRequest
    {
        public CreateSetRequest(Guid userId, string studyTopic, List<int> setWordsIds)
        {
            UserId = userId;
            StudyTopic = studyTopic;
            SetWordsIds = setWordsIds;
        }
        
        public Guid UserId {get;set;}
        public string StudyTopic {get;set;}
        public List<int> SetWordsIds {get;set;}
    }
}
