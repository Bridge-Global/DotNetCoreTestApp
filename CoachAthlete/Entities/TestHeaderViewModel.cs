using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using CoachAthlete.Core.Enum;

namespace CoachAthlete.Entities
{
    public class TestHeaderViewModel
    {
        [Key]
        public int TestHeaderId { get; set; }
        public DateTime TestDate { get; set; }
        public TestType TestType { get; set; }
        [NotMapped]
        public string NoOfParticipants { get; set; }
        public ICollection<TestDetailViewModel>  TestDetails { get; set; }
    }
}