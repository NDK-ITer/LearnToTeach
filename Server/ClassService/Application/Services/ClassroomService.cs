using Application.Models;
using Application.Requests;
using Domain.Entities;
using Infrastructure;
using Infrastructure.Context;
using Infrastructure.Repositories;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.IdentityModel.Tokens;
using XAct;

namespace Application.Services
{
    public interface IClassroomService
    {
        Classroom GetClassroomById(string idClassroom);
        Classroom GetClassroomByName(string nameClassroom);
        List<Classroom> GetAllClassroom();
        List<Classroom> GetAllClassroomPublic();
        Classroom CreateClassroom(ClassroomRequest classroomRequest);
        int UpdateClassroom(ClassroomRequest classroomRequest);
        int UpdateClassroom(ClassroomUpdateModel classroomUpdateModel);
        int DeleteClassroom(string idClass);
        int RemoveMember(string idClassroom, string idMember);
    }
    public class ClassroomService : IClassroomService
    {
        private readonly IUnitOfWork _unitOfWork;
        public ClassroomService(ClassroomDbContext context, IMemoryCache memoryCache)
        {
            _unitOfWork = new UnitOfWork(context, memoryCache);
        }

        public Classroom? CreateClassroom(ClassroomRequest classroomRequest) //To create classroom with "classroomRequest"
        {
            try
            {
                //Create a classroom
                var idClassroom = Guid.NewGuid().ToString();
                var classroom = new Classroom()
                {
                    Id = idClassroom,
                    Name = classroomRequest.name,
                    IdUserHost = classroomRequest.idUserHost,
                    Description = classroomRequest.description,
                };
                if (classroomRequest.isPrivate == true && !classroomRequest.key.IsNullOrEmpty())
                {
                    classroom.IsPrivate = true;
                    classroom.KeyHash = KeyHash.Hash(classroomRequest.key);
                }
                else
                {
                    classroom.IsPrivate = false;
                    classroom.KeyHash = null;
                }
                //add and save classroom to database
                _unitOfWork.classroomRepository.RegisterClassroom(classroom);
                _unitOfWork.SaveChange();
                return classroom;
            }
            catch (Exception)
            {
                return null;
            }

        }

        public int DeleteClassroom(string idClassroom)//To delete classroom with "idClassroom"
        {
            try
            {
                _unitOfWork.classroomRepository.DeleteClassroom(idClassroom);
                _unitOfWork.SaveChange();
                return 1;
            }
            catch (Exception)
            {
                return -1;
            }
        }

        public List<Classroom>? GetAllClassroom()
        {
            try
            {
                var listClassroom = _unitOfWork.classroomRepository.GetAllClassrooms();
                if (!listClassroom.IsNullOrEmpty())
                    return listClassroom;
                return null;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public List<Classroom>? GetAllClassroomPublic()
        {
            try
            {
                var listClassroom = _unitOfWork.classroomRepository.GetClassroomsArePublic();

                if (!listClassroom.IsNullOrEmpty())
                    return listClassroom;
                return null;
            }
            catch (Exception)
            {

                return null;
            }
        }

        public Classroom? GetClassroomById(string idClassroom)
        {
            try
            {
                var classroom = _unitOfWork.classroomRepository.GetClassroomById(idClassroom);
                if (classroom != null)
                    return classroom;
                return null;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public Classroom? GetClassroomByName(string nameClassroom)
        {
            try
            {
                var classroom = _unitOfWork.classroomRepository.GetClassroomByName(nameClassroom);
                if (classroom != null)
                {
                    return classroom;
                }
                return null;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public int RemoveMember(string idClassroom, string idMember)
        {
            try
            {
                //find classroom
                var classroom = _unitOfWork.classroomRepository.GetById(idClassroom);
                if (classroom == null) return 0;

                //delete member
                var classroomDetail = classroom.ListUserId.FirstOrDefault(c => c.IdUser == idMember);
                classroom.ListUserId.Remove(classroomDetail);

                //update and save change
                _unitOfWork.classroomRepository.Update(classroom);
                _unitOfWork.SaveChange();
                return 1;
            }
            catch (Exception)
            {
                return -1;
            }
        }

        public int UpdateClassroom(ClassroomRequest classroomRequest)
        {
            try
            {
                if (classroomRequest.idClassroom == string.Empty) return 0;
                var classNeedUpdate = _unitOfWork.classroomRepository.Find(p => p.Id == classroomRequest.idClassroom).FirstOrDefault();
                if (classroomRequest.isPrivate == true && !classroomRequest.key.IsNullOrEmpty())
                {
                    classNeedUpdate.KeyHash = KeyHash.Hash(classroomRequest.key);
                    classNeedUpdate.IsPrivate = true;
                }
                classroomRequest.UpdateToClassroom(classNeedUpdate);
                _unitOfWork.classroomRepository.UpdateClassroom(classNeedUpdate);
                _unitOfWork.SaveChange();
                return 1;
            }
            catch (Exception)
            {

                return -1;
            }
        }

        public int UpdateClassroom(ClassroomUpdateModel classroomUpdateModel)
        {
            try
            {
                if (classroomUpdateModel.IsNull()) return 0;
                var classroom = _unitOfWork.classroomRepository.Find(p => p.Id == classroomUpdateModel.idClassroom).FirstOrDefault();
                if (classroom.IsNull()) return 0;
                if (!classroomUpdateModel.nameUserHost.IsNullOrEmpty()) classroom.NameUserHost = classroomUpdateModel.nameUserHost;
                if (!classroomUpdateModel.avatarUserHost.IsNullOrEmpty()) classroom.AvatarUserHost = classroomUpdateModel.avatarUserHost;
                _unitOfWork.classroomRepository.Update(classroom);
                _unitOfWork.SaveChange();
                _unitOfWork.Dispose();
                return 1;
            }
            catch (Exception)
            {
                return -1;
            }
        }
    }
}
