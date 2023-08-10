using Application.Requests;
using Domain.Entities;
using Infrastructure;
using Infrastructure.Context;
using Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public interface IClassroomService
    {
        int CreateClassroom(RegisterClassroomRequest registerClassroomRequest);
        int UpdateClassroom(Classroom classroom);
        int DeleteClassroom(string idClass);
        int ChangeToPrivate(string idClass, string key);
        int ChangeToPublic(string idClass);
        int AddMember(string idUser);
        int AddRangeUser(IEnumerable<string> idUsers);
        int DeleteMember(string idUser);
        int DeleteRangeMemeber(IEnumerable<string> idUsers);
    }
    public class ClassroomService : IClassroomService
    {
        private readonly IUnitOfWork _unitOfWork;
        public ClassroomService(ClassroomDbContext context)
        {
            _unitOfWork = new UnitOfWork(context);
        }

        public int AddMember(string idUser)
        {
            throw new NotImplementedException();
        }

        public int AddRangeUser(IEnumerable<string> idUsers)
        {
            throw new NotImplementedException();
        }

        public int ChangeToPrivate(string idClass, string key)
        {
            throw new NotImplementedException();
        }

        public int ChangeToPublic(string idClass)
        {
            throw new NotImplementedException();
        }

        public int CreateClassroom()
        {
            throw new NotImplementedException();
        }

        public int CreateClassroom(RegisterClassroomRequest registerClassroomRequest)
        {
            try
            {
                var idClassroom = Guid.NewGuid().ToString();
                var classroom = new Classroom()
                {
                    Id = idClassroom,
                    CreateDate = DateTime.Now,
                    Name = registerClassroomRequest.nameClassroom,
                    IdUserHost = registerClassroomRequest.idUser,
                    Description = string.Empty,
                    KeyHash = string.Empty,
                };
                if (registerClassroomRequest.isPrivate == true)
                {
                    classroom.IsPrivate = true;
                    classroom.KeyHash = KeyHash.Hash(registerClassroomRequest.key);
                }
                if (registerClassroomRequest.Description != null) classroom.Description = registerClassroomRequest.Description;
                if (registerClassroomRequest.idMembers != null)
                {
                    var listUserTemp = new List<ClassroomDetail>();
                    foreach (var item in registerClassroomRequest.idMembers)
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
                    _unitOfWork.classroomRepository.Add(classroom);
                }
                return 1;
            }
            catch (Exception)
            {
                return -1;
            }
            
        }

        public int DeleteClassroom(string idClass)
        {
            throw new NotImplementedException();
        }

        public int DeleteMember(string idUser)
        {
            throw new NotImplementedException();
        }

        public int DeleteRangeMemeber(IEnumerable<string> idUsers)
        {
            throw new NotImplementedException();
        }

        public int UpdateClassroom(Classroom classroom)
        {
            throw new NotImplementedException();
        }
    }
}
