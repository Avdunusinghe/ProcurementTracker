namespace ProcurementTracker.Application.Common.Response.UserDTOs
{
    public class UserDTO
    {
        public long Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string ContactNumber { get; set; }
        public string Address { get; set; }
        public long RoleId { get; set; }
        public string Password { get; set; }
    }
}
