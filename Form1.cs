using System.Threading;

namespace Process_Planning
{
    public partial class Form1 : Form
    {
        readonly List<Label> _labels;

        readonly List<MyThread> _threads;
        readonly Random _rnd;

        bool clearData = false;
        bool interrupt = false;

        int id = 0;
        int currentTime = 0;

        public Form1()
        {
            _labels = [];
            _threads = [];

            _rnd = new Random();

            InitializeComponent();
        }

        private void AddThreadButton_Click(object sender, EventArgs e)
        {
            interrupt = false;
            var startTime = int.TryParse(startTimeTextBox.Text, out int stRes) ? stRes : _rnd.Next(5);
            if (startTime < 0 || startTime > 19) return;

            var timeLength = int.TryParse(timeTextBox.Text, out int tRes) ? tRes : _rnd.Next(5) + 1;
            if (timeLength < 0 || timeLength + startTime > 19) return;

            if (clearData) ClearData();
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

            AddLabel(lbl);
        }

        private async void StartButton_Click(object sender, EventArgs e)
        {
            if (_threads.Count == 0) return;

            textBox1.Text = "";
            startButton.Enabled = false;
            addThreadButton.Enabled = false;

            var ct = _threads.OrderBy(t => t.StartTime).ThenBy(t => t.TimeLength).FirstOrDefault();
            if (ct == null) return;
            currentTime = ct.StartTime;

            while (_threads.Count > 0 && !interrupt)
            {
                var newt = _threads.OrderBy(t => t.TimeLength).ThenBy(t => t.InitialStartTime)
                    .FirstOrDefault(t => t.StartTime == currentTime || t.Interrupted);

                if (ct == null || newt != null && newt != ct && newt.TimeLength < ct.TimeLength)
                {
                    if (newt != null)
                    {
                        if (ct != null)
                        {
                            ct.Interrupted = true;
                        }
                        ct = newt;
                    }
                }

                ct ??= _threads.OrderBy(t => t.StartTime).ThenBy(t => t.TimeLength).FirstOrDefault();

                if (ct == null)
                    break;

                ct.Interrupted = false;

                await Task.Delay(500);

                var num = new Label()
                {
                    Location = new Point(153 + currentTime * 31, 5),
                    AutoSize = true,
                    Text = currentTime.ToString()
                };

                AddLabel(num);

                textBox1.Text += $"{currentTime}\r\n";

                if (ct.StartTime > currentTime)
                {
                    foreach (var thread in _threads)
                    {
                        textBox1.Text += $"id {thread.Id}; start {thread.StartTime}; " +
                        $"init {thread.InitialStartTime}; len {thread.TimeLength}; " +
                        $"prog {thread.Progress}; inter {thread.Interrupted}\r\n";

                        var lb = new Label()
                        {
                            Text = "",
                            Location = new Point(153 + currentTime * 31, 35 + thread.Id * 30),
                            AutoSize = true,
                        };

                        AddLabel(lb);
                    }
                }
                else
                {
                    foreach (var thread in _threads)
                    {
                        textBox1.Text += $"id {thread.Id}; start {thread.StartTime}; " +
                        $"init {thread.InitialStartTime}; len {thread.TimeLength}; " +
                        $"prog {thread.Progress}; paused {thread.Interrupted}\r\n";

                        if (thread.StartTime > currentTime)
                        {
                            continue;
                        }

                        if (thread.StartTime <= currentTime)
                        {
                            thread.StartTime++;
                        }

                        var lbl = new Label()
                        {
                            Location = new Point(153 + currentTime * 31, 35 + thread.Id * 30),
                            AutoSize = true,
                        };
                        AddLabel(lbl);

                        if (thread == ct)
                        {
                            lbl.Text = "È";
                            ct.Progress++;

                            continue;
                        }

                        lbl.Text = "Ã";
                    }
                }
                currentTime++;

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

        void AddLabel(Label lbl)
        {
            if (interrupt) return;

            panel1.Controls.Add(lbl);
            _labels.Add(lbl);
        }

        void ClearData()
        {
            foreach (var lbl1 in _labels)
            {
                lbl1.Dispose();
            }

            _labels.Clear();
            _threads.Clear();
            id = 0;
        }

        private void resetButton_Click(object sender, EventArgs e)
        {
            interrupt = true;
            ClearData();
        }
    }
}
