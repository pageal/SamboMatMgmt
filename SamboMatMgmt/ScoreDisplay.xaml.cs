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
        private long   _FightLen;
        private string _Weight = "";
        private string _current_fight_time = "";
        private string _special_clock_red = "";
        private string _special_action_red = "";
        private string _special_clock_blue = "";
        private string _special_action_blue = "";
        private string _activity_red = "";
        private string _activity_blue = "";
        private string _sanction_z_red = " ";
        private string _sanction_i_red = " ";
        private string _sanction_ii_red = "  ";
        private string _sanction_dis_red = "   ";
        private string _sanction_z_blue = " ";
        private string _sanction_i_blue = " ";
        private string _sanction_ii_blue = "  ";
        private string _sanction_dis_blue = "   ";

        //CompetitorRed
        private String  _CompetitorRedName = "";
        private String   _CompetitorRedScore = "0";
        //CompetitorBlue
        private String  _CompetitorBlueName = "";
        private String  _CompetitorBlueScore = "0";


        public ScoreDisplayViewModel()
        {
            FightClock = _the_time.ToString("mm:ss");
            SpecialClockBlue = _the_time.ToString("mm:ss");
            SpecialClockRed = _the_time.ToString("mm:ss");
        }

        public string FightClock
        {
            get { return _current_fight_time; }
            set
            {
                _current_fight_time = value;
                OnPropertyChanged("FightClock");
            }
        }

        public string Weight
        {
            get { return _Weight; }
            set
            {
                _Weight = value + " kg";
                OnPropertyChanged("Weight");
            }
        }

        public string SpecialClockBlue
        {
            get { return _special_clock_blue; }
            set
            {
                _special_clock_blue = value;
                OnPropertyChanged("SpecialClockBlue");
            }
        }

        public string SpecialActionBlue
        {
            get { return _special_action_blue; }
            set
            {
                _special_action_blue = value;
                OnPropertyChanged("SpecialActionBlue");
            }
        }

        public string SpecialClockRed
        {
            get { return _special_clock_red; }
            set
            {
                _special_clock_red = value;
                OnPropertyChanged("SpecialClockRed");
            }
        }

        public string ActivityRed
        {
            get { return _activity_red; }
            set
            {
                _activity_red = value;
                OnPropertyChanged("ActivityRed");
            }
        }

        public string ActivityBlue
        {
            get { return _activity_blue.ToString(); }
            set
            {
                _activity_blue = value;
                OnPropertyChanged("ActivityBlue");
            }
        }

        public string SpecialActionRed
        {
            get { return _special_action_red; }
            set
            {
                _special_action_red = value;
                OnPropertyChanged("SpecialActionRed");
            }
        }

        public string SanctionZRed
        {
            get { return _sanction_z_red; }
            set
            {
                _sanction_z_red = value;
                OnPropertyChanged("SanctionZRed");
            }
        }

        public string SanctionZBlue
        {
            get { return _sanction_z_blue; }
            set
            {
                _sanction_z_blue = value;
                OnPropertyChanged("SanctionZBlue");
            }
        }

        public string SanctionIRed
        {
            get { return _sanction_i_red; }
            set
            {
                _sanction_i_red = value;
                OnPropertyChanged("SanctionIRed");
            }
        }
        public string SanctionIBlue
        {
            get { return _sanction_i_blue; }
            set
            {
                _sanction_i_blue = value;
                OnPropertyChanged("SanctionIBlue");
            }
        }

        public string SanctionIIRed
        {
            get { return _sanction_ii_red; }
            set
            {
                _sanction_ii_red = value;
                OnPropertyChanged("SanctionIIRed");
            }
        }

        public string SanctionIIBlue
        {
            get { return _sanction_ii_blue; }
            set
            {
                _sanction_ii_blue = value;
                OnPropertyChanged("SanctionIIBlue");
            }
        }

        public string SanctionDisRed
        {
            get { return _sanction_dis_red; }
            set
            {
                _sanction_dis_red = value;
                OnPropertyChanged("SanctionDisRed");
            }
        }

        public string SanctionDisBlue
        {
            get { return _sanction_dis_blue; }
            set
            {
                _sanction_dis_blue = value;
                OnPropertyChanged("SanctionDisBlue");
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

        public long FightLen
        {
            get { return this._FightLen; }
            set
            {
                _FightLen = value;
                OnPropertyChanged("FightLen");
            }
        }

        public string CurrentFightLen
        {
            get { return _current_fight_time; }
            set
            {
                _current_fight_time = value;
                OnPropertyChanged("FightClock");
            }
        }

        public void ResetSanctions()
        {
            SanctionZRed = " ";
            SanctionIRed = " ";
            SanctionIIRed = "  ";
            SanctionDisRed = "   ";
            SanctionZBlue = " ";
            SanctionIBlue = " ";
            SanctionIIBlue = "  ";
            SanctionDisBlue = "   ";
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
