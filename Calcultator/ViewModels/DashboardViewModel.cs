using Dangl.Calculator;
using System.ComponentModel;
using System.Windows.Input;

namespace Calcultator.ViewModels
{
    public class DashboardViewModel : INotifyPropertyChanged
    {
        #region Events
        public event PropertyChangedEventHandler PropertyChanged;
        #endregion

        #region Full properties
        private string _formula;

        public string Formula
        {
            get => _formula;
            set
            {
                if (_formula != value)
                {
                    _formula = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Formula)));
                }
            }
        }

        private string _result;

        public string Result
        {
            get => _result;
            set
            {
                if (_result != value)
                {
                    _result = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Result)));
                }
            }
        }
        #endregion

        #region Commands
        public ICommand OperationCommand => new Command<string>(UpdateOperation);
        
        public ICommand ClearCommand => new Command(() =>
        {
            Result = "0";
            Formula = string.Empty;
        });

        public ICommand BackSpaceCommand => new Command(() =>
        {
            if(Formula.Any())
            {
                Formula = Formula.Substring(0, Formula.Length - 1);
            }
        });

        public ICommand CalculateCommand => new Command(() =>
        {
            if(!Formula.Any())
            {
                return;
            }

            var calculation = Calculator.Calculate(Formula);

            Result = calculation.Result.ToString();
        });
        #endregion

        #region Constructors
        public DashboardViewModel()
        {
            Result = "0";
        }
        #endregion

        #region Methods
        private void UpdateOperation(string number)
        {
            Formula += number;
        }
        #endregion
    }
}