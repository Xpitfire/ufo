using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PostSharp.Patterns.Model;
using UFO.Commander.Helper;
using UFO.Commander.Proxy;
using UFO.Server.Bll.Common;
using UFO.Server.Domain;

namespace UFO.Commander.ViewModel.Entities
{
    [NotifyPropertyChanged]
    public class UserCollectionViewModel
    {
        private readonly IAdminAccessBll _adminAccessBll = BllFactory.CreateAdminAccessBll();
        public ObservableCollection<UserViewModel> UserCollection => new ObservableCollection<UserViewModel>();

        public UserCollectionViewModel(SessionToken token)
        {
            // TODO: Get page request due to MessageSizeExceeded
            var users = _adminAccessBll.GetAllUser(token);
            foreach (var user in users)
            {
                UserCollection.Add(user.ToViewModelObject<UserViewModel>());
            }
        }

    }
}
