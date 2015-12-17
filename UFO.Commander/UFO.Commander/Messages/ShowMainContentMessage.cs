﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Messaging;

namespace UFO.Commander.Messages
{
    public class ShowMainContentMessage : ShowDialogMessage
    {
        public ShowMainContentMessage(ViewModelBase viewModel) : base(viewModel)
        {
        }
    }
}