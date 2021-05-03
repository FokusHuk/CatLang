using System;
using System.Collections.Generic;

namespace EnglishTrainer.Core.Domain.Entities
{
    public class WordsSet
    {
        public WordsSet(string authorName, string studyTopic, List<Word> words, int popularity, double efficiency, double averageStudyTime, WordsSetComplexity complexity)
        {
            AuthorName = authorName ?? throw new ArgumentNullException(nameof(authorName));
            StudyTopic = studyTopic ?? throw new ArgumentNullException(nameof(studyTopic));
            Words = words ?? throw new ArgumentNullException(nameof(words));
            if (popularity < 0) throw new ArgumentOutOfRangeException(nameof(popularity));
            if (efficiency < 0) throw new ArgumentOutOfRangeException(nameof(efficiency));
            if (averageStudyTime < 0) throw new ArgumentOutOfRangeException(nameof(averageStudyTime));
            Popularity = popularity;
            Efficiency = efficiency;
            AverageStudyTime = averageStudyTime;
            Complexity = complexity;
        }
        
        public string AuthorName { get; }
        public string StudyTopic { get; }
        public List<Word> Words { get; }
        public int Popularity { get; set; }
        public double Efficiency { get; set; }
        public double AverageStudyTime { get; set; }
        public WordsSetComplexity Complexity { get; set; }
    }
}
