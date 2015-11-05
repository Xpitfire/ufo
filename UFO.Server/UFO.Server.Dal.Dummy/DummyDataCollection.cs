using System.Collections.Concurrent;
using System.Collections.Generic;
using FH.SEv.UFO.Server.Model.Entities;
using FH.SEv.UFO.Server.Model.Helper;
using Ploeh.AutoFixture;

namespace FH.SEv.UFO.Server.Dao.Impl
{
    sealed class DummyDataCollection
    {
        public static readonly BlockingCollection<Agenda> Agendas = new BlockingCollection<Agenda>();

        public static readonly BlockingCollection<Artist> Artists = new BlockingCollection<Artist>();
        
        public static readonly BlockingCollection<User> Users = new BlockingCollection<User>();

        public static readonly BlockingCollection<Venue> Venues = new BlockingCollection<Venue>();
        
        public static readonly BlockingCollection<Performance> Performances = new BlockingCollection<Performance>();
        
        static DummyDataCollection()
        {
            // User demo data
            // Password examples use MD5 hashing --> http://www.danstools.com/md5-hash-generator/
            var userList = new List<User>
            {
                new User
                {
                    ArtistId = 1,
                    EMail = "marius.dinu@mail.com",
                    FistName = "Marius",
                    LastName = "Dinu",
                    PasswordHash = "cfefe3e7c1ce34edfd95f0386ab03724", // PW: theTools48297!
                    IsAdmin = true,
                    IsArtist = true
                },
                new User
                {
                    ArtistId = 2,
                    EMail = "chesterbenn@live.com",
                    FistName = "Chester",
                    LastName = "Bennington",
                    PasswordHash = "098f6bcd4621d373cade4e832627b4f6", // PW: test
                    IsAdmin = false,
                    IsArtist = true
                },
                new User
                {
                    ArtistId = 3,
                    EMail = "shinoda@hotmail.com",
                    FistName = "Mike",
                    LastName = "Shinoda",
                    PasswordHash = "a4f5dfd41d26f7fb0972ba8a77eead30", // PW: se8ndkKhHnd3821!D$
                    IsAdmin = false,
                    IsArtist = true
                },
                new User
                {
                    ArtistId = 4,
                    EMail = "hallo@mail.com",
                    FistName = "Peter",
                    LastName = "Fox",
                    PasswordHash = "5f4dcc3b5aa765d61d8327deb882cf99", // PW: password
                    IsAdmin = false,
                    IsArtist = true
                }
            };
            for (var i = 0; i < 100; i++)
                userList.Add(DummyDataGenerator.GenerateUser());

            Users.AddRange(userList);
        }
    }

    public sealed class DummyDataGenerator
    {
        private static int _userIdCnt = 100;

        public static User GenerateUser()
        {
            var fixture = new Fixture();
            var user = fixture.Build<User>();

            fixture.Customize<User>(c => c
            .With(u => u.ArtistId, _userIdCnt++)
            .With(u => u.EMail, $"{fixture.Create<string>()}@{fixture.Create<string>()}.com")
            .With(u => u.FistName, fixture.Create<string>())
            );

            return user.Create();
        }
    }
}
