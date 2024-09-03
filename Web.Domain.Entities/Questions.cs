using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Web.Application.Dto;

namespace Web.Domain.Entities
{
    public class Questions
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int QuestionsId { get; set; }
        public string Question { get; set; }
        public string Answers { get; set; }
        public int AnswerIndex { get; set; }
        public int Score { get; set; }
        public DateTime RegisterDate { get; set; }
        public bool FlgActive { get; set; }

        public int CategoryId {  get; set; }
        public Categories Categories { get; set; }

        public static Questions? QuizItem2Questions(QuizItem quizItem)
        {
            if (quizItem.AnswerIndex >= quizItem.Choices.Count || quizItem.AnswerIndex < 0)
                return null;

            if (!quizItem.CategoryId.HasValue)
                return null;

            Questions newQ = new Questions
            {
                Question = quizItem.Question,
                Answers = string.Join(", ", quizItem.Choices),
                AnswerIndex = quizItem.AnswerIndex,
                Score = quizItem.Score,
                RegisterDate = DateTime.Now,
                FlgActive = true,
                CategoryId = quizItem.CategoryId.Value
            };

            return newQ;
        }
    }
}
