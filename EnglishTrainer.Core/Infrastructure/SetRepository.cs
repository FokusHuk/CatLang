using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Dapper;
using EnglishTrainer.Core.Domain.Entities;
using EnglishTrainer.Core.Domain.Repositories;

namespace EnglishTrainer.Core.Infrastructure
{
    public class SetRepository: ISetRepository
    {
        private readonly IDbConnection _connection;
        
        public SetRepository(IDbConnection connection)
        {
            _connection = connection ?? throw new ArgumentNullException(nameof(connection));
        }
        
        public List<WordsSetDto> GetAll()
        {
            var result = _connection
                .Query<WordsSetDto>(@"select * from Sets")
                .ToList();

            return result;
        }
        
        public WordsSetDto GetById(Guid setId)
        {
            var result = _connection
                .Query<WordsSetDto>(@"select * from Sets
                                    where Id = @Id",
                    new {Id = setId})
                .ToList();

            return result.Single();
        }
        
        public void Create(WordsSetDto setDto)
        {
            var a = _connection
                .Query<Word>(@"insert into Sets
                (Id, UserId, AverageStudyTime, StudyTopic, Popularity, Efficiency, Complexity) 
                VALUES (@Id, @UserId, @AverageStudyTime, @StudyTopic, @Popularity, @Efficiency, @Complexity)",
                    new
                    {
                        Id = setDto.Id,
                        UserId = setDto.UserId,
                        AverageStudyTime = setDto.AverageStudyTime,
                        StudyTopic = setDto.StudyTopic,
                        Popularity = setDto.Popularity,
                        Efficiency = setDto.Efficiency,
                        Complexity = setDto.Complexity
                    });
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

            return result.Single();
        }
        
        public void AddStudiedSet(StudiedSetDto studiedSetDto)
        {
            var a = _connection
                .Query<Word>(@"insert into UserStudiedSets
                (SetId, UserId, AttemptsCount, IsStudied) 
                VALUES (@SetId, @UserId, @AttemptsCount, @IsStudied)",
                    new
                    {
                        SetId = studiedSetDto.SetId,
                        UserId = studiedSetDto.UserId,
                        AttemptsCount = studiedSetDto.AttemptsCount,
                        IsStudied = studiedSetDto.IsStudied
                    });
        }
    }
}
