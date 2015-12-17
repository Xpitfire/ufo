using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight;
using MahApps.Metro.Controls.Dialogs;

namespace UFO.Commander.Views
{
    public class DialogLocator
    {
        private static readonly List<BaseMetroDialog> Dialogs = new List<BaseMetroDialog>();

        private static TDialog Register<TDialog>() where TDialog : BaseMetroDialog
        {
            var type = typeof(TDialog);
            var instance = (TDialog) Activator.CreateInstance(type);
            Dialogs.Add(instance);
            return instance;
        }

        public static TDialog GetInstance<TDialog>() where TDialog : BaseMetroDialog
        {
            foreach (var dialog in Dialogs.OfType<TDialog>())
            {
                return dialog;
            }
            return Register<TDialog>();
        }
    }
}
