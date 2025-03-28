namespace gp_backend.Api.Dtos
{
    public class AddPharmacyDto
    {
        public string? Name { get; set; }
        public string Location { get; set; }
        public string DoctorId { get; set; }
        public TimeSpan? Start { get; set; }
        public TimeSpan? Close { get; set; }
        public int? Fees { get; set; }
    }
}
