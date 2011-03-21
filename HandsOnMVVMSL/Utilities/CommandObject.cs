using System;
using System.Windows.Input;

namespace HandsOnMVVMSL.Utilities
{
    public class CommandObject : ICommand
    {
        private Func<bool> _condition;
        private Action _action;

        public CommandObject(Func<bool> condition, Action action)
        {
            _condition = condition;
            _action = action;
        }

        public CommandObject(Action action)
        {
            _condition = null;
            _action = action;
        }

        public bool CanExecute(object parameter)
        {
            return _condition == null ? true : _condition();
        }

        public void FireCanExecuteChanged()
        {
            if (CanExecuteChanged != null)
                CanExecuteChanged(this, new EventArgs());
        }

        public event EventHandler CanExecuteChanged;

        public void Execute(object parameter)
        {
            _action();
        }
    }
}
