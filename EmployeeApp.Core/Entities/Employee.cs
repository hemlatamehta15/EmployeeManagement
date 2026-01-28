using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeApp.Core.Entities
{
    public class Employee
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string FirstName { get; set; }
     
        [Required]
        [StringLength(100)]
        public string LastName { get; set; }
        
        [StringLength(100)] 
        public string City { get; set; }
        
        [StringLength(10)]
        public string Zip { get; set; }
        public DateTime CreatedDate { get; set; }

    }
}
