using Web.Application.Dto;

namespace Web.Domain.Interfaces
{
    public interface IQuestionsDomain
    {
        Task<ResponseDto<List<CategoryItem>>> GetCategories();
        Task<ResponseDto<List<QuizItem>>> GetQuestions(int? categoryId);
        Task<ResponseDto<QuizItem?>> CreateQuestion(QuizItem question);
        Task<ResponseDto<QuizItem?>> DeleteQuestion(int questionId);
    }
}
