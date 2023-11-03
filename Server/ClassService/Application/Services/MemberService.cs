using Application.Models;
using Domain.Entities;
using Infrastructure.Context;
using Infrastructure.Repositories;
using Microsoft.Extensions.Caching.Memory;
using XAct;

namespace Application.Services
{
    public interface IMemberService
    {
        int AddMember(MemberModel memberModel, string idClassroom);
        int UpdateInforMember(MemberModel memberModel);
    }
    public class MemberService : IMemberService
    {
        private readonly IUnitOfWork _unitOfWork;
        public MemberService(ClassroomDbContext context, IMemoryCache memoryCache)
        {
            _unitOfWork = new UnitOfWork(context, memoryCache);
        }
        public int AddMember(MemberModel memberModel, string idClassroom)
        {
            if (memberModel.IsNull() || idClassroom.IsNullOrEmpty()) return 0;
            try
            {
                var member = new MemberClassroom()
                {
                    IdClass = idClassroom,
                    IdUser = memberModel.idMember,
                    Name = memberModel.nameMember,
                    Avatar = memberModel.avatar,
                    Role = memberModel.role,
                    Description = memberModel.description,
                    classroom = _unitOfWork.classroomRepository.GetClassroomById(idClassroom)
                };
                _unitOfWork.memberClassroomRepository.AddMember(member);
                _unitOfWork.SaveChange();
                _unitOfWork.Dispose();
                return 1;
            }
            catch (Exception)
            {

                return -1;
            }
        }
        public int UpdateInforMember(MemberModel memberModel)
        {
            if (memberModel.IsNull()) return 0;
            try
            {
                var members = _unitOfWork.memberClassroomRepository.GeMemberClassroomByIdUser(memberModel.idMember);
                foreach (var member in members)
                {
                    bool flat = false;
                    if (memberModel.nameMember != null) { member.Name = memberModel.nameMember; flat = true; }
                    if (memberModel.avatar != null) { member.Avatar = memberModel.avatar; flat = true; }
                    if (memberModel.role != null) { member.Role = memberModel.role; flat = true; }
                    if (memberModel.description != null) { member.Description = memberModel.description; flat = true; }
                    if (flat)
                    {
                        _unitOfWork.memberClassroomRepository.UpdateMemberClassroom(member);
                        _unitOfWork.SaveChange();
                        _unitOfWork.Dispose();
                    }
                }
                return 1;
            }
            catch (Exception)
            {
                return -1;
            }
        }
    }
}
