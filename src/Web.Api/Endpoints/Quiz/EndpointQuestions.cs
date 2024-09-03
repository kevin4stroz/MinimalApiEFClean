using Web.Application.Dto;
using Web.Application.Interfaces;

namespace Web.Api.Endpoints.Quiz;

/// <summary>
/// EndpointQuestions
/// </summary>
public class EndpointQuestions : IEndpoint
{
    private readonly IQuestionsApplication _QuestionsApplication;

    /// <summary>
    /// Constructor - EndpointQuestions
    /// </summary>
    /// <param name="questionsApplication"></param>
    public EndpointQuestions(IQuestionsApplication questionsApplication)
    {
        _QuestionsApplication = questionsApplication;
    }

    /// <summary>
    /// MapEndpoint
    /// </summary>
    /// <param name="app"></param>
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        // Endpoint get all categories inside of the system
        app.MapGet("/api/quiz/category", async () =>
        {
            return await _QuestionsApplication.GetCategories();
        });

        // Endpoint get all questions by categoryId
        app.MapGet("/api/quiz/questions", async (int? categoryId) =>
        {
            return await _QuestionsApplication.GetQuestions(categoryId);
        });

        // Endpoint create a new question
        app.MapPost("/api/quiz/questions", async (QuizItem question) =>
        {
            return await _QuestionsApplication.CreateQuestion(question);
        });

        // Endpoint disable a question by id
        app.MapDelete("/api/quiz/questions", async (int questionId) =>
        {
            return await _QuestionsApplication.DeleteQuestion(questionId);
        });


    }
}