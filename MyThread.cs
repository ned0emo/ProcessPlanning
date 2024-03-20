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
        public int InitialStartTime { get; }
        public int TimeLength { get; }
        public int Progress { get; set; } = 0;
        public bool Interrupted { get; set; } = false;

        public MyThread(int id, int startTime, int timeLength)
        {
            Id = id;
            TimeLength = timeLength;
            StartTime = startTime;
            InitialStartTime = startTime;
        }
    }
}
