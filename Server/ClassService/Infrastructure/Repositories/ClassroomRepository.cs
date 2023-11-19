using Domain.Entities;
using Domain.Interfaces;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;

namespace Infrastructure.Repositories
{
    public class ClassroomRepository : GenericRepository<Classroom>, IClassroomRepository
    {
        public ClassroomRepository(ClassroomDbContext context, IMemoryCache memoryCache) : base(context, memoryCache)
        {
            _dbSet.Include(c => c.ListMemberClassroom).Load();
            _dbSet.Include(c => c.ListMember).Load();
            _keyValueCache = "ClassroomPublicMemoryCachingKey";
        }
        public void UpdateClassroom(Classroom classroom) => Update(classroom);
        public void RegisterClassroom(Classroom classroom) => Add(classroom);
        public void DeleteClassroom(string idClassroom)
        {
            if (idClassroom == null) return;
            if (_memoryCache.TryGetValue(_keyValueCache, out List<Classroom> classrooms))
            {
                var classroomDelete = classrooms.FirstOrDefault(c => c.Id == idClassroom);
                if (classroomDelete != null)
                {
                    classrooms.Remove(classroomDelete);
                    Remove(classroomDelete);
                }
                else
                {
                    classroomDelete = _dbSet.Find(idClassroom);
                    Remove(classroomDelete);
                }
                
            }
            else
            {
                var classroomDelete = _dbSet.Find(idClassroom);
                Remove(classroomDelete);
            }
            
        }
        public int CheckClassroomIsPrivate(Classroom classroom)
        {
            if (classroom == null) return -1;
            if (classroom.IsPrivate == true) return 1;
            else return 0;
        }
        public Classroom? GetClassroomById(string id)
        {
            if (id == null) return null;
            if (_memoryCache.TryGetValue(_keyValueCache, out List<Classroom> listClassroom))
            {
                var classroom = listClassroom.FirstOrDefault(c => c.Id == id);
                if (classroom == null) 
                {
                    classroom = _dbSet.Find(id);
                    if (classroom != null)
                    {
                        listClassroom.Add(classroom);
                    }
                    return null;
                } 
                return classroom;
            }
            else
            {
                var classroom = _dbSet.Find(id);
                var classrooms = new List<Classroom>();
                if (classroom != null)
                {
                    classrooms.Add(classroom);
                    _memoryCache.Set(_keyValueCache,classrooms,_options);
                    return classroom;
                }
                return null;
            }
        }
        public Classroom? GetClassroomByName(string name)
        {
            if (name == null) return null;
            if (_memoryCache.TryGetValue(_keyValueCache, out List<Classroom> listClassroom))
            {
                var classroom = listClassroom.FirstOrDefault(c => c.Name == name);
                if (classroom == null)
                {
                    classroom = _dbSet.FirstOrDefault(c => c.Name == name);
                    if (classroom != null)
                    {
                        listClassroom.Add(classroom);
                    }
                    return null;
                }
                return classroom;
            }
            else
            {
                var classroom = _dbSet.FirstOrDefault(c => c.Name == name);
                var classrooms = new List<Classroom>();
                if (classroom != null)
                {
                    classrooms.Add(classroom);
                    _memoryCache.Set(_keyValueCache, classrooms, _options);
                    return classroom;
                }
                return null;
            }
        }
        public List<Classroom> GetAllClassrooms() => GetAll().ToList();
        public List<Classroom>? GetClassroomsArePublic()
        {
            if (_memoryCache.TryGetValue(_keyValueCache, out List<Classroom> listClassroom))
            {
                return listClassroom;
            }
            else
            {
                var classrooms = Find(c => c.IsPrivate == false).ToList();
                if (classrooms != null)
                {
                    _memoryCache.Set(_keyValueCache, classrooms, _options);
                    return classrooms;
                }
                return null;
            }
        }
        public List<Classroom>? GetClassroomsArePrivate()
        {
            return Find(c => c.IsPrivate == true).ToList();
        }
    }
}
