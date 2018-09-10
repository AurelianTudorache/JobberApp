using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using JobberApp.Data.Models.Employee;
using JobberApp.Data.Models.Employee.Enums;
using JobberApp.Repositories;

namespace JobberApp.Data.Models.Employee
{
    public class Employee : IEntity
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public TitleEnum Title { get; set; }
        public GenderEnum Gender { get; set; }
        public string Address { get; set; }
        public string PostalCode { get; set; }
        public string Phone { get; set; }
        public string ProfileThumbnail { get; set; }
        public int TravelDistance { get; set; }
        public DateTime DateOfBirth { get; set; }
        // public Schedule Unavailability { get; set; }
        // public int TotalAssignments { get; set; }
        // public int TotalPositiveReviews { get; set; }
        // public Boolean HasApprovedReference { get; set; }
        public string UserId { get; set; }

        [ForeignKey("UserId")]
        public virtual ApplicationUser User { get; set; }
        public virtual ICollection<EmployeeSkill> EmployeeSkills { get; set; }
        public int BankAccountId { get; set; }
        public virtual BankAccount BankAccount { get; set; }
    }
}