using NUnit.Framework;

namespace UnitTestProject1
{
	[TestFixture]
	public class MorseCodeTranslatorTests
	{
		[Test]
		public void Run_GivenInvalidMorse_ShouldReturnInvalidMorseString()
		{
			// Arrange
			var invalidString = "derpy mac derpystring";

			// Act
			var result = MorseCodeTranslator.Translate(true, invalidString);

			// Assert
			Assert.That(result, Is.EqualTo("Invalid Morse Code Or Spacing"));
		}

		[TestCase(true,
			"- .... .   .-- .. --.. .- .-. -..   --.- ..- .. -.-. -.- .-.. -.--   .--- .. -. -..- . -..   - .... .   --. -. --- -- . ...   -... . ..-. --- .-. .   - .... . -.--   ...- .- .--. --- .-. .. --.. . -.. .-.-.-",
			"the wizard quickly jinxed the gnomes before they vaporized.")]
		[TestCase(false,
			"the wizard quickly jinxed the gnomes before they vaporized.",
			"- .... .   .-- .. --.. .- .-. -..   --.- ..- .. -.-. -.- .-.. -.--   .--- .. -. -..- . -..   - .... .   --. -. --- -- . ...   -... . ..-. --- .-. .   - .... . -.--   ...- .- .--. --- .-. .. --.. . -.. .-.-.-")]
		public void Run_GivenTrueAndMorseText_ShouldReturnExpectedTranslatedString(bool morseToEnglish, string expectedTranslatedResult,
			string expectedEnglishString)
		{
			// Act
			var result = MorseCodeTranslator.Translate(morseToEnglish, expectedTranslatedResult);

			// Assert
			Assert.That(result, Is.EqualTo(expectedEnglishString));
		}
	}
}
