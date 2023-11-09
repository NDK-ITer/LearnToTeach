using Domain.Entities;
using Domain.Interfaces;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.IdentityModel.Tokens;
using System.Dynamic;
using XAct;

namespace Infrastructure.Repositories
{
    public class MemberClassroomRepository : GenericRepository<MemberClassroom>, IMemberClassroomRepository
    {
        public MemberClassroomRepository(ClassroomDbContext context, IMemoryCache memoryCache) : base(context, memoryCache)
        {
            _keyValueCache = "MemberClassroomPublicMemoryCachingKey";
        }
        public void AddMember(MemberClassroom memberClassroom) => Add(memberClassroom);
        public List<MemberClassroom>? GeMemberClassroomByIdUser(string idMemberClassroom)
        {
            if (idMemberClassroom == null) return null;
            if (_memoryCache.TryGetValue(_keyValueCache, out List<MemberClassroom> listMemberClassroomCache))
            {
                var meberClassroom = listMemberClassroomCache.Where(c => c.IdUser == idMemberClassroom).ToList();
                if (meberClassroom == null)
                {
                    meberClassroom = _dbSet.Where(p => p.IdUser == idMemberClassroom).ToList();
                    if (meberClassroom != null)
                    {
                        listMemberClassroomCache.AddRange(meberClassroom);
                    }
                    return null;
                }
                return meberClassroom;
            }
            else
            {
                var listMemberClassroom = _dbSet.AsNoTracking().Where(p => p.IdUser == idMemberClassroom).ToList();
                var listMemberClassroomCacheInitial = new List<MemberClassroom>();
                if (listMemberClassroom != null)
                {
                    listMemberClassroomCacheInitial.AddRange(listMemberClassroom);
                    _memoryCache.Set(_keyValueCache, listMemberClassroomCacheInitial, _options);
                    return listMemberClassroom;
                }
                return null;
            }
        }
        public void UpdateMemberClassroom(MemberClassroom memberClassroom)
        {
            var member = _dbSet.FirstOrDefault(p => p.IdUser == memberClassroom.IdUser && p.IdClass == memberClassroom.IdClass);
            if (member != null)
            {
                member.Name = memberClassroom.Name;
                member.Avatar = memberClassroom.Avatar;
                member.Role = memberClassroom.Role;
                member.Description = memberClassroom.Description;
                Update(member);
            }
        }
        public bool DeleteMemberClassroom(string idMemberClassroomId, string idClassroom)
        {
            if (idMemberClassroomId.IsNullOrEmpty() || idClassroom.IsNullOrEmpty()) return false;
            try
            {
                if (_memoryCache.TryGetValue(_keyValueCache, out List<MemberClassroom> listMemberClassroomCache))
                {
                    var memberClassroomDelete = listMemberClassroomCache.FirstOrDefault(c => c.IdUser == idMemberClassroomId && c.IdClass == idClassroom);
                    if (memberClassroomDelete != null)
                    {
                        listMemberClassroomCache.Remove(memberClassroomDelete);
                        Remove(memberClassroomDelete);
                    }
                    else
                    {
                        memberClassroomDelete = _dbSet.FirstOrDefault(c => c.IdUser == idMemberClassroomId && c.IdClass == idClassroom);
                        Remove(memberClassroomDelete);
                    }
                    
                }
                else
                {
                    var memberClassroomDelete = _dbSet.FirstOrDefault(c => c.IdUser == idMemberClassroomId && c.IdClass == idClassroom);
                    Remove(memberClassroomDelete);
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public bool DeleteRangeMemberClassroom(List<string> listIdMemberClassroom, string idClassroom)
        {
            if (listIdMemberClassroom.IsNullOrEmpty() || idClassroom.IsNullOrEmpty()) return false;
            try
            {
                var listClassroomMember = _dbSet.Where(p => p.IdClass == idClassroom).ToList();
                if (_memoryCache.TryGetValue(_keyValueCache, out List<MemberClassroom> listMemberClassroomCache))
                {
                    listMemberClassroomCache = listMemberClassroomCache.Where(p => p.IdClass == idClassroom).ToList();
                    foreach (var item in listIdMemberClassroom)
                    {
                        var member = listMemberClassroomCache.FirstOrDefault(p => p.IdUser == item);
                        if (member == null)
                        {
                            member = listClassroomMember.FirstOrDefault(p => p.IdUser == item);
                            if(member == null)  return false;
                        }
                        listMemberClassroomCache.Remove(member);
                        Remove(member);
                    }
                }
                else
                {
                    foreach (var item in listIdMemberClassroom)
                    {
                        var member = listClassroomMember.FirstOrDefault(p => p.IdUser == item);
                        if (member == null)
                        {
                            return false;
                        }
                        Remove(member);
                    }
                }
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }
    }
}

