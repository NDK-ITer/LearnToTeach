using Domain.Entities;

namespace Domain.Interfaces
{
    public interface IMemberRepository : IGenericRepository<Member>
    {
        void AddMember(Member member);
        void UpdateMember(Member member);
    }
}
