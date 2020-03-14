using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WorkoutLog.API.Models.Application
{
    public class LogType
    {
        public int Id { get; set; }
        public bool LogsWeight { get; set; }
        public bool LogsSets { get; set; }
        public bool LogsReps { get; set; }
        public bool LogsTime { get; set; }
        public bool LogsDistance { get; set; }
    }
}
