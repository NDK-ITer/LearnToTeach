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
        Tuple<string, Exercise?> CreateExercise(CreateExerciseModel exercise);
        Member GetMemberById(string id);
        int AddMember(UpdateMemberModel memberModel, string idClassroom);
        int UpdateInforMember(UpdateMemberModel memberModel);
        int DeleteMember(string idMember);
        bool IsHost(string idMember, string idClassroom);
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
                    Role = "Member",
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

        public int DeleteMember(string idMember)
        {
            try
            {
                if (idMember.IsNullOrEmpty()) return 0;
                var member = _unitOfWork.memberRepository.Find(p => p.IdMember == idMember).FirstOrDefault();
                if (member == null) return 0;
                _unitOfWork.memberRepository.Remove(member);
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
            if (memberModel.IsNull() || memberModel.idMember.IsNullOrEmpty()) return 0;
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
        
        public Member? GetMemberById(string id)
        {
            try
            {
                var member = _unitOfWork.memberRepository.GetById(id);
                if (member != null)
                {
                    return member;
                }
                return null;
            }
            catch (Exception)
            {

                return null;
            }
        }

        public bool IsHost(string idMember, string idClassroom)
        {
            if (idMember.IsNullOrEmpty() || idClassroom.IsNullOrEmpty()) return false;
            var classroom = _unitOfWork.classroomRepository.GetClassroomById(idClassroom);
            var memberClass = classroom.ListMemberClassroom.FirstOrDefault(p => p.IdUser == idMember);
            if (memberClass == null) return false;
            if (memberClass.Role == "Host")
            {
                return true;
            }
            return false;
        }

        public Tuple<string,Exercise?> CreateExercise(CreateExerciseModel exerciseInput)
        {
            try
            {
                if (exerciseInput == null || exerciseInput.IdClassroom.IsNullOrEmpty() || exerciseInput.IdMember.IsNullOrEmpty()) { return new Tuple<string, Exercise?>("input is not is valid", null);}
                var classroom = _unitOfWork.classroomRepository.GetById(exerciseInput.IdClassroom);
                if (classroom == null) return new Tuple<string, Exercise?>("classroom is not exist", null);
                //var checkHost = IsHost(exerciseInput.IdMember, exerciseInput.IdClassroom);
                //if (!checkHost) return new Tuple<string, Exercise?>("Member isn't \"Host\"", null);
                var exercise = new Exercise()
                {
                    //IdExercise = Guid.NewGuid().ToString(),
                    DeadLine = exerciseInput.Deadline,
                    Name = exerciseInput.Name,
                    LinkFile = exerciseInput.LinkFile,
                    FileName = exerciseInput.FileName,
                    Description = exerciseInput.Description,
                    Classroom = classroom,
                };
                if (exerciseInput.IdExercise.IsNullOrEmpty()) exercise.IdExercise = exerciseInput.IdExercise;
                exercise.IdExercise = Guid.NewGuid().ToString();
                _unitOfWork.exerciseRepository.Add(exercise);
                _unitOfWork.SaveChange();
                _unitOfWork.Dispose();
                return new Tuple<string, Exercise?>("Successful", exercise);
            }
            catch (Exception)
            {
                return new Tuple<string, Exercise?>("Error!", null);
            }
        }
    }
}
