using Infrastructure.Context;
using Microsoft.Extensions.Caching.Memory;

namespace Application.Services
{
    public interface IUnitOfWork_ClassroomService
    {
        IClassroomService _classroomService { get; }
        IMemberService _memberService { get; }
        IExerciseService _exerciseService { get; }
        IAnswerService _answerService { get; }
        ILearningDocumentService _learningDocumentService { get; }
    }
    public class UnitOfWork_ClassroomService : IUnitOfWork_ClassroomService
    {
        public UnitOfWork_ClassroomService(ClassroomDbContext context, IMemoryCache memoryCache)
        {
            _classroomService = new ClassroomService(context, memoryCache);
            _memberService = new MemberService(context, memoryCache);
            _exerciseService = new ExerciseService(context, memoryCache);
            _answerService = new AnswerService(context, memoryCache);
            _learningDocumentService = new LearningDocumentService(context, memoryCache);
        }

        public IClassroomService _classroomService { get; private set; }
        public IMemberService _memberService { get; private set; }
        public IExerciseService _exerciseService { get; private set; }
        public IAnswerService _answerService { get; private set; }
        public ILearningDocumentService _learningDocumentService { get; private set; }
    }
}
