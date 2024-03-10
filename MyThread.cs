using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Process_Planning
{
    public class MyThread
    {
        public readonly int id;
        public readonly int maxValue;
        public readonly int priority;
        public readonly int time;

        public ProgressBar progressBar;
        public Label label;

        public MyThread(int id, int maxValue, int priority, int time, ProgressBar progressBar, Label label)
        {
            this.id = id;
            this.maxValue = maxValue;
            this.priority = priority;
            this.time = time;
            this.progressBar = progressBar;
            this.label = label;
        }

        public void Increment() => progressBar.Value++;

        public override string ToString()
        {
            return $"id: {id}, priority: {priority}, time: {time}";
        }
    }
}
