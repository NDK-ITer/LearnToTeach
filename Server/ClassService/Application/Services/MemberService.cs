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
                };
                _unitOfWork.memberClassroomRepository.AddMember(member);
                _unitOfWork.SaveChange();
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
                var listMember = _unitOfWork.memberClassroomRepository.GeMemberClassroomByIdUser(memberModel.idMember);
                foreach (var member in listMember)
                {
                    member.Name = memberModel.nameMember;
                    member.Avatar = memberModel.avatar;
                    member.Description = memberModel.description;
                    _unitOfWork.memberClassroomRepository.UpdateMemberClassroom(member);
                    _unitOfWork.SaveChange();
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
