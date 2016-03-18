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
        }

        private void ComboCompetitorRed_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //this._ViewModel.CompetitorRedName = e;

        }
        private void ComboCompetitorRed_LostFocus(object sender, RoutedEventArgs e)
        {
            var comboBox = (ComboBox)sender;
            this._ViewModel.CompetitorRedName = comboBox.Text;
            //comboBox.SelectedItem = newItem;
        }

        private void ComboCompetitorBlue_LostFocus(object sender, RoutedEventArgs e)
        {
            var comboBox = (ComboBox)sender;
            this._ViewModel.CompetitorBlueName = comboBox.Text;
            //comboBox.SelectedItem = newItem;
        }

        private void FightLen_LostFocus(object sender, RoutedEventArgs e)
        {
            var comboBox = (ComboBox)sender;
            if (!String.IsNullOrEmpty(comboBox.Text))
            {
                this._ViewModel.FightLen = (int)(Convert.ToDouble(comboBox.Text));
                //comboBox.SelectedItem = newItem;
            }
        }

        // Score events for Red Fighter
        private void OnRedScoreReset(object sender, RoutedEventArgs e)
        {
            _ViewModel.OnRedScoreReset(Convert.ToInt32(textBoxRedReset.Text));
        }

        private void OnRedPlus1(object sender, RoutedEventArgs e)
        {
            _ViewModel.OnRedScorePlus(Convert.ToInt32(textBoxRedPlus1.Text));
        }

        private void OnRedScorePlus2(object sender, RoutedEventArgs e)
        {
            _ViewModel.OnRedScorePlus(Convert.ToInt32(textBoxRedPlus2.Text));
        }

        private void OnRedScorePlus4(object sender, RoutedEventArgs e)
        {
            _ViewModel.OnRedScorePlus(Convert.ToInt32(textBoxRedPlus4.Text));
        }

        private void OnRedScoreMinus1(object sender, RoutedEventArgs e)
        {
            _ViewModel.OnRedScoreMinus(Convert.ToInt32(textBoxRedMinus1.Text));
        }

        // Score events for Blue Fighter
        private void OnBluePlus1(object sender, RoutedEventArgs e)
        {
            _ViewModel.OnBlueScorePlus(Convert.ToInt32(textBoxBluePlus1.Text));
        }
        private void OnBlueScorePlus2(object sender, RoutedEventArgs e)
        {
            _ViewModel.OnBlueScorePlus(Convert.ToInt32(textBoxBluePlus2.Text));
        }
        private void OnBlueScorePlus4(object sender, RoutedEventArgs e)
        {
            _ViewModel.OnBlueScorePlus(Convert.ToInt32(textBoxBluePlus4.Text));
        }
        private void OnBlueScoreMinus1(object sender, RoutedEventArgs e)
        {
            _ViewModel.OnBlueScoreMinus(Convert.ToInt32(textBoxBlueMinus1.Text));
        }
        private void OnBlueScoreReset(object sender, RoutedEventArgs e)
        {
            _ViewModel.OnBlueScoreReset(Convert.ToInt32(textBoxBlueReset.Text));
        }

        private void OnActionHoldRed(object sender, RoutedEventArgs e)
        {
            _ViewModel.StopSpecialCountingRed();
            _ViewModel.HandleTimeMax = Convert.ToInt32(textBoxHold.Text);

            _ViewModel.isCountingHandleRed = true;
            _ViewModel.isCounting = false;
            lblSpecialActionRed.Content = "HANDLE";
            //SetSpecialClockBackground("#FFD31A1A");
        }

        private void OnActionHoldBlue(object sender, RoutedEventArgs e)
        {
            _ViewModel.StopSpecialCountingBlue();
            _ViewModel.HandleTimeMax = Convert.ToInt32(textBoxHoldBlue.Text);
            _ViewModel.isCountingHandleBlue = true;
            _ViewModel.isCounting = false;
            lblSpecialActionBlue.Content = "HANDLE";
            //SetSpecialClockBackground("#FF1414DC");
        }

        private void OnActionPainRed(object sender, RoutedEventArgs e)
        {
            _ViewModel.StopSpecialCountingRed();
            _ViewModel.PainTimeMax = Convert.ToInt32(textBoxPain.Text);
            _ViewModel.isCountingPainRed = true;
            lblSpecialActionRed.Content = "PAIN";
            _ViewModel.isCounting = false;
            //SetSpecialClockBackground("#FFD31A1A");
        }

        private void OnActionPainBlue(object sender, RoutedEventArgs e)
        {
            _ViewModel.StopSpecialCountingBlue();
            _ViewModel.PainTimeMax = Convert.ToInt32(textBoxPainBlue.Text);
            _ViewModel.isCountingPainBlue = true;
            lblSpecialActionBlue.Content = "PAIN";
            _ViewModel.isCounting = false;
            //SetSpecialClockBackground("#FF1414DC");
        }

        private void OnActionMedicalRed(object sender, RoutedEventArgs e)
        {
            lblSpecialActionRed.Content = "MEDICAL";
            _ViewModel.OnActionMedicalRed(Convert.ToInt32(textBoxMedical.Text));
            //SetSpecialClockBackground("#FFD31A1A");
        }

        private void OnActionMedicalBlue(object sender, RoutedEventArgs e)
        {
            _ViewModel.StopSpecialCountingBlue();
            _ViewModel.OnActionMedicalBlue(Convert.ToInt32(textBoxMedicalBlue.Text));
            //SetSpecialClockBackground("#FF1414DC");
        }

        private void OnSpecialActionStopRed(object sender, RoutedEventArgs e)
        {
            _ViewModel.StopSpecialCountingRed();
            if(_ViewModel.isCountingSpecial)
                _ViewModel.isCounting = true;
        }

        private void OnSpecialActionStopBlue(object sender, RoutedEventArgs e)
        {
            _ViewModel.StopSpecialCountingBlue();
            if (_ViewModel.isCountingSpecial)
                _ViewModel.isCounting = true;
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
            _ViewModel.ResetClocks();
        }

        private void OnWeightEditKeyIp(object sender, KeyEventArgs e)
        {
            var comboBox = (ComboBox)sender;
            if (!String.IsNullOrEmpty(comboBox.Text))
            {
                this._ViewModel.Weight = (int)(Convert.ToDouble(comboBox.Text));
                //comboBox.SelectedItem = newItem;
            }
        }
    }


    public class SamboMatMgmtViewModel : INotifyPropertyChanged
    {
        public class Fighter
        {
            public Fighter()
            {
                StopSpecialCounting();
            }

            public String Name = "";
            public long score = 0;

            public bool is_counting_medical = false;
            public bool is_counting_handle = false;
            public bool is_counting_pain = false;

            public long MedicalTime = 180;
            public long PainTime = 0;
            public long HandleTime = 0;

            public string current_special_time;
            public string special_clock;
            public string special_action;
            public bool IsSpecialCountOn() { return (is_counting_medical | is_counting_handle | is_counting_pain); }
            public void StopSpecialCounting() { is_counting_medical = is_counting_handle = is_counting_pain = false;  }
        
    }

        private bool _is_counting_fight = false;
        private string _current_fight_time;

        private Fighter _bf = new Fighter(); //Blue fighter
        private Fighter _rf = new Fighter(); //Red fighter

        private DateTime _the_time;
        private long _FightLen = 180;
        private long _Weight = 20;
        public  long PainTimeMax = 60;
        public  long HandleTimeMax = 20;

        private RelayCommand _playCommand;
        private ScoreDisplayViewModel _DisplayWin;

        public SamboMatMgmtViewModel(ScoreDisplayViewModel dcDisplayWin)
        {
            this._DisplayWin = dcDisplayWin;

            DispatcherTimer timer = new DispatcherTimer(DispatcherPriority.Background);
            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Tick += UpdateTime;
            timer.Start();

            ResetClocks();
            Weight = _Weight;
        }

        public void OnActionMedicalRed(Int32 time)
        {
            StopSpecialCountingRed();
            _rf.MedicalTime = time;
            isCountingMedicalRed = true;
            isCounting = false;
        }

        public void OnActionMedicalBlue(Int32 time)
        {
            StopSpecialCountingBlue();
            _bf.MedicalTime = time;
            isCountingMedicalBlue = true;
            isCounting = false;
        }

        public void ResetClocks()
        {
            FightClock = new DateTime(0).ToString("mm:ss");
            SpecialClockRed = new DateTime(0).ToString("mm:ss");
            SpecialClockBlue = new DateTime(0).ToString("mm:ss");
        }
        public String CompetitorRedName
        {
            get { return this._rf.Name; }
            set
            {
                this._rf.Name = value;
                _DisplayWin.CompetitorRedName = this._rf.Name;
            }
        }

        public String CompetitorBlueName
        {
            get { return this._bf.Name; }
            set
            {
                this._bf.Name = value;
                _DisplayWin.CompetitorBlueName = _bf.Name;
            }
        }

        public String ScoreRed
        {
            get { String score = this._rf.score.ToString(); _DisplayWin.ScoreRed = score; return score; }
        }

        public String ScoreBlue
        {
            get { String score = this._bf.score.ToString(); _DisplayWin.ScoreBlue = score;  return score; }
            
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
            get { return (_rf.is_counting_medical | _rf.is_counting_handle | _rf.is_counting_pain | _bf.is_counting_medical | _bf.is_counting_handle | _bf.is_counting_pain); }
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
                _DisplayWin.FightLen = this._FightLen;
            }
        }

        public long Weight
        {
            get { return this._Weight; }
            set
            {
                this._Weight = value;
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

                _the_time = new DateTime(fighter.MedicalTime * 10000000);
                return _the_time.ToString("mm:ss");
            }
            else if (fighter.is_counting_handle)
            {
                if (fighter.HandleTime < HandleTimeMax)
                    fighter.HandleTime += 1;

                _the_time = new DateTime(fighter.HandleTime * 10000000);
                return _the_time.ToString("mm:ss");
            }
            else if (fighter.is_counting_pain)
            {
                if (fighter.PainTime < PainTimeMax)
                    fighter.PainTime += 1;

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

            if(_rf.IsSpecialCountOn())
                SpecialClockRed = UpdateSpecialTime(sender, e, _rf);

            if (_bf.IsSpecialCountOn())
                SpecialClockBlue = UpdateSpecialTime(sender, e, _bf);
        }

        public void OnRedScoreReset(int val)
        {
            _rf.score = val;
            OnPropertyChanged("ScoreRed");

        }

        public void OnRedScorePlus(int increment)
        {
            _rf.score += increment;
            OnPropertyChanged("ScoreRed");

        }

        public void OnRedScoreMinus(int increment)
        {
            _rf.score -= increment;
            if (_rf.score < 0)
                _rf.score = 0;
            OnPropertyChanged("ScoreRed");

        }

        public void OnBlueScoreReset(int val)
        {
            _bf.score = val;
            OnPropertyChanged("ScoreBlue");

        }

        public void OnBlueScorePlus(int increment)
        {
            _bf.score += increment;
            OnPropertyChanged("ScoreBlue");

        }

        public void OnBlueScoreMinus(int increment)
        {
            _bf.score -= increment;
            if (_bf.score < 0)
                _bf.score = 0;
            OnPropertyChanged("ScoreBlue");
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
