namespace Process_Planning
{
    public partial class Form1 : Form
    {
        readonly Random _rnd;
        readonly List<ProgressBar> _bars;
        readonly List<Label> _labels;

        int id = 0;

        public Form1()
        {
            _rnd = new Random();
            _bars = [];
            _labels = [];

            InitializeComponent();
        }

        private void AddThreadButton_Click(object sender, EventArgs e)
        {
            var pb = new ProgressBar()
            {
                Width = 740,
                Location = new Point(33, 3 + _bars.Count * 30),
                Maximum = _rnd.Next(10, 101),
            };

            var lbl = new Label()
            {
                Text = id++.ToString(),
                Location = new Point(3, 3 + _bars.Count * 30),
            };

            var thread = new MyThread(id++, _rnd.Next(10, 101), _rnd.Next(1, 5), -1, pb, lbl);

            panel1.Controls.Add(pb);
            panel1.Controls.Add(lbl);

            _labels.Add(lbl);
            _bars.Add(pb);

            ProgressThread(pb, lbl);
        }

        async void ProgressThread(ProgressBar pb, Label lbl)
        {
            do
            {
                pb.Value++;

                await Task.Delay(100);

                pb.Location = new Point(33, 3 + _bars.IndexOf(pb) * 30);
                lbl.Location = new Point(3, 3 + _labels.IndexOf(lbl) * 30);
            } while (pb.Value < pb.Maximum);

            panel1.Controls.Remove(pb);
            panel1.Controls.Remove(lbl);

            _bars.Remove(pb);
            _labels.Remove(lbl);

            pb.Dispose();
        }
    }
}
