using System.Threading;

namespace Process_Planning
{
    public partial class Form1 : Form
    {
        readonly List<ProgressBar> _bars;
        readonly List<Label> _labels;

        readonly List<MyThread> _threads;
        readonly Random _rnd;

        bool clearData = false;

        int id = 0;
        int currentTime = 0;

        public Form1()
        {
            _bars = [];
            _labels = [];
            _threads = [];

            _rnd = new Random();

            InitializeComponent();
        }

        private void AddThreadButton_Click(object sender, EventArgs e)
        {
            var startTime = int.TryParse(startTimeTextBox.Text, out int stRes) ? stRes : _rnd.Next(7);
            if (startTime < 0 || startTime > 19) return;

            var timeLength = int.TryParse(timeTextBox.Text, out int tRes) ? tRes : _rnd.Next(7) + 1;
            if (timeLength < 0 || timeLength + startTime > 19) return;

            if (clearData)
            {
                foreach (var pb1 in _bars)
                {
                    pb1.Dispose();
                }

                foreach (var lbl1 in _labels)
                {
                    lbl1.Dispose();
                }

                _bars.Clear();
                _labels.Clear();
                _threads.Clear();
                id = 0;
            }
            clearData = false;

            var lbl = new Label()
            {
                Location = new Point(3, 35 + id * 30),
                AutoSize = true,
                Text = $"start time: {startTime}, length: {timeLength}"
            };

            var thread = new MyThread(id++,
                startTime,
                timeLength);
            _threads.Add(thread);

            panel1.Controls.Add(lbl);

            _labels.Add(lbl);
        }

        //async Task ProgressThread(MyThread thread)
        //{
        //    while (thread.Progress())
        //    {
        //        await Task.Delay(1000);
        //    }
        //
        //    _threads.Remove(thread);
        //}

        private async void StartButton_Click(object sender, EventArgs e)
        {
            if (_threads.Count == 0) return;

            textBox1.Text = "";
            startButton.Enabled = false;
            addThreadButton.Enabled = false;

            var ct = _threads.OrderBy(t => t.StartTime).ThenBy(t => t.TimeLength).FirstOrDefault();
            if (ct == null) return;
            currentTime = ct.StartTime;

            while (_threads.Count > 0)
            {
                var newt = _threads.OrderBy(t => t.TimeLength).ThenBy(t => t.InitialStartTime)
                    .ThenByDescending(t => t.Progress)
                    .FirstOrDefault(t => t.StartTime == currentTime);
                
                //textBox1.Text += "newt: " + (newt == null ? "null\r\n" : $"id {newt.Id}; " +
                //    $"start {newt.StartTime}; init {newt.InitialStartTime}; len {newt.TimeLength}\r\n");
                
                if (ct == null || newt != null && newt != ct && newt.TimeLength < ct.TimeLength)
                {
                    if (newt != null)
                    {
                        ct = newt;
                            //_threads.FirstOrDefault(t => t.TimeLength == newt.TimeLength && t.InitialStartTime < newt.InitialStartTime) ?? newt;
                    }
                }

                ct ??= _threads.OrderBy(t => t.StartTime).ThenBy(t => t.TimeLength).FirstOrDefault();
                //textBox1.Text += "ct: " + (ct == null ? "null\r\n" : $"id {ct.Id}; " +
                //    $"start {ct.StartTime}; init {ct.InitialStartTime}; len {ct.TimeLength}\r\n");

                if (ct == null)
                    break;

                await Task.Delay(1000);

                var num = new Label()
                {
                    Location = new Point(153 + currentTime * 31, 5),
                    AutoSize = true,
                    Text = currentTime.ToString()
                };

                _labels.Add(num);
                panel1.Controls.Add(num);

                textBox1.Text += $"{currentTime}\r\n";
                foreach (var thread in _threads)
                {
                    textBox1.Text += $"id {thread.Id}; start {thread.StartTime}; " +
                        $"init {thread.InitialStartTime}; len {thread.TimeLength}; " +
                        $"prog {thread.Progress}\r\n";

                    if(ct.StartTime > currentTime)
                    {
                        var lb = new Label()
                        {
                            Text = "",
                            Location = new Point(153 + currentTime * 31, 35 + thread.Id * 30),
                            AutoSize = true,
                        };

                        panel1.Controls.Add(lb);
                        _labels.Add(lb);
                        continue;
                    }

                    if (thread.StartTime > currentTime)
                    {
                        continue;
                    }

                    //thread.StartTime++;
                    if (thread.StartTime <= currentTime)
                    {
                        thread.StartTime++;
                    }

                    var lbl = new Label()
                    {
                        //Text = "È",
                        Location = new Point(153 + currentTime * 31, 35 + thread.Id * 30),
                        AutoSize = true,
                    };

                    _labels.Add(lbl);

                    if (thread == ct)
                    {
                        lbl.Text = "È";
                        ct.Progress++;
                        panel1.Controls.Add(lbl);
                        continue;
                    }

                    lbl.Text = "Ã";
                    panel1.Controls.Add(lbl);
                }
                currentTime++;

                //if(ct.StartTime > currentTime)
                //{
                //    ct.StartTime++;
                //}

                if (ct.Progress == ct.TimeLength)
                {
                    _threads.Remove(ct);
                    ct = null;
                }
            }

            clearData = true;
            startButton.Enabled = true;
            addThreadButton.Enabled = true;
        }
    }
}
