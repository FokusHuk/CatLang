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
            _connection
                .Query<Word>(@"insert into Sets
                (Id, UserId, AverageStudyTime, StudyTopic, Popularity, Efficiency, Complexity) 
                values (@Id, @UserId, @AverageStudyTime, @StudyTopic, @Popularity, @Efficiency, @Complexity)",
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

        public void UpdateSet(WordsSetDto setDto)
        {
            _connection
                .Query<WordsSetDto>(@"update Sets
                            set 
                                AverageStudyTime = @AverageStudyTime,
                                StudyTopic = @StudyTopic,
                                Popularity = @Popularity,
                                Efficiency = @Efficiency,
                                Complexity = @Complexity
                            where Id = @Id",
                    new
                    {
                        Id = setDto.Id,
                        AverageStudyTime = setDto.AverageStudyTime,
                        StudyTopic = setDto.StudyTopic,
                        Popularity = setDto.Popularity,
                        Efficiency = setDto.Efficiency,
                        Complexity = setDto.Complexity
                    });
        }
    }
}
