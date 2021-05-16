using System;
using System.Collections.Generic;

namespace EnglishTrainer.API.Models
{
    public class CreateSetRequest
    {
        public CreateSetRequest()
        {
            
        }
        
        public CreateSetRequest(string studyTopic, List<int> setWordsIds)
        {
            StudyTopic = studyTopic;
            SetWordsIds = setWordsIds;
        }
        
        public string StudyTopic {get;set;}
        public List<int> SetWordsIds {get;set;}
    }
}
