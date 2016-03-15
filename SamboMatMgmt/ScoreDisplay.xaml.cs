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
        private DateTime    _the_time = new DateTime(0);
        private bool        _is_counting = false;
        private long        _FightTime;
        private string      _currenttime;


        //CompetitorRed
        private String  _CompetitorRedName = "";
        private String   _CompetitorRedScore = "0";
        //CompetitorBlue
        private String  _CompetitorBlueName = "";
        private String  _CompetitorBlueScore = "0";


        public ScoreDisplayViewModel()
        {
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

        public String ScoreRed
        {
            get { return this._CompetitorRedScore.ToString(); }
            set
            {
                _CompetitorRedScore = value;
                OnPropertyChanged("ScoreRed");
            }
        }

        public String ScoreBlue
        {
            get { return this._CompetitorBlueScore.ToString(); }
            set
            {
                _CompetitorBlueScore = value;
                OnPropertyChanged("ScoreBlue");
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
            }
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
