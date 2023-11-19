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
        int AddMember(UpdateMemberModel memberModel, string idClassroom);
        int UpdateInforMember(UpdateMemberModel memberModel);
    }
    public class MemberService : IMemberService
    {
        private readonly IUnitOfWork _unitOfWork;
        public MemberService(ClassroomDbContext context, IMemoryCache memoryCache)
        {
            _unitOfWork = new UnitOfWork(context, memoryCache);
        }
        public int AddMember(UpdateMemberModel memberModel, string idClassroom)
        {
            if (memberModel.IsNull() || idClassroom.IsNullOrEmpty()) return 0;
            try
            {
                var classroom = _unitOfWork.classroomRepository.Find(p => p.Id == idClassroom).FirstOrDefault();
                if (classroom == null) return 0;
                var member = _unitOfWork.memberRepository.Find(p => p.IdMember == memberModel.idMember).FirstOrDefault();
                if (member == null)
                {
                    member = new Member()
                    {
                        IdMember = memberModel.idMember,
                        Name = memberModel.nameMember,
                        Avatar = memberModel.avatar,
                        LinkAvatar = memberModel.linkAvatar,
                    };
                }
                var memberClass = new MemberClassroom()
                {
                    IdClass = classroom.Id,
                    IdUser = member.IdMember,
                    Role = "Member".ToUpper(),
                    Description = "",
                };
                classroom.ListMember.Add(member);
                classroom.ListMemberClassroom.Add(memberClass);
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
        public int UpdateInforMember(UpdateMemberModel memberModel)
        {
            if (memberModel.IsNull()) return 0;
            try
            {
                var member = _unitOfWork.memberRepository.Find(p => p.IdMember == memberModel.idMember).FirstOrDefault();
                if (member != null)
                {
                    if (!memberModel.nameMember.IsNullOrEmpty()) { member.Name = memberModel.nameMember; }
                    if (!memberModel.avatar.IsNullOrEmpty()) { member.Avatar = memberModel.avatar; }
                    if (!memberModel.linkAvatar.IsNullOrEmpty()) { member.LinkAvatar = memberModel.linkAvatar; }
                    _unitOfWork.memberRepository.UpdateMember(member);
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
