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

        public Label label;

        public MyThread(int id, int startTime, int timeLength, Label label)
        {
            this.Id = id;
            this.label = label;

            //this.priority = priority;
            TimeLength = timeLength;
            StartTime = startTime;

            this.label.Text = $"start time: {StartTime}, length: {TimeLength}";
        }
    }
}
