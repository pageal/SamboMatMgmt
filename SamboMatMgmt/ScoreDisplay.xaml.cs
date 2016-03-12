using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace SamboMatMgmt
{
    /// <summary>
    /// Interaction logic for ScoreDisplay.xaml
    /// </summary>
    public partial class ScoreDisplay : Window
    {
        public ScoreDisplay()
        {
            InitializeComponent();
            this.DataContext = new ScoreDisplayViewModel();
        }

    }

    public class ScoreDisplayViewModel : INotifyPropertyChanged
    {
        //CompetitorRed
        private String _CompetitorRedName = "";

        //CompetitorBlue
        private String _CompetitorBlueName = "";

        private bool _is_counting = false;
        private string _currenttime;
        private DateTime _the_time;

        private long _FightTime = 180;

        public ScoreDisplayViewModel()
        {
            DispatcherTimer timer = new DispatcherTimer(DispatcherPriority.Background);
            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Tick += UpdateTime;
            timer.Start();
            CurrentTime = _the_time.ToString("mm:ss");
        }

        public bool isCounting
        {
            get { return _is_counting; }
            set
            {
                _is_counting = value;
                OnPropertyChanged("isCounting");
            }
        }

        public String CompetitorRedName
        {
            get { return this._CompetitorRedName; }
            set
            {
                _CompetitorRedName = value;
                OnPropertyChanged("CompetitorRedName");
            }
        }

        public String CompetitorBlueName
        {
            get { return this._CompetitorBlueName; }
            set
            {
                _CompetitorBlueName = value;
                OnPropertyChanged("CompetitorBlueName");
            }
        }

        public long FightTime
        {
            get { return this._FightTime; }
            set
            {
                _FightTime = value;
                OnPropertyChanged("FightTime");
            }
        }

        public string CurrentTime
        {
            get { return _currenttime; }
            set
            {
                _currenttime = value;
                OnPropertyChanged("CurrentTime");
                // lblTime.Content = the_time.ToString("mm:ss");
            }
        }

        private void UpdateTime(object sender, EventArgs e)
        {
            if (_is_counting == false)
                return;

            if (_FightTime > 0)
                _FightTime -= 1;

            _the_time = new DateTime(_FightTime * 10000000);
            CurrentTime = _the_time.ToString("mm:ss");
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
