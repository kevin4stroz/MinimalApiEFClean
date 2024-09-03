using Web.Application.Dto;
using Web.Application.Interfaces;
using Web.Domain.Interfaces;

namespace Web.Application.Implementation
{
    /// <summary>
    /// QuestionsApplication
    /// </summary>
    public class QuestionsApplication : IQuestionsApplication
    {
        private readonly IQuestionsDomain _QuestionsDomain;

        /// <summary>
        /// Constructor - QuestionsApplication
        /// </summary>
        /// <param name="questionsDomain"></param>
        public QuestionsApplication(IQuestionsDomain questionsDomain)
        {
            _QuestionsDomain = questionsDomain;
        }

        /// <summary>
        /// GetCategories
        /// </summary>
        /// <returns></returns>
        public async Task<ResponseDto<List<CategoryItem>>> GetCategories()
        {
            return await _QuestionsDomain.GetCategories();
        }

        /// <summary>
        /// GetQuestions
        /// </summary>
        /// <param name="categoryId"></param>
        /// <returns></returns>
        public async Task<ResponseDto<List<QuizItem>>> GetQuestions(int? categoryId)
        {
            return await _QuestionsDomain.GetQuestions(categoryId);
        }

        /// <summary>
        /// CreateQuestion
        /// </summary>
        /// <param name="question"></param>
        /// <returns></returns>
        public async Task<ResponseDto<QuizItem?>> CreateQuestion(QuizItem question)
        {
            return await _QuestionsDomain.CreateQuestion(question);
        }

        /// <summary>
        /// DeleteQuestion
        /// </summary>
        /// <param name="questionId"></param>
        /// <returns></returns>
        public async Task<ResponseDto<QuizItem?>> DeleteQuestion(int questionId)
        {
            return await _QuestionsDomain.DeleteQuestion(questionId);
        }



    }
}
