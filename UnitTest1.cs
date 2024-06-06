using TechnicalTask1.Tests;
using TechnicalTask1.Models;
using TechnicalTask1.Constants;

namespace UnitTests
{
	public class AgeTestTests
	{
		private AgeTest _ageTest;

		public AgeTestTests()
		{
			_ageTest = new AgeTest();
		}

		[Fact]
		public void Age_LessThan23_ShouldReturnUnsatisfactory()
		{
			var candidate = new Candidate("Вивер", 80, 180, 22, 1.0, Array.Empty<string>());
			var result = _ageTest.Evaluate(candidate);
			Assert.Equal(ConstantsMarks.Unsatisfactory, result.Mark);
			Assert.Equal("Возраст кандидата больше 37 лет или меньше 23 лет", result.Reason);
		}

		[Fact]
		public void Age_GreaterThan37_ShouldReturnUnsatisfactory()
		{
			var candidate = new Candidate("Вивер", 80, 180, 38, 1.0, Array.Empty<string>());
			var result = _ageTest.Evaluate(candidate);
			Assert.Equal(ConstantsMarks.Unsatisfactory, result.Mark);
			Assert.Equal("Возраст кандидата больше 37 лет или меньше 23 лет", result.Reason);
		}

		[Fact]
		public void Age_Between23And25_ShouldReturnSatisfactory()
		{
			var candidate = new Candidate("Вивер", 80, 180, 24, 1.0, Array.Empty<string>());
			var result = _ageTest.Evaluate(candidate);
			Assert.Equal(ConstantsMarks.Satisfactory, result.Mark);
			Assert.Equal("Возраст кандидата в диапазоне [23-25) или (35-37]", result.Reason);
		}

		[Fact]
		public void Age_Between35And37_ShouldReturnSatisfactory()
		{
			var candidate = new Candidate("Вивер", 80, 180, 36, 1.0, Array.Empty<string>());
			var result = _ageTest.Evaluate(candidate);
			Assert.Equal(ConstantsMarks.Satisfactory, result.Mark);
			Assert.Equal("Возраст кандидата в диапазоне [23-25) или (35-37]", result.Reason);
		}

		[Fact]
		public void Age_Between25And35_ShouldReturnGood()
		{
			var candidate = new Candidate("Вивер", 80, 180, 30, 1.0, Array.Empty<string>());
			var result = _ageTest.Evaluate(candidate);
			Assert.Equal(ConstantsMarks.Good, result.Mark);
			Assert.Equal("", result.Reason);
		}
	}
}