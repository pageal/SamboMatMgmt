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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace SamboMatMgmt
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private ScoreDisplay _DisplayWin = new ScoreDisplay();
        private SamboMatMgmtViewModel _ViewModel;

        public MainWindow()
        {
            InitializeComponent();

            this._ViewModel = new SamboMatMgmtViewModel((ScoreDisplayViewModel)_DisplayWin.DataContext);
            this.DataContext = this._ViewModel;
            this._DisplayWin.Show();
            ResetSanctions();
        }

        private void ComboCompetitorRed_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //this._ViewModel.CompetitorRedName = e;

        }

        private void ResetFightLen()
        {
            if (!String.IsNullOrEmpty(BattleTime.Text))
            {
                try
                {
                    this._ViewModel.FightLen = (int)(Convert.ToDouble(BattleTime.Text));
                }
                catch (Exception)
                {
                    MessageBox.Show("Please enter valid fight length");
                }
                //comboBox.SelectedItem = newItem;
            }
        }
        private void FightLen_LostFocus(object sender, RoutedEventArgs e)
        {
            ResetFightLen();
        }

        // Score events for Red Fighter
        private void OnRedScoreReset(object sender, RoutedEventArgs e)
        {
            try
            {
                _ViewModel.OnRedScoreReset(Convert.ToInt32(textBoxRedReset.Text));
            }
            catch (Exception)
            {
                MessageBox.Show("Please enter valid score reset value");
            }
        }

        private void OnRedPlus1(object sender, RoutedEventArgs e)
        {
            try
            {
                _ViewModel.OnRedScorePlus(Convert.ToInt32(textBoxRedPlus1.Text));
            }
            catch (Exception)
            {
                MessageBox.Show("Please enter valid number");
            }
        }

        private void OnRedScorePlus2(object sender, RoutedEventArgs e)
        {
            try
            {
                _ViewModel.OnRedScorePlus(Convert.ToInt32(textBoxRedPlus2.Text));
            }
            catch (Exception)
            {
                MessageBox.Show("Please enter valid number");
            }
        }

        private void OnRedScorePlus4(object sender, RoutedEventArgs e)
        {
            try
            {
                _ViewModel.OnRedScorePlus(Convert.ToInt32(textBoxRedPlus4.Text));
            }
            catch (Exception)
            {
                MessageBox.Show("Please enter valid number");
            }
        }

        private void OnRedScoreMinus1(object sender, RoutedEventArgs e)
        {
            try
            {
                _ViewModel.OnRedScoreMinus(Convert.ToInt32(textBoxRedMinus1.Text));
            }
            catch (Exception)
            {
                MessageBox.Show("Please enter valid number");
            }
        }

        // Score events for Blue Fighter
        private void OnBluePlus1(object sender, RoutedEventArgs e)
        {
            try
            {
                _ViewModel.OnBlueScorePlus(Convert.ToInt32(textBoxBluePlus1.Text));

            }
            catch (Exception)
            {
                MessageBox.Show("Please enter valid number");
            }
        }
        private void OnBlueScorePlus2(object sender, RoutedEventArgs e)
        {
            try
            {
                _ViewModel.OnBlueScorePlus(Convert.ToInt32(textBoxBluePlus2.Text));
            }
            catch (Exception)
            {
                MessageBox.Show("Please enter valid number");
            }
        }
        private void OnBlueScorePlus4(object sender, RoutedEventArgs e)
        {
            try
            {
                _ViewModel.OnBlueScorePlus(Convert.ToInt32(textBoxBluePlus4.Text));
            }
            catch (Exception)
            {
                MessageBox.Show("Please enter valid number");
            }
        }
        private void OnBlueScoreMinus1(object sender, RoutedEventArgs e)
        {
            try
            {
                _ViewModel.OnBlueScoreMinus(Convert.ToInt32(textBoxBlueMinus1.Text));
            }
            catch (Exception)
            {
                MessageBox.Show("Please enter valid number");
            }
        }
        private void OnBlueScoreReset(object sender, RoutedEventArgs e)
        {
            try
            {
                _ViewModel.OnBlueScoreReset(Convert.ToInt32(textBoxBlueReset.Text));
            }
            catch (Exception)
            {
                MessageBox.Show("Please enter valid number");
            }
        }

        private void OnActionHoldRed(object sender, RoutedEventArgs e)
        {
            _ViewModel.StopSpecialCountingRed();

            try
            {
                _ViewModel.HandleTimeMax = Convert.ToInt32(textBoxHold.Text);
            }
            catch (Exception)
            {
                MessageBox.Show("Please enter valid number");
            }

            _ViewModel.isCountingHandleRed = true;
            _ViewModel.SpecialTimeoutTypeRed = "HANDLE";
            //_ViewModel.isCounting = false;
            //SetSpecialClockBackground("#FFD31A1A");
        }

        private void OnActionHoldBlue(object sender, RoutedEventArgs e)
        {
            _ViewModel.StopSpecialCountingBlue();
            try
            {
                _ViewModel.HandleTimeMax = Convert.ToInt32(textBoxHoldBlue.Text);
            }
            catch (Exception)
            {
                MessageBox.Show("Please enter valid number");
            }
            _ViewModel.isCountingHandleBlue = true;
            _ViewModel.SpecialTimeoutTypeBlue = "HANDLE";
            //_ViewModel.isCounting = false;
            //SetSpecialClockBackground("#FF1414DC");
        }

        private void OnActionPainRed(object sender, RoutedEventArgs e)
        {
            _ViewModel.StopSpecialCountingRed();
            try
            {
                _ViewModel.PainTimeMax = Convert.ToInt32(textBoxPain.Text);
            }
            catch (Exception)
            {
                MessageBox.Show("Please enter valid number");
            }
            _ViewModel.isCountingPainRed = true;
            _ViewModel.SpecialTimeoutTypeRed = "PAIN";
            //_ViewModel.isCounting = false;
            //SetSpecialClockBackground("#FFD31A1A");
        }

        private void OnActionPainBlue(object sender, RoutedEventArgs e)
        {
            _ViewModel.StopSpecialCountingBlue();
            try
            {
                _ViewModel.PainTimeMax = Convert.ToInt32(textBoxPainBlue.Text);
            }
            catch (Exception)
            {
                MessageBox.Show("Please enter valid number");
            }
            _ViewModel.isCountingPainBlue = true;
            _ViewModel.SpecialTimeoutTypeBlue = "PAIN";
            //_ViewModel.isCounting = false;
            //SetSpecialClockBackground("#FF1414DC");
        }

        private void OnActionMedicalRed(object sender, RoutedEventArgs e)
        {
            try
            {
                _ViewModel.OnActionMedicalRed(Convert.ToInt32(textBoxMedical.Text));
            }
            catch (Exception)
            {
                MessageBox.Show("Please enter valid number");
            }
            //SetSpecialClockBackground("#FFD31A1A");
        }

        private void OnActionMedicalBlue(object sender, RoutedEventArgs e)
        {
            _ViewModel.StopSpecialCountingBlue();
            try
            {
                _ViewModel.OnActionMedicalBlue(Convert.ToInt32(textBoxMedicalBlue.Text));
            }
            catch (Exception)
            {
                MessageBox.Show("Please enter valid number");
            }
            //SetSpecialClockBackground("#FF1414DC");
        }

        private void OnSpecialActionStopRed(object sender, RoutedEventArgs e)
        {
            _ViewModel.StopSpecialCountingRed();
        }

        private void OnSpecialActionResetRed(object sender, RoutedEventArgs e)
        {
            _ViewModel.StopSpecialCountingRed();
            _ViewModel.ResetClocksRed();
        }

        private void OnSpecialActionResetBlue(object sender, RoutedEventArgs e)
        {
            _ViewModel.StopSpecialCountingBlue();
            _ViewModel.ResetClocksBlue();
        }


        private void OnSpecialActionStopBlue(object sender, RoutedEventArgs e)
        {
            _ViewModel.StopSpecialCountingBlue();
        }

        private void SetSpecialClockBackground(String color)
        {
            Color clr = (Color)ColorConverter.ConvertFromString(color);
            //lblSpecialClock.Background = new SolidColorBrush(clr);
            //lblSpecialAction.Background = new SolidColorBrush(clr);
       }

        private void OnBtnResetClick(object sender, RoutedEventArgs e)
        {
            _ViewModel.StopSpecialCountingRed();
            _ViewModel.StopSpecialCountingBlue();
            _ViewModel.isCounting = false;
            _ViewModel.OnRedScoreReset(0);
            _ViewModel.OnBlueScoreReset(0);
            _ViewModel.ResetFight();
            ResetFightLen();
            ComboCompetitorBlue.Text = "";
            ComboCompetitorRed.Text = "";
            ResetSanctions();
        }

        private void OnWeightEditKeyIp(object sender, KeyEventArgs e)
        {
            var comboBox = (ComboBox)sender;
            if (!String.IsNullOrEmpty(comboBox.Text))
            {
                try
                {
                    this._ViewModel.Weight = (int)(Convert.ToDouble(comboBox.Text));
                }
                catch (Exception)
                {
                    MessageBox.Show("Please enter valid weight");
                }
                //comboBox.SelectedItem = newItem;
            }
        }

        private void OnActivityPlusRed(object sender, RoutedEventArgs e)
        {
            this._ViewModel.ActivityRed += 1;
        }

        private void OnActivityMinusRed(object sender, RoutedEventArgs e)
        {
            if(this._ViewModel.ActivityRed > 0)
                this._ViewModel.ActivityRed -= 1;
        }

        private void OnActivityResetRed(object sender, RoutedEventArgs e)
        {
            this._ViewModel.ActivityRed = 0;
        }

        private void OnActivityPlusBlue(object sender, RoutedEventArgs e)
        {
            this._ViewModel.ActivityBlue += 1;
        }

        private void OnActivityMinusBlue(object sender, RoutedEventArgs e)
        {
            if(this._ViewModel.ActivityBlue > 0)
                this._ViewModel.ActivityBlue -= 1;
        }

        private void OnActivityResetBlue(object sender, RoutedEventArgs e)
        {
            this._ViewModel.ActivityBlue = 0;
        }

        private void ComboCompetitorRed_KeyUp(object sender, KeyEventArgs e)
        {
            var comboBox = (ComboBox)sender;
            this._ViewModel.CompetitorRedName = comboBox.Text;
        }

        private void ComboCompetitorBlue_KeyUp(object sender, KeyEventArgs e)
        {
            var comboBox = (ComboBox)sender;
            this._ViewModel.CompetitorBlueName = comboBox.Text;
        }
        public void OnSanctionRed(object sender, RoutedEventArgs e)
        {
            if(((Button)sender).Background != Brushes.Yellow)
                this._ViewModel.IncrementSanctionRed();
            ((Button)sender).Background = Brushes.Yellow;
        }
        public void OnSanctionBlue(object sender, RoutedEventArgs e)
        {
            if (((Button)sender).Background != Brushes.Yellow)
                this._ViewModel.IncrementSanctionBlue();
            ((Button)sender).Background = Brushes.Yellow;
        }


        private void ResetSanctions()
        {
            buttonZRed.Background = Brushes.White;
            buttonIRed.Background = Brushes.White;
            buttonIIRed.Background = Brushes.White;
            buttonDisRed.Background = Brushes.White;
            buttonZBlue.Background = Brushes.White;
            buttonIBlue.Background = Brushes.White;
            buttonIIBlue.Background = Brushes.White;
            buttonDisBlue.Background = Brushes.White;
            _ViewModel.ResetSanctions();
        }

    }


    public class SamboMatMgmtViewModel : INotifyPropertyChanged
    {
        public class Fighter
        {
            public Fighter(String fighter_color)
            {
                this.color = fighter_color;
                StopSpecialCounting();
            }

            public String Name = "";
            public String color = "";
            public long score = 0;
            public long activity = 0;

            public String special_timeout_type = "";
            public bool is_counting_medical = false;
            public bool is_counting_handle = false;
            public bool is_counting_pain = false;

            public long MedicalTime = 180;
            public long PainTime = 0;
            public long HandleTime = 0;

            public string current_special_time;
            public string special_clock;
            public string special_action;
            public long sanction = 0;
            public bool IsSpecialCountOn() { return (is_counting_medical | is_counting_handle | is_counting_pain); }
            public void StopSpecialCounting() { is_counting_medical = is_counting_handle = is_counting_pain = false;  }
        
    }

        private bool _is_counting_fight = false;
        private string _current_fight_time;

        private Fighter _bf = new Fighter("BLUE"); //Blue fighter
        private Fighter _rf = new Fighter("RED"); //Red fighter

        private DateTime _the_time;
        private long _FightLen = 180;
        private long _Weight = 20;
        public  long PainTimeMax = 60;
        public  long HandleTimeMax = 20;
        private long _handle_cost = 2;

        private RelayCommand _playCommand;
        private ScoreDisplayViewModel _DisplayWin;

        public SamboMatMgmtViewModel(ScoreDisplayViewModel dcDisplayWin)
        {
            this._DisplayWin = dcDisplayWin;

            DispatcherTimer timer = new DispatcherTimer(DispatcherPriority.Background);
            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Tick += UpdateTime;
            timer.Start();

            ResetFight();
            Weight = _Weight;
            FightLen = _FightLen;
        }

        public void ResetSanctions()
        {
            _rf.sanction = 0;
            _bf.sanction = 0;
            _DisplayWin.ResetSanctions();
        }

        public void IncrementSanctionRed()
        {
            switch (_rf.sanction)
            {
                case 0:
                    _DisplayWin.SanctionZRed = "Z";
                    break;
                case 1:
                    {
                        _DisplayWin.SanctionIRed = "I";
                        OnBlueScorePlus(1);
                        break;
                    }
                case 2:
                    {
                        _DisplayWin.SanctionIIRed = "II";
                        OnBlueScorePlus(2);
                        break;
                    }
                case 3:
                    {
                        _DisplayWin.SanctionDisRed = "DIS";
                        isCounting = false;
                        break;
                    }
            }
            _rf.sanction += 1;
        }
    public void IncrementSanctionBlue()
        {
            switch (_bf.sanction)
            {
                case 0:
                    _DisplayWin.SanctionZBlue = "Z";
                    break;
                case 1:
                    {
                        _DisplayWin.SanctionIBlue = "I";
                        OnRedScorePlus(1);
                        break;
                    }
                case 2:
                    {
                        _DisplayWin.SanctionIIBlue = "II";
                        OnRedScorePlus(2);
                        break;
                    }
                case 3:
                    {
                        _DisplayWin.SanctionDisBlue = "DIS";
                        isCounting = false;
                        break;
                    }
            }
            _bf.sanction += 1;
        }

        public String SpecialTimeoutTypeRed
        {
            get { return this._rf.special_timeout_type; }
            set
            {
                this._rf.special_timeout_type = value;
                _DisplayWin.SpecialActionRed = this._rf.special_timeout_type;
                OnPropertyChanged("SpecialTimeoutTypeRed");
            }
        }

        public String SpecialTimeoutTypeBlue
        {
            get { return this._bf.special_timeout_type; }
            set
            {
                this._bf.special_timeout_type = value;
                _DisplayWin.SpecialActionBlue = this._bf.special_timeout_type;
                OnPropertyChanged("SpecialTimeoutTypeBlue");
            }
        }

        public void OnActionMedicalRed(Int32 time)
        {
            StopSpecialCountingRed();
            _rf.MedicalTime = time;
            isCountingMedicalRed = true;
            isCounting = false;
            SpecialTimeoutTypeRed = "MEDICAL";
        }

        public void OnActionMedicalBlue(Int32 time)
        {
            StopSpecialCountingBlue();
            _bf.MedicalTime = time;
            isCountingMedicalBlue = true;
            isCounting = false;
            SpecialTimeoutTypeBlue = "MEDICAL";
        }

        public void ResetFight()
        {
            FightClock = new DateTime(0).ToString("mm:ss");
            ResetClocksRed();
            ResetClocksBlue();
            CompetitorRedName = "";
            CompetitorBlueName = "";
            ResetSanctions();
            ActivityRed = 0;
            ActivityBlue = 0;
        }

        public void ResetClocksRed()
        {
            SpecialClockRed = new DateTime(0).ToString("mm:ss");
            SpecialTimeoutTypeRed = "      ";
        }

        public void ResetClocksBlue()
        {
            SpecialClockBlue = new DateTime(0).ToString("mm:ss");
            SpecialTimeoutTypeBlue = "      ";
        }

        public String CompetitorRedName
        {
            get { return this._rf.Name; }
            set
            {
                this._rf.Name = value;
                OnPropertyChanged("CompetitorRedName");
                if(_DisplayWin != null)
                    _DisplayWin.CompetitorRedName = this._rf.Name;
            }
        }

        public String CompetitorBlueName
        {
            get { return this._bf.Name; }
            set
            {
                this._bf.Name = value;
                OnPropertyChanged("CompetitorBlueName");
                _DisplayWin.CompetitorBlueName = _bf.Name;
            }
        }

        public long HandleCost
        {
            get { return this._handle_cost; }
            set
            {

                _handle_cost = value;
                OnPropertyChanged("HandleCost");
            }
        }

        public long ScoreRed
        {
            get { return this._rf.score; }
            set
            {

                _rf.score = value;
                OnPropertyChanged("ScoreRed");

                if (_DisplayWin != null)
                    _DisplayWin.ScoreRed = this._rf.score.ToString();
            }
        }

        public long ScoreBlue
        {
            get { return this._bf.score; }
            set {

                _bf.score = value;
                OnPropertyChanged("ScoreBlue");

                if (_DisplayWin != null)
                    _DisplayWin.ScoreBlue = this._bf.score.ToString();
            }
        }

        public bool isCounting
        {
            get { return _is_counting_fight; }
            set
            {
                _is_counting_fight = value;
                OnPropertyChanged("isCounting");
            }
        }

        //Red Fighter statuses
        public bool isCountingHandleRed
        {
            get { return _rf.is_counting_handle; }
            set
            {
                _rf.is_counting_handle = value;
                _rf.HandleTime = 0;
                OnPropertyChanged("isCountingSpecialRed");
            }
        }

        public bool isCountingPainRed
        {
            get { return _rf.is_counting_pain; }
            set
            {
                _rf.is_counting_pain = value;
                _rf.PainTime = 0;
                OnPropertyChanged("isCountingSpecialRed");
            }
        }

        public bool isCountingMedicalRed
        {
            get { return _rf.is_counting_medical; }
            set
            {
                _rf.is_counting_medical = value;
                OnPropertyChanged("isCountingSpecialRed");
            }
        }

        //Red Fighter statuses
        public bool isCountingHandleBlue
        {
            get { return _bf.is_counting_handle; }
            set
            {
                _bf.is_counting_handle = value;
                _bf.HandleTime = 0;
                OnPropertyChanged("isCountingSpecialBlue");
            }
        }

        public bool isCountingPainBlue
        {
            get { return _bf.is_counting_pain; }
            set
            {
                _bf.is_counting_pain = value;
                _bf.PainTime = 0;
                OnPropertyChanged("isCountingSpecialBlue");
            }
        }

        public bool isCountingMedicalBlue
        {
            get { return _bf.is_counting_medical; }
            set
            {
                _bf.is_counting_medical = value;
                OnPropertyChanged("isCountingSpecialBlue");
            }
        }

        public bool isCountingSpecial
        {
            get { return (_rf.IsSpecialCountOn() | _bf.IsSpecialCountOn()); }
        }

        public bool isCountingSpecialRed
        {
            get { return _rf.IsSpecialCountOn(); }
        }

        public bool isCountingSpecialBlue
        {
            get { return _bf.IsSpecialCountOn(); }
        }

        public void StopSpecialCountingRed()
        {
            _rf.StopSpecialCounting();
            OnPropertyChanged("SpecialClockRed");
            OnPropertyChanged("isCountingSpecialRed");
        }

        public void StopSpecialCountingBlue()
        {
            _bf.StopSpecialCounting();
            OnPropertyChanged("SpecialClockBlue");
            OnPropertyChanged("isCountingSpecialBlue");
        }


        public ICommand FightCommand
        {
            get
            {
                return _playCommand ?? new RelayCommand((x) =>
                {
                    if (x == null) return;

                    var buttonType = x.ToString();

                    if (null != buttonType)
                    {
                        if (buttonType.Contains("start"))
                        {
                            isCounting = true;
                        }
                        else if (buttonType.Contains("stop"))
                        {
                            isCounting = false;
                        }
                    }
                });
            }
        }

        public long FightLen
        {
            get { return this._FightLen; }
            set
            {
                this._FightLen = value;
                OnPropertyChanged("FightLen");
                if (this._DisplayWin != null)
                    _DisplayWin.FightLen = this._FightLen;
            }
        }

        public long Weight
        {
            get { return this._Weight; }
            set
            {
                this._Weight = value;
                OnPropertyChanged("Weight");
                if (this._DisplayWin != null)
                    _DisplayWin.Weight = this._Weight.ToString();
            }
        }

        public string FightClock
        {
            get { return _current_fight_time; }
            set
            {
                _current_fight_time = value;
                OnPropertyChanged("FightClock");
                if (this._DisplayWin != null)
                    this._DisplayWin.FightClock = value;
            }
        }

        public string SpecialClockRed
        {
            get { return _rf.current_special_time; }
            set
            {
                _rf.current_special_time = value;
                OnPropertyChanged("SpecialClockRed");
                if (this._DisplayWin != null)
                    this._DisplayWin.SpecialClockRed = value;
            }
        }

        public string SpecialClockBlue
        {
            get { return _rf.current_special_time; }
            set
            {
                _rf.current_special_time = value;
                OnPropertyChanged("SpecialClockBlue");
                if (this._DisplayWin != null)
                    this._DisplayWin.SpecialClockBlue = value;
            }
        }

        private String UpdateSpecialTime(object sender, EventArgs e, Fighter fighter)
        {
            if (fighter.is_counting_medical)
            {
                if (fighter.MedicalTime > 0)
                    fighter.MedicalTime -= 1;
                else
                    fighter.StopSpecialCounting();


                _the_time = new DateTime(fighter.MedicalTime * 10000000);
                return _the_time.ToString("mm:ss");
            }
            else if (fighter.is_counting_handle)
            {
                if (fighter.HandleTime < HandleTimeMax)
                    fighter.HandleTime += 1;
                else
                {
                    fighter.StopSpecialCounting();
                    //isCounting = false;
                    //MessageBox.Show(String.Format("The {0} competitor will receive {1} points.", fighter.color, _handle_cost));
                    fighter.score += _handle_cost;
                    ScoreBlue = _bf.score;
                    ScoreRed = _rf.score;
                }

                _the_time = new DateTime(fighter.HandleTime * 10000000);
                return _the_time.ToString("mm:ss");
            }
            else if (fighter.is_counting_pain)
            {
                if (fighter.PainTime < PainTimeMax)
                    fighter.PainTime += 1;
                else
                {
                    fighter.StopSpecialCounting();
                }

                _the_time = new DateTime(fighter.PainTime * 10000000);
                return _the_time.ToString("mm:ss");
            }
            return "";
        }


        private void UpdateTime(object sender, EventArgs e)
        {
            if (_is_counting_fight)
            {
                if (_FightLen > 0)
                    _FightLen -= 1;

                _the_time = new DateTime(_FightLen * 10000000);
                FightClock = _the_time.ToString("mm:ss");
            }

            if (_rf.IsSpecialCountOn())
            {
                SpecialClockRed = UpdateSpecialTime(sender, e, _rf);
                if (!_rf.IsSpecialCountOn())
                    StopSpecialCountingRed();
            }

            if (_bf.IsSpecialCountOn())
            {
                SpecialClockBlue = UpdateSpecialTime(sender, e, _bf);
                if (!_bf.IsSpecialCountOn())
                    StopSpecialCountingBlue();
            }
        }

        public void OnRedScoreReset(int val)
        {
            ScoreRed = val;
        }

        public void OnRedScorePlus(int increment)
        {
            ScoreRed += increment;
        }

        public void OnRedScoreMinus(int increment)
        {
            if (ScoreRed > 0)
                ScoreRed -= increment;
        }

        public void OnBlueScoreReset(int val)
        {
            ScoreBlue = val;
        }

        public void OnBlueScorePlus(int increment)
        {
            ScoreBlue += increment;
        }

        public void OnBlueScoreMinus(int increment)
        {
            if (ScoreBlue > 0)
                ScoreBlue -= increment;
        }


        public long ActivityRed
        {
            get { return _rf.activity; }
            set
            {
                _rf.activity = value;
                OnPropertyChanged("ActivityRed");
                if (this._DisplayWin != null)
                    _DisplayWin.ActivityRed = _rf.activity.ToString();
            }
        }

        public long ActivityBlue
        {
            get { return _bf.activity; }
            set
            {
                _bf.activity = value;
                OnPropertyChanged("ActivityBlue");
                if (this._DisplayWin != null)
                    _DisplayWin.ActivityBlue = _bf.activity.ToString();
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

    public class RelayCommand : ICommand
    {
        private readonly Predicate<object> _canExecute;
        private readonly Action<object> _execute;

        public event EventHandler CanExecuteChanged;

        public RelayCommand(Action<object> execute) : this(execute, null) { }

        public RelayCommand(Action<object> execute, Predicate<object> canExecute)
        {
            _execute = execute;
            _canExecute = canExecute;
        }

        public bool CanExecute(object parameter)
        {

            if (_canExecute == null)
            {
                return true;
            }

            return _canExecute(parameter);
        }

        public void Execute(object parameter)
        {
            _execute(parameter);
        }

        public void RaiseCanExecuteChanged()
        {
            if (CanExecuteChanged != null)
            {
                CanExecuteChanged(this, EventArgs.Empty);
            }
        }
    }
}
