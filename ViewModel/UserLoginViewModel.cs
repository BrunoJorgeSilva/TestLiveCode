using System.ComponentModel.DataAnnotations;

namespace TestLiveCode.ViewModel
{
    public class UserLoginViewModel
    {
        [StringLength(50)]
        public string User { get; set; }
        [StringLength(50)]
        public string Password { get; set; }
        public bool? Active { get; set; }
        public DateTime? DateAdded { get; set; }
    }
}
