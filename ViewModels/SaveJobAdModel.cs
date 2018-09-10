using System;
using System.Collections.Generic;

namespace JobberApp.ViewModels
{
    public class SaveJobAdModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int LocationId { get; set; }
        public int SkillId { get; set; }
        public int PosNeeded { get; set; }
        public string Description { get; set; }
        public string Requirments { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int Duration { get; set; }  
        public int Payrate { get; set; }
        public float ChargeRate { get; set; }
        public float TotalCharge { get; set; }
    }
}