using System;
using System.Collections.Generic;
using CoachAthlete.Core.Enum;
using CoachAthlete.Entities;

namespace CoachAthlete.Data.Entities
{
    public class TestHeaderModel
    {
        public int TestHeaderId { get; set; }
        public DateTime TestDate { get; set; }
        public TestType TestType { get; set; }
        public string NoOfParticipants { get; set; }
        public ICollection<TestDetailModel>  TestDetails { get; set; }
    }
}
