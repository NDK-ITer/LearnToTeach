using Domain.Entities;
using Domain.Interfaces;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class ClassroomDetailRepository :GenericRepository<ClassroomDetail> , IClassroomDetailRepository
    {
        public ClassroomDetailRepository(ClassroomDbContext context) : base(context)
        {
            _dbSet.Include(c => c.classroom).Load();
        }

        public void AddClassroomDetail(ClassroomDetail classroomDetail) => Add(classroomDetail);
        

        public void AddRangeClassroomDetail(IEnumerable<ClassroomDetail> classroomDetails) => AddRange(classroomDetails);


        public void DeleteRangeClassroomDetail(IEnumerable<ClassroomDetail> classroomDetails) => RemoveRange(classroomDetails);



        public IEnumerable<ClassroomDetail>? GetClassroomDetailsByIdUser(string idClass)
        {
            return Find(c => c.IdClass == idClass);
        }

        public void UpdateClassroomDetail(ClassroomDetail classroomDetail) => Update(classroomDetail);
        

        
    }
}
