using Application.Models.ModelsOfAnswer;
using Domain.Entities;
using Infrastructure.Context;
using Infrastructure.Repositories;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.IdentityModel.Tokens;

namespace Application.Services
{
    public interface IAnswerService
    {
        Tuple<string, Answer?> CreateAnswer(CreateAnswerModel uploadAnswer);
        Tuple<string, List<AnswerModel>?> GetListAnswer(string idExercise);
        Tuple<string, AnswerModel?> GetAnswerById(string idExercise, string idMember);
        Tuple<string, Answer?> UpdateAnswer(UpdateAnswerModel updateAnswer);
        Tuple<bool, string> DeleteAnswer(string idExercise, string idMember);
    }
    public class AnswerService : IAnswerService
    {
        private readonly IUnitOfWork _unitOfWork;

        public AnswerService(ClassroomDbContext context, IMemoryCache memoryCache)
        {
            _unitOfWork = new UnitOfWork(context, memoryCache);
        }

        public Tuple<string, Answer?> CreateAnswer(CreateAnswerModel uploadAnswer)
        {
            try
            {
                var answerNew = new Answer()
                {
                    IdExercise = uploadAnswer.IdExercise,
                    IdMember = uploadAnswer.IdMember,
                    Content = uploadAnswer.Content,
                    DateAnswer = DateTime.Now,
                    LinkFile = uploadAnswer.LinkFile,
                    FileName = uploadAnswer.FileName,
                };
                _unitOfWork.answerRepository.Add(answerNew);
                _unitOfWork.SaveChange();
                return new Tuple<string, Answer?>("Successful", answerNew);
            }
            catch (Exception)
            {
                return new Tuple<string, Answer?>("Error!", null);
            }
        }

        public Tuple<bool, string> DeleteAnswer(string idExercise, string idMember)
        {
            try
            {
                var answer = _unitOfWork.answerRepository.Find(p => p.IdExercise == idExercise && p.IdMember == idMember).FirstOrDefault();
                if (answer == null) return new Tuple<bool, string>(false, "this answer is not exist");
                _unitOfWork.answerRepository.Remove(answer);
                _unitOfWork.SaveChange();
                return new Tuple<bool, string>(true, "Successful");
            }
            catch (Exception)
            {
                return new Tuple<bool, string>(false, "Error!");
            }
        }

        public Tuple<string, AnswerModel?> GetAnswerById(string idExercise, string idMember)
        {
            try
            {
                var answer = _unitOfWork.answerRepository.Find(p => p.IdExercise == idExercise && p.IdMember == idMember).FirstOrDefault();
                if (answer == null) return new Tuple<string, AnswerModel?>("Not found", null);
                var answerModel = new AnswerModel()
                {
                    Content = answer.Content,
                    DateAnswer = answer.DateAnswer,
                    LinkFile = $"{answer.LinkFile}{answer.FileName}",
                };
                return new Tuple<string, AnswerModel?>("Found", answerModel);
            }
            catch (Exception)
            {
                return new Tuple<string, AnswerModel?>("Error!", null);
            }
        }

        public Tuple<string, List<AnswerModel>?> GetListAnswer(string idExercise)
        {
            try
            {
                var exercise = _unitOfWork.exerciseRepository.GetById(idExercise);
                var listAnswer = new List<AnswerModel>();
                foreach (var item in exercise.ListAnswer)
                {
                    listAnswer.Add(new AnswerModel()
                    {
                        Content = item.Content,
                        DateAnswer = item.DateAnswer,
                        LinkFile = $"{item.LinkFile}{item.FileName}",
                    });
                }
                return new Tuple<string, List<AnswerModel>?>("Successful", listAnswer);
            }
            catch (Exception)
            {
                return new Tuple<string, List<AnswerModel>?>("Error!", null);
            }
        }

        public Tuple<string, Answer?> UpdateAnswer(UpdateAnswerModel updateAnswer)
        {
            try
            {
                var answerUpdate = _unitOfWork.answerRepository.Find(p => p.IdExercise == updateAnswer.IdExercise && p.IdMember == updateAnswer.IdMember).FirstOrDefault();
                if (!updateAnswer.Content.IsNullOrEmpty()) answerUpdate.Content = updateAnswer.Content;
                answerUpdate.LinkFile = updateAnswer.LinkFile;
                answerUpdate.FileName = updateAnswer.FileName;
                _unitOfWork.answerRepository.Update(answerUpdate);
                _unitOfWork.SaveChange();
                return new Tuple<string, Answer?>("Successful", answerUpdate);
            }
            catch (Exception)
            {
                return new Tuple<string, Answer?>("Error!", null);
            }
        }
    }
}
