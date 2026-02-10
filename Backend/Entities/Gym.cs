namespace GYMIND.API.Entities
{
    public class Gym
    {
        public Guid GymId { get; set; }
        public string Name { get; set; } = null!;
        public string Address { get; set; } = null!;
        public bool IsApproved { get; set; }
        public DateTime CreatedAt { get; set; }

        // Navigation property for related users (gym owners)
        public ICollection<Membership> Memberships {get; set; } = new List<Membership>();
        public ICollection<GymBranch> GymBranches { get; set; } = new List<GymBranch>();
    }
}
