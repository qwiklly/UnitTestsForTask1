using TechnicalTask1.Tests;
using TechnicalTask1.Models;
using TechnicalTask1.Constants;


namespace UnitTests
{
    public class StrangeTestTests
    {
        private StrangeTest _strangeTest;

        public StrangeTestTests()
        {
            _strangeTest = new StrangeTest();
        }

        [Fact]
        public void NameStartsWithP_ShouldReturnGood()
        {
            var candidate = new Candidate("Петр", 80, 180, 30, 1.0, []);
            var result = _strangeTest.Evaluate(candidate);
            Assert.Equal(ConstantsMarks.Good, result.Mark);
            Assert.Equal("", result.Reason);
        }

        [Fact]
        public void AgeGreaterThan68_ShouldReturnSatisfactory()
        {
            var candidate = new Candidate("Вивер", 80, 180, 69, 1.0, []);
            var result = _strangeTest.Evaluate(candidate);
            Assert.Equal(ConstantsMarks.Satisfactory, result.Mark);
            Assert.Equal("Возраст кандидата больше 68 лет", result.Reason);
        }

        [Fact]
        public void NameDoesNotStartWithP_And_AgeNotGreaterThan68_ShouldReturnUnsatisfactory()
        {
            var candidate = new Candidate("Вивер", 80, 180, 30, 1.0, []);
            var result = _strangeTest.Evaluate(candidate);
            Assert.Equal(ConstantsMarks.Unsatisfactory, result.Mark);
            Assert.Equal("Имя кандидата не начинается с буквы «П» и возраст кандидата больше 68 лет", result.Reason);
        }
    }
}