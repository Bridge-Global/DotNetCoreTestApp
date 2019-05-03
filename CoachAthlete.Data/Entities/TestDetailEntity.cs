using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using CoachAthlete.Core.Enum;
using Microsoft.AspNetCore.Identity;

namespace CoachAthlete.Data.Entities
{
    [Table("TestDetail")]
    public class TestDetailEntity
    {
        public TestDetailEntity()
        {
            
        }
        [Key]
        public  long SlNo {get; set;}
        [ForeignKey("Id")]
        public string AthleteId { get; set; }
        public IdentityUser Athlete { get; set; }
        public float DistanceOrTime { get; set; }

        [NotMapped]
        public FitnessRating FitnessRating { get; set; }
        public int TestHeaderId { get; set; }
        public TestHeaderEntity TestHeader { get; set; }
    }
}
