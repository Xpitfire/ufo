#region copyright
// (C) Copyright 2015 Dinu Marius-Constantin (http://dinu.at) and others.
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
//     http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
//
// Contributors:
//     Dinu Marius-Constantin
#endregion
using System;
using System.Windows.Input;

namespace UFO.Commander.ViewModels
{
    // RelayCommand objects delegate to the methods passed
    // as an argument.
    public class RelayCommand : ICommand
    {
        readonly Action<object> _executeAction;
        readonly Predicate<object> _canExecutePredicate;
        
        public RelayCommand(Action<object> execute)
          : this(execute, null)
        {
        }

        public RelayCommand(Action<object> execute, Predicate<object> canExecute)
        {
            if (execute == null)
                throw new ArgumentNullException(nameof(execute));

            _executeAction = execute;
            _canExecutePredicate = canExecute;
        }

        // Invoked when command is executed
        public void Execute(object parameter)
        {
            _executeAction(parameter);
        }

        // The returned value indicates whether command is active (can be executed) or not.
        public bool CanExecute(object parameter)
        {
            return _canExecutePredicate == null || _canExecutePredicate(parameter);
        }

        // Occurs when changes occur that affect whether or not the command should execute.
        // The handling of this event ist delegated to the CommandManger.
        // WPF invokes CanExecute in response to this event. CanExecute returns the
        // command's state.
        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }
    }
}
