using System.Collections.Generic;
using TranslationTrainer.Domain;
using TranslationTrainer.Domain.Entities;
using TranslationTrainer.Domain.Repositories;

namespace TranslationTrainer.Infrastructure
{
	public class WordsRepository : IWordsRepository
	{
		public IEnumerable<Word> LoadAll()
		{
			return new List<Word>()
			{
				new Word("name", "имя"),
				new Word("apple", "яблоко"),
				new Word("home", "дом"),
				new Word("task", "задача"),
				new Word("word", "слово"),
				new Word("panel", "панель"),
				new Word("window", "окно"),
				new Word("pen", "ручка"),
				new Word("hi", "привет"),
				new Word("fast", "быстрый"),
				new Word("slow", "медленный"),
				new Word("week", "неделя"),
				new Word("safe", "безопасный"),
				new Word("correct", "правильный"),
				new Word("life", "жизнь"),
				new Word("token", "токен"),
				new Word("error", "ошибка"),
				new Word("finish", "финиш")
			};
		}
	}
}