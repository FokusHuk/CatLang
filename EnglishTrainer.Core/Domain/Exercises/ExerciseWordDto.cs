using System;

namespace EnglishTrainer.Core.Domain.Exercises
{
    public class ExerciseWordDto
    {
        public ExerciseWordDto(int id, Guid exerciseId, Guid setId, int wordId, string answer, DateTime date, bool isCorrect)
        {
            Id = id;
            ExerciseId = exerciseId;
            SetId = setId;
            WordId = wordId;
            Answer = answer;
            Date = date;
            IsCorrect = isCorrect;
        }
        
        public int Id { get; }
        public Guid ExerciseId { get; }
        public Guid SetId { get; }
        public int WordId { get; }
        public string Answer { get; }
        public DateTime Date { get; }
        public bool IsCorrect { get; }
    }
}
