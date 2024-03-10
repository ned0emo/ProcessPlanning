namespace Process_Planning
{
    public partial class Form1 : Form
    {
        readonly List<ProgressBar> _bars;
        readonly List<Label> _labels;

        readonly List<MyThread> _threads;

        bool clearData = false;

        int id = 0;

        public Form1()
        {
            _bars = [];
            _labels = [];
            _threads = [];

            InitializeComponent();
        }

        private void AddThreadButton_Click(object sender, EventArgs e)
        {
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
                id = 0;
            }
            clearData = false;

            var pb = new ProgressBar()
            {
                Width = 620,
                Location = new Point(153, 3 + _bars.Count * 30),
                Maximum = int.TryParse(timeTextBox.Text, out int tRes) ? tRes : 10,
            };

            var lbl = new Label()
            {
                //Text = id.ToString(),
                Location = new Point(3, 5 + _bars.Count * 30),
                AutoSize = true,
            };

            var thread = new MyThread(id++,
                int.TryParse(priorityTextBox.Text, out int pRes) ? pRes : 0,
                int.TryParse(startTimeTextBox.Text, out int stRes) ? stRes : 0,
                pb, lbl);
            _threads.Add(thread);

            panel1.Controls.Add(pb);
            panel1.Controls.Add(lbl);

            _labels.Add(lbl);
            _bars.Add(pb);
        }

        async void DoWork()
        {
            if (_threads.Count == 0) return;

            startButton.Enabled = false;
            addThreadButton.Enabled = false;

            while (_threads.Count > 0)
            {
                var ct = _threads.OrderBy(t => t.priority).ThenBy(t => t.startTime).First();
                await ProgressThread(ct);
            }

            clearData = true;
            startButton.Enabled = true;
            addThreadButton.Enabled = true;
        }

        async Task ProgressThread(MyThread thread)
        {
            while (thread.Progress())
            {
                await Task.Delay(1000);
            }

            _threads.Remove(thread);
        }

        private void startButton_Click(object sender, EventArgs e)
        {
            DoWork();
        }
    }
}
