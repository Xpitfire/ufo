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
        private readonly SessionToken _sessionToken;
        
        public PagingData Page { get; set; }

        public ObservableCollection<UserViewModel> UserViewModels { get; }

        public UserCollectionViewModel(SessionToken token)
        {
            UserViewModels = new ObservableCollection<UserViewModel>();
            _sessionToken = token;
        }

        public void RequestPagingDataInit()
        {
            Page = _adminAccessBll.RequestUserPagingData(_sessionToken);
        }

        public void GetNextPage()
        {
            var parcialUsers = _adminAccessBll.GetUser(_sessionToken, Page);
            if (parcialUsers == null || !parcialUsers.Any())
                return;
            Page.ToNextPage();
            foreach (var userVm in parcialUsers.Select(user => user.ToViewModelObject<UserViewModel>()))
            {
                UserViewModels.Add(userVm);
            }
        }
    }
}
