using EnglishTrainer.Core.Domain.Entities;

namespace EnglishTrainer.Core.Domain.Features
{
    public static class WordExtensions
    {
        public static Word SwapOriginalAndTranslation(this Word word) =>
            new Word(word.Id, word.Translation, word.Original);
    }
}
