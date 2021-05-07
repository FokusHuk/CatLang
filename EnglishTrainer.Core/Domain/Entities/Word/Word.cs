using System;

namespace EnglishTrainer.Core.Domain.Entities
{
	public class Word
	{
		public Word(string original, string translation)
		{
			Original = original ?? throw new ArgumentNullException(nameof(original));
			Translation = translation ?? throw new ArgumentNullException(nameof(translation));
		}
		
		public Word(int id, string original, string translation)
		{
			Id = id;
			Original = original ?? throw new ArgumentNullException(nameof(original));
			Translation = translation ?? throw new ArgumentNullException(nameof(translation));
		}
		
		public int Id { get; }

		public string Original { get; set; }

		public string Translation { get; set; }

		public override bool Equals(object obj)
		{
			if (ReferenceEquals(null, obj)) return false;
			if (ReferenceEquals(this, obj)) return true;
			return obj.GetType() == GetType() && Equals((Word) obj);
		}

		public override int GetHashCode()
		{
			unchecked
			{
				return (Original.GetHashCode() * 397) ^ Translation.GetHashCode() * Id.GetHashCode();
			}
		}

		public static bool operator ==(Word left, Word right)
		{
			return Equals(left, right);
		}

		public static bool operator !=(Word left, Word right)
		{
			return !Equals(left, right);
		}
		
		private bool Equals(Word other)
		{
			return string.Equals(Original, other.Original) && 
			       string.Equals(Translation, other.Translation) &&
			       Id == other.Id;
		}
	}
}