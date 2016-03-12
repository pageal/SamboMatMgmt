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

namespace SamboMatMgmt
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public int _start_pause = 0;
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
    }


    public class SamboMatMgmtViewModel : INotifyPropertyChanged
    {
        private bool _isPlaying = false;
        private RelayCommand _playCommand;
        private ScoreDisplayViewModel _DisplayWin;
        private String _CompetitorRedName = "";
        private String _CompetitorBlueName = "";
        private int _FightTime;

        public SamboMatMgmtViewModel(ScoreDisplayViewModel dcDisplayWin)
        {
            isPlaying = false;
            this._DisplayWin = dcDisplayWin;
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

        public int FightTime
        {
            get { return this._FightTime; }
            set
            {
                this._FightTime = value;
                _DisplayWin.FightTime = this._FightTime;
            }
        }

        public bool isPlaying
        {
            get { return _isPlaying; }
            set
            {
                _isPlaying = value;
                OnPropertyChanged("isPlaying");
                if(this._DisplayWin != null)
                    this._DisplayWin.isCounting = value;
            }
        }

        public ICommand PlayCommand
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
                            isPlaying = true;
                        }
                        else if (buttonType.Contains("stop"))
                        {
                            isPlaying = false;
                        }
                    }
                });
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
