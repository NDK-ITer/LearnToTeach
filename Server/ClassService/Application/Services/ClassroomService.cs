﻿using Application.Models;
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
        Classroom CreateClassroom(AddClassroomModel classroomRequest);
        int UpdateClassroom(ClassroomRequest classroomRequest);
        int UpdateClassroom(UpdateClassroomModel classroomUpdateModel);
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

        public Classroom? CreateClassroom(AddClassroomModel classroomRequest) //To create classroom with "classroomRequest"
        {
            try
            {
                //Create a classroom
                var idClassroom = Guid.NewGuid().ToString();
                var member = _unitOfWork.memberRepository.GetById(classroomRequest.idUserHost);
                if (member == null)
                {
                    member = new Member()
                    {
                        IdMember = classroomRequest.idUserHost,
                        Name = string.Empty,
                        Avatar = string.Empty,
                        LinkAvatar = string.Empty
                    };
                }
                var classroom = new Classroom()
                {
                    Id = idClassroom,
                    Name = classroomRequest.name,
                    Description = classroomRequest.description,
                };
                classroom.ListMemberClassroom = new List<MemberClassroom>()
                {
                    new MemberClassroom()
                    {
                        IdClass = classroomRequest.idClassroom,
                        IdUser = classroomRequest.idUserHost,
                        Description = classroomRequest.description,
                        Role = "Host"
                    }
                };
                classroom.ListMember = new List<Member>()
                {
                    member
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
                var classroomDetail = classroom.ListMemberClassroom.FirstOrDefault(c => c.IdUser == idMember);
                classroom.ListMemberClassroom.Remove(classroomDetail);

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

        public int UpdateClassroom(UpdateClassroomModel classroomUpdateModel)
        {
            try
            {
                if (classroomUpdateModel.IsNull()) return 0;
                if (classroomUpdateModel.idClassroom.IsNullOrEmpty()) return 0;
                var classroom = _unitOfWork.classroomRepository.Find(p => p.Id == classroomUpdateModel.idClassroom).FirstOrDefault();
                var member = _unitOfWork.memberRepository.Find(p => p.IdMember == classroomUpdateModel.idUserHost).FirstOrDefault();
                if (!classroom.IsNull())
                {
                    if (!classroomUpdateModel.linkAvatar.IsNullOrEmpty()) classroom.LinkAvatar = classroomUpdateModel.linkAvatar;
                    if (!classroomUpdateModel.avatarClassroom.IsNullOrEmpty()) classroom.Avatar = classroomUpdateModel.avatarClassroom;
                    _unitOfWork.classroomRepository.Update(classroom);
                    _unitOfWork.SaveChange();
                    _unitOfWork.Dispose();
                    return 1;
                }
                else if (!member.IsNull()) 
                {
                    if (!classroomUpdateModel.linkAvatar.IsNullOrEmpty()) member.LinkAvatar = classroomUpdateModel.linkAvatar;
                    if (!classroomUpdateModel.nameUserHost.IsNullOrEmpty()) member.Name = classroomUpdateModel.nameUserHost;
                    if (!classroomUpdateModel.avatarUserHost.IsNullOrEmpty()) member.Avatar = classroomUpdateModel.avatarUserHost;
                    _unitOfWork.classroomRepository.Update(classroom);
                    _unitOfWork.SaveChange();
                    _unitOfWork.Dispose();
                    return 1;
                }
                return 0;
            }
            catch (Exception)
            {
                return -1;
            }
        }
    }
}
