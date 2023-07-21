namespace Domain.Entites
{
    public class Role
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string NomalizeName { get; set; }
        public IEnumerable<User> Users { get; set; }
    }
}
