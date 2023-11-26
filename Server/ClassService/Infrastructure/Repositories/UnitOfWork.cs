using Domain.Interfaces;
using Infrastructure.Context;
using Microsoft.Extensions.Caching.Memory;

namespace Infrastructure.Repositories
{
    public interface IUnitOfWork
    {
        IClassroomRepository classroomRepository { get; }
        IMemberClassroomRepository memberClassroomRepository { get; }
        IMemberRepository memberRepository { get; }
        IExerciseRepository exerciseRepository { get; }
        IAnswerRepository answerRepository { get; }
        ILearningDocumentRepository learningDocumentRepository { get; }
        void SaveChange();
    }
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ClassroomDbContext _context;

        public UnitOfWork(ClassroomDbContext context, IMemoryCache memoryCache)
        {
            _context = context;
            classroomRepository = new ClassroomRepository(context, memoryCache);
            memberClassroomRepository = new MemberClassroomRepository(context, memoryCache);
            memberRepository = new MemberRepository(context, memoryCache);
            exerciseRepository = new ExerciseRepository(context, memoryCache);
            answerRepository = new AnswerRepository(context, memoryCache);
            learningDocumentRepository = new LearningDocumentRepository(context, memoryCache);
        }
        public IClassroomRepository classroomRepository { get; private set; }
        public IMemberClassroomRepository memberClassroomRepository { get; private set; }
        public IMemberRepository memberRepository { get; private set; }
        public IExerciseRepository exerciseRepository { get; private set; }
        public IAnswerRepository answerRepository { get; private set; }
        public ILearningDocumentRepository learningDocumentRepository { get; private set; }

        public void SaveChange()
        {
            _context.SaveChanges();
            _context.Dispose();
        }
    }
}
