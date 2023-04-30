using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Input;

namespace EsercizioWPF.Models.ViewModels
{
    public class RelayCommander : ICommand
    {
        public event EventHandler? CanExecuteChanged;
        private Action<object> ExecuteMethod;
        private Predicate<object> CanExecuteMethod;

        public RelayCommander(Action<object> executeMethod, Predicate<object> executePredicate)
        {
            this.ExecuteMethod = executeMethod;
            this.CanExecuteMethod = executePredicate;
        }

        public RelayCommander(Action<object> Excute) : this(Excute, null)
        { }

        public bool CanExecute(object parameter)
        {
            return (CanExecuteMethod == null) ? true : CanExecuteMethod.Invoke(parameter);
        }

        public void Execute(object? parameter)
        {
            ExecuteMethod.Invoke(parameter);
        }

        public void RaiseCanExecuteChanged()
        {
            CanExecuteChanged?.Invoke(this, EventArgs.Empty);
        }
    }

    public abstract class ViewModelBase : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }


    }

    public class MainWindowViewModels : ViewModelBase
    {
        private Models.IPersonaService _personaService = null;
        public RelayCommander SalutamiCommand { get; private set; }
        public IList<Persona> Persone => _personaService.Persone;
        //public Models.Persona PersonaSelezionata { get; set; }
        public Models.Persona _PersonaSelezionata = null;
        private string _TextSalut;

        public Models.Persona PersonaSelezionata
        {

            get { return _PersonaSelezionata; }

            set
            {
                if (_PersonaSelezionata == value) return;
                _PersonaSelezionata = value;
                NotifyPropertyChanged();
                SalutamiCommand.RaiseCanExecuteChanged();

            }
        }
        public MainWindowViewModels(Models.IPersonaService personaService)
        {
            _personaService = personaService;
            SalutamiCommand = new RelayCommander(salutaMethod, salutaCanExec);
        }


        private void salutaMethod(object parm)
        {
            Saluto();
        }


        private bool salutaCanExec(object parm)
        {
            return PersonaSelezionata != null;
        }

        public string TextSaluto
        {
            get { return _TextSalut; }

            set
            {
                _TextSalut = value;
                NotifyPropertyChanged();
            }
        }

        public void Saluto()
        {
            if (PersonaSelezionata != null)
            {
                TextSaluto = $"ciao {PersonaSelezionata.Nome} {PersonaSelezionata.Cognome}";
            }

        }
    }

}
