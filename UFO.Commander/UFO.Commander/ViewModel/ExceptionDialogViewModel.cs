﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using GalaSoft.MvvmLight.Messaging;
using UFO.Commander.Messages;

namespace UFO.Commander.ViewModel
{
    public class ExceptionDialogViewModel : ViewModelBase
    {
        public ExceptionDialogViewModel()
        {
            ConfirmCommand = new RelayCommand(() =>
            {
                Messenger.Default.Send(new HideExceptionDialogMessage(this));
            });
        }

        public RelayCommand ConfirmCommand { get; set; }

        public Exception Exception { get; set; }
        public string Message { get; set; }
        public string Title { get; set; }

        public override string ToString()
        {
            return "UFO Exception";
        }
    }
}
