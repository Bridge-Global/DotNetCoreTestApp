using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using CoachAthlete.Core.Enum;
using CoachAthlete.Data.Entities;
using Microsoft.AspNetCore.Identity;


namespace CoachAthlete.Entities
{
    public class TestDetailModel
    {

        public  long SlNo {get; set;}
        public string AthleteId { get; set; }
        public IdentityUser Athlete { get; set; }
        public float DistanceOrTime { get; set; }
        public FitnessRating FitnessRating { get; set; }
        public int TestHeaderId { get; set; }
        public TestHeaderModel TestHeader { get; set; }
    }
}
