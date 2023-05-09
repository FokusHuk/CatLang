using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Dapper;
using EnglishTrainer.Core.Domain.Entities;
using EnglishTrainer.Core.Domain.Repositories;

namespace EnglishTrainer.Core.Infrastructure
{
	public class PostgreSqlWordsRepository : IWordsRepository
	{
		private readonly IDbConnection _connection;
		public PostgreSqlWordsRepository(IDbConnection connection)
		{
			_connection = connection ?? throw new ArgumentNullException(nameof(connection));
		}

		public List<Word> GetAll()
		{
			var result = _connection
				.Query<Word>("select * from public.\"Words\"")
				.ToList();

			return result;
		}

		public Word GetById(int wordId)
		{
			var result = _connection
				.Query<Word>(@"select * from public.""Words""
				where ""Id"" = @Id",
					new {Id = wordId})
				.ToList();

			return result.Single();
		}

		public void Create(Word word)
		{
			var a = _connection
				.Query<Word>(@"insert into public.""Words""
				(""Original"", ""Translation"") 
				VALUES (@Original, @Translation)",
					new
					{
						Original = word.Original,
						Translation = word.Translation
					});
		}

		public List<Word> GetSetWords(Guid setId)
		{
			var result = _connection
				.Query<Word>(@"select * from public.""Words""
				Where ""Id"" in 
				(select (""WordId"") from public.""SetWords""
				where ""SetId"" = @SetId)",
					new {SetId = setId})
				.ToList();

			return result;
		}

		public void AddSetWord(Guid setId, int wordId)
		{
			var a = _connection
				.Query<Word>(@"insert into public.""SetWords""
				(""WordId"", ""SetId"") 
				VALUES (@WordId, @SetId)",
					new
					{
						WordId = wordId,
						SetId = setId
					});
		}
		
		public StudiedWordDto GetStudiedWord(Guid userId, int wordId)
		{
			var result = _connection
				.Query<StudiedWordDto>(@"select * from public.""StudiedWords""
				Where ""UserId"" = @UserId and ""WordId"" = @WordId",
					new
					{
						UserId = userId,
						WordId = wordId
					})
				.ToList();

			return result.SingleOrDefault();
		}
		
		public List<StudiedWordDto> GetStudiedWordsByUserId(Guid userId)
		{
			var result = _connection
				.Query<StudiedWordDto>(@"select * from public.""StudiedWords""
				Where ""UserId"" = @UserId",
					new {UserId = userId})
				.ToList();

			return result;
		}
		
		public void UpdateStudiedWord(StudiedWordDto studiedWordDto)
		{
			var result = _connection
				.Query<StudiedWordDto>(@"update public.""StudiedWords""
				set 
					""CorrectAnswers"" = @CorrectAnswers,
					""IncorrectAnswers"" = @IncorrectAnswers,
					""LastAppearanceDate"" = @LastAppearanceDate,
					""Status"" = @Status,
					""RiskFactor"" = @RiskFactor
				where ""Id"" = @Id",
					new
					{
						Id = studiedWordDto.Id,
						CorrectAnswers = studiedWordDto.CorrectAnswers,
						IncorrectAnswers = studiedWordDto.IncorrectAnswers,
						LastAppearanceDate = studiedWordDto.LastAppearanceDate,
						Status = studiedWordDto.Status,
						RiskFactor = studiedWordDto.RiskFactor
					});
		}
		
		public void AddStudiedWord(StudiedWordDto studiedWordDto)
		{
			var a = _connection
				.Query<Word>(@"insert into public.""StudiedWords""
				(""UserId"", ""WordId"", ""CorrectAnswers"", ""IncorrectAnswers"", ""LastAppearanceDate"", ""Status"", ""RiskFactor"") 
				VALUES (@UserId, @WordId, @CorrectAnswers, @IncorrectAnswers, @LastAppearanceDate, @Status, @RiskFactor)",
					new
					{
						UserId = studiedWordDto.UserId,
						WordId = studiedWordDto.WordId,
						CorrectAnswers = studiedWordDto.CorrectAnswers,
						IncorrectAnswers = studiedWordDto.IncorrectAnswers,
						LastAppearanceDate = studiedWordDto.LastAppearanceDate,
						Status = studiedWordDto.Status,
						RiskFactor = studiedWordDto.RiskFactor
					});
		}
	}
}
