using Application.Requests;
using Application.Responses;
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
        ClassroomResponse GetClassroomById(string idClassroom);
        ClassroomResponse GetClassroomByName(string nameClassroom);
        List<ClassroomResponse> GetAllClassroom();
        List<ClassroomResponse> GetAllClassroomPublic();
        int CreateClassroom(ClassroomRequest classroomRequest);
        int UpdateClassroom(ClassroomRequest classroomRequest);
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
        
        public int CreateClassroom(ClassroomRequest classroomRequest) //To create classroom with "classroomRequest"
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

                //check and add member to this classroom
                if (classroomRequest.Members != null)
                {
                    var listUserTemp = new List<ClassroomDetail>();
                    foreach (var item in classroomRequest.Members)
                    {
                        var classroomDetail = new ClassroomDetail() 
                        {
                            IdClass = idClassroom,
                            IdUser = item.idMember,
                            Description = item.description,
                            Role = item.role,
                        };
                        listUserTemp.Add(classroomDetail);
                    }
                    classroom.ListUserId = listUserTemp;
                }

                //add and save classroom to database
                _unitOfWork.classroomRepository.RegisterClassroom(classroom);
                _unitOfWork.SaveChange();
                return 1;
            }
            catch (Exception)
            {
                return -1;
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

        public List<ClassroomResponse>? GetAllClassroom()
        {
            try
            {
                var listClassroom = _unitOfWork.classroomRepository.GetAllClassrooms();
                var listClassroomResponse = new List<ClassroomResponse>();
                foreach (var item in listClassroom) 
                {
                    listClassroomResponse.Add(new ClassroomResponse(item));
                }
                if (!listClassroomResponse.IsNullOrEmpty())
                    return listClassroomResponse;
                return null;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public List<ClassroomResponse>? GetAllClassroomPublic()
        {
            try
            {
                var listClassroom = _unitOfWork.classroomRepository.GetClassroomsArePublic();
                var listClassroomResponse = new List<ClassroomResponse>();
                foreach (var item in listClassroom)
                {
                    listClassroomResponse.Add(new ClassroomResponse(item));
                }
                if (!listClassroomResponse.IsNullOrEmpty())
                    return listClassroomResponse;
                return null;
            }
            catch (Exception)
            {

                return null;
            }
        }

        public ClassroomResponse? GetClassroomById(string idClassroom)
        {
            try
            {
                var classroom = _unitOfWork.classroomRepository.GetClassroomById(idClassroom);
                var classroomResponse = new ClassroomResponse(classroom);
                if (classroom != null)
                    return classroomResponse;
                return null;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public ClassroomResponse? GetClassroomByName(string nameClassroom)
        {
            try
            {
                var classroom = _unitOfWork.classroomRepository.GetClassroomByName(nameClassroom);
                var classroomResponse = new ClassroomResponse(classroom);
                if (classroom != null)
                    return classroomResponse;
                return null;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public int RemoveMember(string idClassroom, string idMember)
        //To remove a member of this classroom with "idClassroom" and "idMember"
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
        //To update classroom With "classroomRequest"
        {
            try
            {
                //check "classroomRequest"
                if (classroomRequest.idClassroom == string.Empty) return 0;

                //Find classroom need to update
                var classNeedUpdate = _unitOfWork.classroomRepository.GetById(classroomRequest.idClassroom);
                
                //update
                if (classroomRequest.isPrivate == true && !classroomRequest.key.IsNullOrEmpty())
                {
                    classNeedUpdate.KeyHash = KeyHash.Hash(classroomRequest.key);
                    classNeedUpdate.IsPrivate = true;
                }
                classroomRequest.UpdateToClassroom(classNeedUpdate);

                //Save to database
                _unitOfWork.classroomRepository.UpdateClassroom(classNeedUpdate);
                _unitOfWork.SaveChange();
                return 1;
            }
            catch (Exception)
            {

                return -1;
            }
        }
    }
}
