using System;
using UFO.Server.Dal.Common;
using UFO.Server.Domain;

namespace UFO.Server.Bll.Common.Helper
{
    public static class PagingHelper
    {
        public static PagingData RequestPagingData<TEntity>(ICommonDao<TEntity> dao) where TEntity : DomainObject
        {
            var count = dao.Count().ResultObject;
            return new PagingData
            {
                Offset = 0,
                Request = Constants.DefaultPageResultCount,
                Remaining = count,
                Size = count
            };
        }

        public static bool IsPageValid(PagingData page)
        {
            return page != null
                   && page.Request > 0
                   && page.Offset >= 0
                   && page.Remaining > 0
                   && page.Size > 0
                   && page.Remaining <= page.Size
                   && page.Offset < page.Size;
        }

        public static TResult EvaluatePagingResult<TResult>(PagingData page, Func<TResult> function)
        {
            return IsPageValid(page) ? function() : default(TResult);
        }
    }
}
