using Moq;
using Xunit;
using FluentAssertions;
using Web.Application.Implementation;
using Web.Application.Interfaces;
using Web.Domain.Interfaces;
using Web.Application.Dto;

namespace Web.UnitTest
{
    public class TestCreateQuestion
    {
        private readonly Mock<IQuestionsDomain> _mockQuestionsDomain;
        private readonly QuestionsApplication _questionApplication;
        private const int _ID_CATEGORIA_VALIDA = 1;

        public TestCreateQuestion()
        {
            _mockQuestionsDomain = new Mock<IQuestionsDomain>();
            _questionApplication = new QuestionsApplication(_mockQuestionsDomain.Object);
        }

        [Fact]
        public async Task CreateQuestion_WhenIsCorrect()
        {
            // this is not complete, i need to learn more about Unit Tests

            QuizItem newQuestion = new QuizItem(
                $"Pregunta Prueba - {DateTime.Now.Ticks}",
                new List<string>() { "hoy", "mañana", "ayer" },
                1,
                _ID_CATEGORIA_VALIDA);

            ResponseDto<QuizItem?> response = await _questionApplication.CreateQuestion(newQuestion);

            Assert.Null(response);
        }
    }
}