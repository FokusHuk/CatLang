using System;

namespace EnglishTrainer.Core.Domain.Entities
{
    public class WordsSetDto
    {
        public WordsSetDto(Guid id, Guid userId, string studyTopic, int popularity, double efficiency, double averageStudyTime, WordsSetComplexity complexity)
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
        
        public Guid Id { get; }
        public Guid UserId { get; }
        public string StudyTopic { get; }
        public int Popularity { get; set; }
        public double Efficiency { get; set; }
        public double AverageStudyTime { get; set; }
        public WordsSetComplexity Complexity { get; set; }
    }
}