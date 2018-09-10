using System;
using System.Collections.Generic;
using JobberApp.Repositories;

namespace JobberApp.Data.Models
{
    public class JobAd : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int LocationId { get; set; }
        public int SkillId { get; set; }
        public int EmployerId { get; set; }
        public int PosNeeded { get; set; }
        public string Description { get; set; }
        public string Requirments { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int Duration { get; set; }
        public int Payrate { get; set; }
        public float ChargeRate { get; set; }
        public float TotalCharge { get; set; }
        public DateTime CreatedAt { get; set; }
        public bool IsCompleted { get; set; }
        public bool IsAssigned { get; set; }
        
    }
}