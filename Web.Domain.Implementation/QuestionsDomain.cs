using Web.Domain.Entities;
using Web.Domain.Interfaces;
using Web.Infraestructure.Interfaces;
using Web.Application.Dto;

namespace Web.Domain.Implementation
{
    /// <summary>
    /// QuestionsDomain
    /// </summary>
    public class QuestionsDomain : IQuestionsDomain
    {
        private readonly IQuestionsRepository _QuestionsInfraestructure;
        private readonly ICategoryRepository _CategoryInfraestructure;

        /// <summary>
        /// Constructor QuestionsDomain
        /// </summary>
        /// <param name="questionsInfraestructure"></param>
        /// <param name="categoryInfraestructure"></param>
        public QuestionsDomain(IQuestionsRepository questionsInfraestructure, ICategoryRepository categoryInfraestructure)
        {
            _QuestionsInfraestructure = questionsInfraestructure;
            _CategoryInfraestructure = categoryInfraestructure;
        }

        /// <summary>
        /// GetCategories
        /// </summary>
        /// <returns></returns>
        public async Task<ResponseDto<List<CategoryItem>>> GetCategories()
        {
            // get all Categories in database
            List<Categories> allCategories = await _CategoryInfraestructure.GetAllCategories();

            // check if not exists almost one
            if (!allCategories.Any())
                return new ResponseDto<List<CategoryItem>>() 
                { 
                    success = false,
                    error = true,
                    message = "No existe categorias de preguntas",
                    result = new List<CategoryItem>()
                };

            // return list of items category
            return new ResponseDto<List<CategoryItem>>()
            {
                success = true,
                error = false,
                message = "Categorias de preguntas encontradas",
                result = allCategories.Select(x => new CategoryItem(x.CategoryId, x.Name)).ToList<CategoryItem>()
            };

        }

        public async Task<ResponseDto<List<QuizItem>>> GetQuestions(int? categoryId)
        {
            List<Questions> resultQuestions = await _QuestionsInfraestructure.GetQuestions(categoryId);

            if (!resultQuestions.Any())
                return new ResponseDto<List<QuizItem>>()
                {
                    success = false,
                    error = true,
                    message = "No existe preguntas",
                    result = new List<QuizItem>()
                };

            return new ResponseDto<List<QuizItem>>()
            {
                success = true,
                error = false,
                message = "Preguntas encontradas",
                result = resultQuestions.Select(
                    x => new QuizItem(
                        x.Question, 
                        x.Answers.Split(", ").ToList<string>(),
                        x.AnswerIndex,
                        x.Score,
                        x.CategoryId)
                ).ToList<QuizItem>()
            };

        }

        public async Task<ResponseDto<QuizItem?>> CreateQuestion(QuizItem question)
        {
            Questions? newQuestion = Questions.QuizItem2Questions(question);

            if(newQuestion == null)
                return new ResponseDto<QuizItem?>()
                {
                    success = false,
                    error = true,
                    message = "No se pudo crear pregunta - error con parametros de la pregunta"
                };

            Tuple<int,Questions?> resultCreate = await _QuestionsInfraestructure.CreateQuestion(newQuestion);

            if(resultCreate.Item1 <= 0)
                return new ResponseDto<QuizItem?>()
                {
                    success = false,
                    error = true,
                    message = "No se pudo crear pregunta - error al momento de creacion"
                };

            return new ResponseDto<QuizItem?>
            {
                success = true,
                error = false,
                message = "Pregunta creada",
                result = question
            };
        }

        public async Task<ResponseDto<QuizItem?>> DeleteQuestion(int questionId)
        {
            Tuple<int, Questions?> resultCreate = await _QuestionsInfraestructure.DeleteQuestion(questionId);

            if(resultCreate.Item1 <= 0 || resultCreate.Item2 == null)
                return new ResponseDto<QuizItem?>()
                {
                    success = false,
                    error = true,
                    message = "No se pudo eliminar pregunta"
                };

            return new ResponseDto<QuizItem?>
            {
                success = true,
                error = false,
                message = "Pregunta eliminada",
                result = new QuizItem(
                    resultCreate.Item2.Question,
                    resultCreate.Item2.Answers.Split(", ").ToList(),
                    resultCreate.Item2.AnswerIndex,
                    resultCreate.Item2.Score,
                    resultCreate.Item2.CategoryId)
            };


        }

    }
}
