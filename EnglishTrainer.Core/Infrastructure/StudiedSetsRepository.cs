using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Dapper;
using EnglishTrainer.Core.Domain.Entities;
using EnglishTrainer.Core.Domain.Repositories;

namespace EnglishTrainer.Core.Infrastructure
{
    public class StudiedSetsRepository : IStudiedSetsRepository
    {
        private readonly IDbConnection _connection;
        
        public StudiedSetsRepository(IDbConnection connection)
        {
            _connection = connection ?? throw new ArgumentNullException(nameof(connection));
        }
        
        public List<StudiedSetDto> GetStudiedSetsBySetId(Guid setId)
        {
            var result = _connection
                .Query<StudiedSetDto>(@"select * from UserStudiedSets
                                    where SetId = @SetId",
                    new {SetId = setId})
                .ToList();

            return result;
        }
        
        public List<StudiedSetDto> GetStudiedSetsByUserId(Guid userId)
        {
            var result = _connection
                .Query<StudiedSetDto>(@"select * from UserStudiedSets
                                    where UserId = @UserId",
                    new {UserId = userId})
                .ToList();

            return result;
        }
        
        public StudiedSetDto GetStudiedSet(Guid userId, Guid setId)
        {
            var result = _connection
                .Query<StudiedSetDto>(@"select * from UserStudiedSets
                                    where UserId = @UserId and SetId = @SetId",
                    new
                    {
                        UserId = userId,
                        SetId = setId
                    })
                .ToList();

            return result.SingleOrDefault();
        }

        public void UpdateStudiedSet(StudiedSetDto studiedSetDto)
        {
            var result = _connection
                .Query<StudiedSetDto>(@"update UserStudiedSets
                                    set AttemptsCount = @AttemptsCount,
                                        IsStudied = @IsStudied,
                                        CorrectAnswers = @CorrectAnswers,
                                        AnswersCount = @AnswersCount
                                    where Id = @Id",
                    new
                    {
                        Id = studiedSetDto.Id,
                        AttemptsCount = studiedSetDto.AttemptsCount,
                        IsStudied = studiedSetDto.IsStudied,
                        CorrectAnswers = studiedSetDto.CorrectAnswers,
                        AnswersCount = studiedSetDto.AnswersCount
                    });
        }

        public void AddStudiedSet(StudiedSetDto studiedSetDto)
        {
            var a = _connection
                .Query<Word>(@"insert into UserStudiedSets
                (SetId, UserId, AttemptsCount, IsStudied, CorrectAnswers, AnswersCount) 
                VALUES (@SetId, @UserId, @AttemptsCount, @IsStudied, @CorrectAnswers, @AnswersCount)",
                    new
                    {
                        SetId = studiedSetDto.SetId,
                        UserId = studiedSetDto.UserId,
                        AttemptsCount = studiedSetDto.AttemptsCount,
                        IsStudied = studiedSetDto.IsStudied,
                        CorrectAnswers = studiedSetDto.CorrectAnswers,
                        AnswersCount = studiedSetDto.AnswersCount
                    });
        }
    }
}
