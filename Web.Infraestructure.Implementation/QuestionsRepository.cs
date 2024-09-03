using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Web.Domain.Entities;
using Web.Infraestructure.Interfaces;

namespace Web.Infraestructure.Implementation
{
    /// <summary>
    /// QuestionsRepository
    /// </summary>
    public class QuestionsRepository : IQuestionsRepository
    {
        private readonly ApplicationDbContext _ApplicationDbContext;

        /// <summary>
        /// Constructor QuestionsRepository
        /// </summary>
        /// <param name="applicationDbContext"></param>
        public QuestionsRepository(ApplicationDbContext applicationDbContext)
        {
            _ApplicationDbContext = applicationDbContext;
        }

        /// <summary>
        /// GetQuestions
        /// </summary>
        /// <param name="categoryId"></param>
        /// <returns></returns>
        public async Task<List<Questions>> GetQuestions(int? categoryId)
        {
            List<Questions> questions;

            if (categoryId == null)
            {
                questions = await _ApplicationDbContext.Questions.Where(
                    q => q.FlgActive && q.Categories.FlgActive).ToListAsync<Questions>();
            }
            else
            {
                questions = await _ApplicationDbContext.Questions.Where(
                    q => q.FlgActive && q.Categories.FlgActive && q.CategoryId == categoryId).ToListAsync<Questions>();
            }

            return questions;
        }

        /// <summary>
        /// CreateQuestion
        /// </summary>
        /// <param name="question"></param>
        /// <returns></returns>
        public async Task<Tuple<int,Questions?>> CreateQuestion(Questions question)
        {
            // check if exists a question
            Questions? existQuestion = _ApplicationDbContext.Questions.Where(
                q => q.Question == question.Question && q.FlgActive).FirstOrDefault();

            if (existQuestion != null)
                return new Tuple<int, Questions?>(0, null);

            _ApplicationDbContext.Questions.Add(question);
            int rowsAffected = await _ApplicationDbContext.SaveChangesAsync();

            return new Tuple<int, Questions?>(rowsAffected, question);
        }

        /// <summary>
        /// DeleteQuestion
        /// </summary>
        /// <param name="questionId"></param>
        /// <returns></returns>
        public async Task<Tuple<int, Questions?>> DeleteQuestion(int questionId)
        {
            // check if exists a question
            Questions? deleteQuestion = _ApplicationDbContext.Questions.Where(
                q => q.QuestionsId == questionId && q.FlgActive && q.Categories.FlgActive).FirstOrDefault();

            if (deleteQuestion == null)
                return new Tuple<int, Questions?>(0, null);

            deleteQuestion.FlgActive = false;

            int rowsAffected = await _ApplicationDbContext.SaveChangesAsync();
 
            return new Tuple<int, Questions?>(rowsAffected, deleteQuestion);
        }
    }
}
