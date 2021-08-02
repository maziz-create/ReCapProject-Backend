using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DTOs
{
    public class UserDetailForUpdateDto
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string CompanyName { get; set; }
        public string NationalIdentity { get; set; }
        public string CurrentPassword { get; set; }
        public string NewPassword { get; set; }
    }
}
