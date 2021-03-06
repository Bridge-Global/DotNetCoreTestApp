﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace CoachAthlete.Entities
{
    public class TestDetail
    {
        [Key]
        public  long SlNo {get; set;}
        public IdentityUser Athlete { get; set; }
        public float DistanceOrTime { get; set; }

        public int TestHeaderId { get; set; }
        public TestHeader TestHeader { get; set; }
    }
}
