using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UFO.Server.Dal.Common
{
    public static class DaoResponseExtension
    {
        public static async Task<DaoResponse<TDaoType>> OnSuccessAsync<TDaoType>(this DaoResponse<TDaoType> daoResponse, Action action)
        {
            return await Task.Run(() =>
            {
                if (daoResponse.ResponseStatus == DaoStatus.Successful)
                    action();
                return daoResponse;
            });
        }

        public static async Task<DaoResponse<TDaoType>> OnSuccessAsync<TDaoType>(this DaoResponse<TDaoType> daoResponse, Action<TDaoType> action)
        {
            return await Task.Run(() =>
            {
                if (daoResponse.ResponseStatus == DaoStatus.Successful)
                    action(daoResponse.ResultObject);
                return daoResponse;
            });
        }

        public static async Task<DaoResponse<TDaoType>> OnSuccessAsync<TDaoType>(this DaoResponse<TDaoType> daoResponse, Action<DaoResponse<TDaoType>> action)
        {
            return await Task.Run(() =>
            {
                if (daoResponse.ResponseStatus == DaoStatus.Successful)
                    action(daoResponse);
                return daoResponse;
            });
        }

        public static async Task<DaoResponse<TDaoType>> OnFailureAsync<TDaoType>(this DaoResponse<TDaoType> daoResponse, Action<DaoResponse<TDaoType>> action)
        {
            return await Task.Run(() =>
            {
                if (daoResponse.ResponseStatus != DaoStatus.Successful)
                    action(daoResponse);
                return daoResponse;
            });
        }

    }
}
