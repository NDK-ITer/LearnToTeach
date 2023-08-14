using Application.Requests;
using Domain.Entities;
using Infrastructure;
using Infrastructure.Context;
using Infrastructure.Repositories;
using XAct;

namespace Application.Services
{
    public interface IClassroomService
    {
        int CreateClassroom(ClassroomRequest classroomRequest);
        int UpdateClassroom(ClassroomRequest classroomRequest);
        int DeleteClassroom(string idClass);
        int DeleteMember(string idClassroom, string idMember);
    }
    public class ClassroomService : IClassroomService
    {
        private readonly IUnitOfWork _unitOfWork;
        public ClassroomService(ClassroomDbContext context)
        {
            _unitOfWork = new UnitOfWork(context);
        }

        public int CreateClassroom(ClassroomRequest classroomRequest)
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
                if (classroomRequest.isPrivate == true)
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

        public int DeleteClassroom(string idClass)
        {
            try
            {
                _unitOfWork.classroomRepository.DeleteClassroom(idClass);
                _unitOfWork.SaveChange();
                return 1;
            }
            catch (Exception)
            {
                return -1;
            }
        }

        public int DeleteMember(string idClassroom, string idMember)
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
                if (classroomRequest.isPrivate == true && classroomRequest.key.IsNullOrEmpty()) return 0;
                var classNeedUpdate = _unitOfWork.classroomRepository.GetById(classroomRequest.idClassroom);
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
    }
}
