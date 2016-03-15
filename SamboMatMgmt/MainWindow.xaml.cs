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

        private void FightTime_LostFocus(object sender, RoutedEventArgs e)
        {
            var comboBox = (ComboBox)sender;
            if (!String.IsNullOrEmpty(comboBox.Text))
            {
                this._ViewModel.FightTime = (int)(Convert.ToDouble(comboBox.Text)*60);
                //comboBox.SelectedItem = newItem;
            }
        }

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
            _ViewModel.OnRedScoreReset(Convert.ToInt32(textBoxBlueReset.Text));
        }

    }


    public class SamboMatMgmtViewModel : INotifyPropertyChanged
    {
        public int _start_pause = 0;
        private bool _is_counting = false;
        private string _currenttime;
        private DateTime _the_time;
        private long _FightTime = 180;
        private RelayCommand _playCommand;
        private ScoreDisplayViewModel _DisplayWin;

        private String  _CompetitorRedName = "";
        private long _score_red = 0;

        private String  _CompetitorBlueName = "";
        private long _score_blue = 0;

        public SamboMatMgmtViewModel(ScoreDisplayViewModel dcDisplayWin)
        {
            this._DisplayWin = dcDisplayWin;

            DispatcherTimer timer = new DispatcherTimer(DispatcherPriority.Background);
            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Tick += UpdateTime;
            timer.Start();
        }

        public String CompetitorRedName
        {
            get { return this._CompetitorRedName; }
            set
            {
                this._CompetitorRedName = value;
                _DisplayWin.CompetitorRedName = this._CompetitorRedName;
            }
        }

        public String CompetitorBlueName
        {
            get { return this._CompetitorBlueName; }
            set
            {
                this._CompetitorBlueName = value;
                _DisplayWin.CompetitorBlueName = this._CompetitorBlueName;
            }
        }

        public String ScoreRed
        {
            get { String score = this._score_red.ToString(); _DisplayWin.ScoreRed = score; return score; }
        }

        public String ScoreBlue
        {
            get { String score = this._score_blue.ToString(); _DisplayWin.ScoreBlue = score;  return score; }
            
        }

        public long FightTime
        {
            get { return this._FightTime; }
            set
            {
                this._FightTime = value;
                _DisplayWin.FightTime = this._FightTime;
            }
        }

        public bool isCounting
        {
            get { return _is_counting; }
            set
            {
                _is_counting = value;
                OnPropertyChanged("isCounting");
                if (this._DisplayWin != null)
                    this._DisplayWin.isCounting = value;
            }
        }

        public ICommand FightCommand
        {
            get
            {
                return _playCommand ?? new RelayCommand((x) =>
                {
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

        public string CurrentTime
        {
            get { return _currenttime; }
            set
            {
                _currenttime = value;
                OnPropertyChanged("CurrentTime");
                if (this._DisplayWin != null)
                    this._DisplayWin.CurrentTime = value;
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

        public void OnRedScoreReset(int val)
        {
            _score_red = val;
            OnPropertyChanged("ScoreRed");

        }

        public void OnRedScorePlus(int increment)
        {
            _score_red += increment;
            OnPropertyChanged("ScoreRed");

        }

        public void OnRedScoreMinus(int increment)
        {
            _score_red -= increment;
            if (_score_red < 0)
                _score_red = 0;
            OnPropertyChanged("ScoreRed");

        }

        public void OnBlueScoreReset(int val)
        {
            _score_blue = val;
            OnPropertyChanged("ScoreBlue");

        }

        public void OnBlueScorePlus(int increment)
        {
            _score_blue += increment;
            OnPropertyChanged("ScoreBlue");

        }

        public void OnBlueScoreMinus(int increment)
        {
            _score_blue -= increment;
            if (_score_blue < 0)
                _score_blue = 0;
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
