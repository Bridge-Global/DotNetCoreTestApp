using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using CoachAthlete.Core.Enum;

namespace CoachAthlete.Data.Entities
{
    // attribute to specify table name
    [name]
    public class TestHeaderEntity
    {
        [Key]
        public int TestHeaderId { get; set; }
        public DateTime TestDate { get; set; }
        public TestType TestType { get; set; }
        [NotMapped]
        public string NoOfParticipants { get; set; }
        public ICollection<TestDetailEntity>  TestDetails { get; set; }
    }
}
