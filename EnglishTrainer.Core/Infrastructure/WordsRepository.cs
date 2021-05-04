﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Dapper;
using EnglishTrainer.Core.Domain.Entities;
using EnglishTrainer.Core.Domain.Repositories;

namespace EnglishTrainer.Core.Infrastructure
{
	public class WordsRepository : IWordsRepository
	{
		private readonly IDbConnection _connection;
		public WordsRepository(IDbConnection connection)
		{
			_connection = connection ?? throw new ArgumentNullException(nameof(connection));
		}

		public List<Word> GetAll()
		{
			var result = _connection
				.Query<Word>(@"select * from Words")
				.ToList();

			return result;
		}

		public Word GetById(int id)
		{
			var result = _connection
				.Query<Word>(@"select * from Words
                                    where Id = @Id",
					new {Id = id})
				.ToList();

			return result.Single();
		}

		public void Create(Word word)
		{
			var a = _connection
				.Query<Word>(@"insert into Words
                (Original, Translation) 
                VALUES (@Original, @Translation)",
					new
					{
						Original = word.Original,
						Translation = word.Translation
					});
		}
	}
}
