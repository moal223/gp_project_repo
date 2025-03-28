
namespace gp_backend.Core.Models
{
    public class Pharmacy
    {
        public int Id { get; set; }
        public string? Name { get;  set; }
        public string Location { get; set; }
        public TimeSpan? Start { get; set; }
        public TimeSpan? Close { get; set; }
        public int? Fees { get; set; }
        public ApplicationUser Doctor { get; set; }
    }
}
