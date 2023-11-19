using Domain.Entities;
using Domain.Interfaces;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;

namespace Infrastructure.Repositories
{
    public class MemberRepository : GenericRepository<Member>, IMemberRepository
    {
        public MemberRepository(ClassroomDbContext context, IMemoryCache memoryCache) : base(context, memoryCache)
        {
            _dbSet.Include(c => c.ListMemberClassroom).Load();
            _dbSet.Include(c => c.ListClassroom).Load();
            _keyValueCache = "MemberPublicMemoryCachingKey";
        }

        public void AddMember(Member member) => Add(member);

        public void UpdateMember(Member member) => Update(member);
    }
}
