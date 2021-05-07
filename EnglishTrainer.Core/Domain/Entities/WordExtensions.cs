namespace EnglishTrainer.Core.Domain.Entities
{
    public static class WordExtensions
    {
        public static Word SwapOriginalAndTranslation(this Word word) =>
            new Word(word.Id, word.Translation, word.Original);
    }
}
