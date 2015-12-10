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
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
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

            userDao.SelectWhere(users => users.Where(u => u.IsAdmin))
                .OnSuccess(users =>
                {
                    foreach (var user in users)
                    {
                        Console.WriteLine($"Update user: ({user}) successful");
                    }
                })
                .OnFailure(response => { throw response.Exception; });

            var performanceDao = daoFacotry.CreatePerformanceDao();
            performanceDao.SelectById(new DateTime(2015, 11, 15, 22, 00, 00), 64)
                .OnSuccess(response => Console.WriteLine($"{response.ResultObject}"))
                .OnEmptyResult(() => Console.WriteLine("No performance data found!"))
                .OnFailure(response => Console.WriteLine($"{response.Exception}"));

            Console.ReadLine();
        }
    }
}
