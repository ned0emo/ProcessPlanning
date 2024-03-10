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
        public readonly int priority;
        public readonly int startTime;

        public ProgressBar progressBar;
        public Label label;

        public MyThread(int id, int priority, int startTime, ProgressBar progressBar, Label label)
        {
            this.id = id;
            this.priority = priority;
            this.progressBar = progressBar;
            this.label = label;
            this.startTime = startTime;

            this.label.Text = this.ToString();
        }

        public bool Progress()
        {
            if (progressBar.Value < progressBar.Maximum)
            {
                progressBar.Value++;
                return true;
            }
            return false;
        }

        public override string ToString()
        {
            return $"start time: {startTime}, priority: {priority}";
        }
    }
}
