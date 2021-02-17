namespace ASP.NET_MVC_CRUD.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Employee")]
    public partial class Employee
    {
        public int EmployeeID { get; set; }
        
        [Required(ErrorMessage = "This field is Required")]
        public string Name { get; set; }
        
        [Required(ErrorMessage = "This field is Required")]
        public string Position { get; set; }

       
        public string Office { get; set; }

        public int? Age { get; set; }

        public int? Salary { get; set; }
    }
}
