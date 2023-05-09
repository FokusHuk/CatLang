using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Dapper;
using EnglishTrainer.Core.Domain.Entities;
using EnglishTrainer.Core.Domain.Exercises;
using EnglishTrainer.Core.Domain.Repositories;

namespace EnglishTrainer.Core.Infrastructure
{
    public class PostgreSqlExerciseWordsRepository : IExerciseWordsRepository
    {
        private readonly IDbConnection _connection;
        
        public PostgreSqlExerciseWordsRepository(IDbConnection connection)
        {
            _connection = connection ?? throw new ArgumentNullException(nameof(connection));
        }
        
        public List<ExerciseWordDto> GetExerciseWordsByExerciseId(Guid exerciseId)
        {
            var result = _connection
                .Query<ExerciseWordDto>("select * from public.\"ExerciseWords\"" +
                                        "Where \"ExerciseId\" = @ExerciseId",
                    new {ExerciseId = exerciseId})
                .ToList();

            return result;
        }

        public void AddExerciseWord(ExerciseWordDto exerciseWordDto)
        {
            var a = _connection
                .Query<Word>("insert into public.\"ExerciseWords\"" +
                             "(\"ExerciseId\", \"SetId\", \"WordId\", \"Answer\", \"Date\", \"IsCorrect\")" +
                             "VALUES (@ExerciseId, @SetId, @WordId, @Answer, @Date, @IsCorrect)",
                    new
                    {
                        ExerciseId = exerciseWordDto.ExerciseId,
                        SetId = exerciseWordDto.SetId,
                        WordId = exerciseWordDto.WordId,
                        Answer = exerciseWordDto.Answer,
                        Date = exerciseWordDto.Date,
                        IsCorrect = exerciseWordDto.IsCorrect
                    });
        }

        public void DeleteExerciseWordsByExerciseId(Guid exerciseId)
        {
            _connection.Query<ExerciseWordDto>(@"delete from public.""ExerciseWords""
                                                Where ""ExerciseId"" = @ExerciseId",
                new {ExerciseId = exerciseId});
        }
    }
}
