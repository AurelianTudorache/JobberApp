using JobberApp.Repositories;

namespace JobberApp.Data.Models.Employee
{
    public class EmployeeSkill : IEntity
    {
        public int Id { get; set; }
        public int Experience { get; set; }
        public string PayRate { get; set; }
        public string Qualifications { get; set; }
        public int SkillId { get; set; }
        public Skill Skill { get; set; }

    }
}