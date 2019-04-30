using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CoachAthlete.Entities
{
    public enum TestType
    {
        CooperTest,
        SprintTest
    }
    public class TestHeader
    {
        [Key]
        public int TestHeaderId { get; set; }
        public DateTime TestDate { get; set; }
        public TestType TestType { get; set; }
        [NotMapped]
        public string NoOfParticipants { get; set; }
        public ICollection<TestDetail>  TestDetails { get; set; }
    }
}
