using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UFO.Server.Dal.Common;
using UFO.Server.Domain;

namespace UFO.Server
{
    class Program
    {
        static void Main(string[] args)
        {
            var daoFacotry = DalProviderFactories.GetDaoFactory();
            var artistDao = daoFacotry.CreateArtistDao();
            artistDao.Update(new Artist())
                .OnSuccess(artist => Console.WriteLine($"Found artist id: {artist.ArtistId}"))
                .OnFailure(response => Console.WriteLine($"Error: {response.ErrorMessage}; {response.Exception}"));

            artistDao.SelectAll()
                .OnSuccess(list =>
                {
                    foreach (var artist in list)
                    {
                        Console.WriteLine($"{artist}");
                    }
                })
                .OnFailure(response => Console.WriteLine($"Error: {response.ErrorMessage}"));

            var userDao = daoFacotry.CreateUserDao();
            userDao.SelectWhere<IList<User>>((list, value) => list.Where(x => x.Artist != null))
                .OnSuccess(list =>
                {
                    foreach (var user in list)
                    {
                        Console.WriteLine($"{user}");
                    }
                });
            
            Console.ReadLine();
        }
    }
}
