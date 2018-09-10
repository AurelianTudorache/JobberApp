using JobberApp.Repositories;

namespace JobberApp.Data.Models
{
    public class Skill : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }

    }
}