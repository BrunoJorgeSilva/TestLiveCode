using System.ComponentModel.DataAnnotations;

namespace TestLiveCode.Model
{
    public class UserLogin
    {
        public Guid Id { get; set; }
        [StringLength(50)]
        public string User { get; set; }
        [StringLength(50)]
        public string Password { get; set; }
        public bool Active { get; set; }
        public DateTime DateAdded { get; set; }
    }
}
