﻿using System;

namespace EnglishTrainer.Core.Domain.Entities
{
    public class WordsSetDto
    {
        public WordsSetDto(
            Guid id, 
            Guid userId, 
            double averageStudyTime, 
            string studyTopic, 
            int popularity, 
            double efficiency, 
            double complexity)
        {
            Id = id;
            UserId = userId;
            StudyTopic = studyTopic ?? throw new ArgumentNullException(nameof(studyTopic));
            if (popularity < 0) throw new ArgumentOutOfRangeException(nameof(popularity));
            if (efficiency < 0) throw new ArgumentOutOfRangeException(nameof(efficiency));
            if (averageStudyTime < 0) throw new ArgumentOutOfRangeException(nameof(averageStudyTime));
            Popularity = popularity;
            Efficiency = efficiency;
            AverageStudyTime = averageStudyTime;
            Complexity = complexity;
        }

        public WordsSetDto(Guid id, Guid userId, string studyTopic)
        {
            Id = id;
            UserId = userId;
            StudyTopic = studyTopic ?? throw new ArgumentNullException(nameof(studyTopic));
            Popularity = 0;
            Efficiency = 0.0;
            AverageStudyTime = 0.0;
            Complexity = 0.0;
        }

        public WordsSetDto()
        {
            
        }
        
        public Guid Id { get; }
        public Guid UserId { get; }
        public string StudyTopic { get; }
        public int Popularity { get; set; }
        public double Efficiency { get; set; }
        public double AverageStudyTime { get; set; }
        public double Complexity { get; set; }
    }
}
