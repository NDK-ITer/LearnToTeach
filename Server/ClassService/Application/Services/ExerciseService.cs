using Application.Models.ModelsOfExercise;
using Domain.Entities;
using Infrastructure.Context;
using Infrastructure.Repositories;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.IdentityModel.Tokens;

namespace Application.Services
{
    public interface IExerciseService
    {
        Exercise GetExerciseById(string idExercise);
        Tuple<string,Exercise?> UpdateExercise(UpdateExerciseModel updateAnswerModel);
    }
    public class ExerciseService : IExerciseService
    {
        private readonly IUnitOfWork _unitOfWork;
        public ExerciseService(ClassroomDbContext context, IMemoryCache memoryCache)
        {
            _unitOfWork = new UnitOfWork(context, memoryCache);
        }

        public Exercise? GetExerciseById(string idExercise)
        {
            try
            {
                var exercise =_unitOfWork.exerciseRepository.GetById(idExercise);
                return exercise;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public Tuple<string, Exercise?>? UpdateExercise(UpdateExerciseModel updateAnswerModel)
        {
            try
            {
                var exercise = _unitOfWork.exerciseRepository.GetById(updateAnswerModel.IdExercise);
                if (exercise == null) return new Tuple<string, Exercise?>("This exercise is not exist",null);
                if (!updateAnswerModel.Name.IsNullOrEmpty()) exercise.Name = updateAnswerModel.Name;
                if (!updateAnswerModel.Description.IsNullOrEmpty()) exercise.Description = updateAnswerModel.Description;
                if ((updateAnswerModel.Deadline > exercise.DeadLine)||updateAnswerModel.Deadline != null) exercise.DeadLine = updateAnswerModel.Deadline;
                _unitOfWork.exerciseRepository.Update(exercise);
                _unitOfWork.SaveChange();
                return new Tuple<string, Exercise?>("Update is successful", exercise);
            }
            catch (Exception e)
            {
                return new Tuple<string,Exercise?>(e.Message,null);
            }
        }
    }
}
