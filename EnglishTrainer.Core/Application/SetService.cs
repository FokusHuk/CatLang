using System;
using System.Collections.Generic;
using EnglishTrainer.Core.Domain.Entities;
using EnglishTrainer.Core.Domain.Repositories;

namespace EnglishTrainer.Core.Application
{
    public class SetService : ISetService
    {
        private readonly ISetRepository _setRepository;
        private readonly IUserRepository _userRepository;
        private readonly IWordsRepository _wordsRepository;

        public SetService(ISetRepository setRepository, IUserRepository userRepository, IWordsRepository wordsRepository)
        {
            _setRepository = setRepository ?? throw new ArgumentNullException(nameof(setRepository));
            _userRepository = userRepository ?? throw new ArgumentNullException(nameof(userRepository));
            _wordsRepository = wordsRepository ?? throw new ArgumentNullException(nameof(wordsRepository));
        }

        public List<WordsSet> GetAllSets()
        {
            var sets = new List<WordsSet>();
            var setDtos = _setRepository.GetAll();

            foreach (var setDto in setDtos)
            {
                sets.Add(GetSetFromDto(setDto));
            }

            return sets;
        }

        public WordsSet GetSetById(Guid setId)
        {
            var setDto = _setRepository.GetById(setId);
            return GetSetFromDto(setDto);
        }

        public Guid CreateSet(Guid userId, string studyTopic, List<int> setWordsIds)
        {
            var setId = Guid.NewGuid();
            var setDto = new WordsSetDto(setId, userId, studyTopic);
            
            _setRepository.Create(setDto);
            
            foreach (var wordId in setWordsIds)
            {
                _wordsRepository.AddSetWord(setId, wordId);
            }

            return setId;
        }

        private WordsSet GetSetFromDto(WordsSetDto setDto)
        {
            var setWords = _wordsRepository.GetSetWords(setDto.Id);
            var authorName = _userRepository.GetById(setDto.UserId).Username;

            return new WordsSet(setDto.Id, authorName, setDto.StudyTopic, setWords, setDto.Popularity,
                setDto.Efficiency, setDto.AverageStudyTime, setDto.Complexity);
        }
    }
}
