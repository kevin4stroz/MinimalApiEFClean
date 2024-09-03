using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Web.Domain.Entities;

namespace Web.Infraestructure.Interfaces
{
    public interface IQuestionsRepository
    {
        Task<List<Questions>> GetQuestions(int? categoryId);
        Task<Tuple<int, Questions?>> CreateQuestion(Questions question);
        Task<Tuple<int, Questions?>> DeleteQuestion(int questionId);
    }
}
