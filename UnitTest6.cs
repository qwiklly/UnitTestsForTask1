using TechnicalTask1.Tests;
using TechnicalTask1.Models;
using TechnicalTask1.Constants;

namespace UnitTests
{
	public class TherapistTestTests
	{
		private TherapistTest _therapistTest;

		public TherapistTestTests()
		{
			_therapistTest = new TherapistTest();
		}

		[Fact]
		public void MoreThan3Diseases_ShouldReturnUnsatisfactory()
		{
			var candidate = new Candidate("Вивер", 80, 180, 30, 1.0, ["насморк", "бронхит", "вирус", "аллергия"]);
			var result = _therapistTest.Evaluate(candidate);
			Assert.Equal(ConstantsMarks.Unsatisfactory, result.Mark);
			Assert.Equal("Больше 3 болезней", result.Reason);
		}

		[Fact]
		public void Exactly3Diseases_ShouldReturnSatisfactory()
		{
			var candidate = new Candidate("Вивер", 80, 180, 30, 1.0, [ "насморк", "бронхит", "вирус"]);
			var result = _therapistTest.Evaluate(candidate);
			Assert.Equal(ConstantsMarks.Satisfactory, result.Mark);
			Assert.Equal("3 болезни", result.Reason);
		}

		[Fact]
		public void LessThan3Diseases_ShouldReturnGood()
		{
			var candidate = new Candidate("Вивер", 80, 180, 30, 1.0, [ "насморк", "бронхит" ]);
			var result = _therapistTest.Evaluate(candidate);
			Assert.Equal(ConstantsMarks.Good, result.Mark);
			Assert.Equal("", result.Reason);
		}
	}
}