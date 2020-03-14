using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WorkoutLog.API.Models.Application
{
    public class Volume
    {
        public int Id { get; set; }
        public short Weight { get; set; }
        public byte Sets { get; set; }
        public byte Reps { get; set; }
        public string Distance { get; set; }
        public TimeSpan Time { get; set; }
    }
}
