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
        int CreateClassroom(CreateClassroomRequest registerClassroomRequest);
        int UpdateClassroom(UpdateClassroomRepuest updateClassroomRepuest);
        int DeleteClassroom(string idClass);
        int AddMember(string idClassroom, MemberClassroomRequest member);
        int AddRangeUser(string idClassroom, IEnumerable<string> idUsers);
        int DeleteMember(string idUser);
        int DeleteRangeMember(IEnumerable<string> idUsers);
    }
    public class ClassroomService : IClassroomService
    {
        private readonly IUnitOfWork _unitOfWork;
        public ClassroomService(ClassroomDbContext context)
        {
            _unitOfWork = new UnitOfWork(context);
        }

        public int AddMember(string idClassroom, MemberClassroomRequest member)
        {
            try
            {
                if (idClassroom == null) { return 0; }
                if (member == null) { return 0; }

                var classroom = _unitOfWork.classroomRepository.GetClassroomById(idClassroom);
                if (classroom == null) { return 0; }

                var classroomDetail = new ClassroomDetail();
                member.ChangeToClassroomDetail(classroomDetail);
                _unitOfWork.classroomRepository.AddMember(classroom, classroomDetail);
                _unitOfWork.SaveChange();
                return 1;
            }
            catch (Exception)
            {
                return -1;
            }
        }

        public int AddRangeUser(string idClassroom, IEnumerable<string> idUsers)
        {
            throw new NotImplementedException();
        }
        
        public int CreateClassroom(CreateClassroomRequest createClassroomRequest)
        {
            try
            {
                var idClassroom = Guid.NewGuid().ToString();
                var classroom = new Classroom()
                {
                    Id = idClassroom,
                    CreateDate = DateTime.Now,
                    Name = createClassroomRequest.nameClassroom,
                    IdUserHost = createClassroomRequest.idUser,
                    Description = string.Empty,
                    KeyHash = string.Empty,
                };
                if (createClassroomRequest.isPrivate == true)
                {
                    classroom.IsPrivate = true;
                    classroom.KeyHash = KeyHash.Hash(createClassroomRequest.key);
                }
                if (createClassroomRequest.Description != null) classroom.Description = createClassroomRequest.Description;
                if (createClassroomRequest.idMembers != null)
                {
                    var listUserTemp = new List<ClassroomDetail>();
                    foreach (var item in createClassroomRequest.idMembers)
                    {
                        var classroomDetail = new ClassroomDetail() 
                        {
                            IdClass = idClassroom,
                            IdUser = item,
                            Description = null,
                            Role = null,
                        };
                        listUserTemp.Add(classroomDetail);
                    }
                    IEnumerable<ClassroomDetail> listUser = listUserTemp;
                    classroom.ListUserId = listUser;
                }
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

        public int DeleteMember(string idUser)
        {
            throw new NotImplementedException();
        }

        public int DeleteRangeMember(IEnumerable<string> idUsers)
        {
            throw new NotImplementedException();
        }

        public int UpdateClassroom(UpdateClassroomRepuest updateClassroomRepuest)
        {
            try
            {
                if (updateClassroomRepuest.idClassroom == string.Empty) return 0;
                if (updateClassroomRepuest.isPrivate == true && updateClassroomRepuest.key.IsNullOrEmpty()) return 0;
                var classNeedUpdate = _unitOfWork.classroomRepository.GetById(updateClassroomRepuest.idClassroom);
                updateClassroomRepuest.UpdateToClassroom(classNeedUpdate);
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
