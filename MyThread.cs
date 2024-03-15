using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Process_Planning
{
    public class MyThread
    {
        public int Id { get; }
        public int StartTime { get; set; }
        public int TimeLength { get; }
        public int Progress { get; set; } = 0;

        public MyThread(int id, int startTime, int timeLength)
        {
            Id = id;

            //this.priority = priority;
            TimeLength = timeLength;
            StartTime = startTime;
        }
    }
}
