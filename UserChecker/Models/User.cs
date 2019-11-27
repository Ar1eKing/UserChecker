using System.Collections.Generic;

namespace UserChecker.Models
{
    public class User
    {
        public string UserId { get; set; }
        public string Email { get; set; }
        public List<Signature> SignatureItems { get; set; }
    }
}