using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace UnitTestProject1
{
	public static class MorseCodeTranslator
	{
		private static readonly Dictionary<string, string> MorseLookup = new Dictionary<string, string>
		{
			{"A", ".-"},
			{"B", "-..."},
			{"C", "-.-."},
			{"D", "-.."},
			{"E", "."},
			{"F", "..-."},
			{"G", "--."},
			{"H", "...."},
			{"I", ".."},
			{"J", ".---"},
			{"K", "-.-"},
			{"L", ".-.."},
			{"M", "--"},
			{"N", "-."},
			{"O", "---"},
			{"P", ".--."},
			{"Q", "--.-"},
			{"R", ".-."},
			{"S", "..."},
			{"T", "-"},
			{"U", "..-"},
			{"V", "...-"},
			{"W", ".--"},
			{"X", "-..-"},
			{"Y", "-.--"},
			{"Z", "--.."},
			{ ".", ".-.-.-"}
		};

		public static string Translate(bool morseToEnglish, string textToTranslate)
		{
			return morseToEnglish ? MorseToEnglish(textToTranslate) : EnglishToMorse(textToTranslate);
		}

		private static string MorseToEnglish(string textToTranslate)
		{
			var translatedText = "Invalid Morse Code Or Spacing";
			var stringBuilder = new StringBuilder();
			var sentences = Regex.Split(textToTranslate, "  ");

			var isFirstLetter = true;

			foreach (var sentence in sentences)
			{
				var words = sentence.Split(' ');
				foreach (var word in words)
				{
					var key = MorseLookup.SingleOrDefault(x => x.Value == word).Key;
					if (string.IsNullOrWhiteSpace(key)) continue;
					stringBuilder.Append(!isFirstLetter ? $"{key.ToLower()}" : $"{key}");

					isFirstLetter = false;
				}

				stringBuilder.Append(" ");
			}

			translatedText = string.IsNullOrWhiteSpace(stringBuilder.ToString())
				? translatedText
				: $"{stringBuilder.ToString().Trim(' ').ToLower()}";

			return translatedText;
		}

		private static string EnglishToMorse(string textToTranslate)
		{
			var translatedText = "Invalid Morse Code Or Spacing";
			var stringBuilder = new StringBuilder();
			var words = Regex.Split(textToTranslate, " ");

			foreach (var word in words)
			{
				foreach (var letter in word)
				{
					stringBuilder.Append(MorseLookup[letter.ToString().ToUpper()]);
					stringBuilder.Append(" ");
				}

				stringBuilder.Append("  ");
			}

			translatedText = string.IsNullOrWhiteSpace(stringBuilder.ToString())
				? translatedText
				: $"{stringBuilder.ToString().TrimEnd(' ')}";

			return translatedText;
		}
	}
}