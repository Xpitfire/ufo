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
using System.Collections.Generic;
using System.Linq;
using UFO.Server.Bll.Common;
using UFO.Server.Domain;

namespace UFO.Server.Bll.Impl
{
    public class SessionHandler : ISessionBll
    {
        private static SessionHandler _instance;
        public static SessionHandler Instance => _instance ?? (_instance = new SessionHandler());

        private const int MaxSessions = 100;
        private static int _sessionIndex = 0;
        private static readonly SessionToken[] SessionIds = new SessionToken[MaxSessions]; 

        private readonly Dictionary<SessionToken, IAuthAccessBll> _sessionDirectory = new Dictionary<SessionToken, IAuthAccessBll>();

        private SessionHandler()
        {
        }

        public void RegisterUserSession(SessionToken token, IAuthAccessBll authAccessBll)
        {
            lock (_sessionDirectory)
            {
                if (token?.SessionId == null || token.User == null)
                    return;
                _sessionDirectory[token] = authAccessBll;
                Console.WriteLine($"Registered new session key: {token}");
            }
        }

        public void DeleteUserSession(SessionToken token)
        {
            lock (_sessionDirectory)
            {
                var value = _sessionDirectory.Keys.AsParallel().FirstOrDefault(x => x.User.Equals(token.User));
                if (value == null)
                    return;
                _sessionDirectory.Remove(value);
                Console.WriteLine($"Removed session key: {value}");
            }
        }

        public User GetUserFromSession(SessionToken token)
        {
            lock (_sessionDirectory)
            {
                if (_sessionDirectory.ContainsKey(token)
                    && _sessionDirectory.AsParallel().Any(x => x.Key.Equals(token)))
                    return token.User;
            }
            return null;
        }

        public SessionToken RequestSessionId(User user)
        {
            lock (_sessionDirectory)
            {
                var index = ++_sessionIndex % MaxSessions;
                var sessionId = GenerateSessionIds.GenerateRandomString();
                var sessionToken = new SessionToken
                {
                    SessionId = sessionId.ToCharArray(0, sessionId.Length),
                    User = user
                };
                SessionIds[index] = sessionToken;
                Console.WriteLine($"Created new session key: {new string(sessionToken.SessionId)}");
                return sessionToken;
            }
        }
    }

    internal class GenerateSessionIds
    {
        private const int SessionKeyLength = 128;
        // available char
        private static string possibleChars = "0123456789ABCDEF";
        // optimized (?) what's available
        private static readonly char[] PossibleCharsArray = possibleChars.ToCharArray();
        // optimized (precalculated) count
        private static readonly int PossibleCharsAvailable = possibleChars.Length;
        // shared randomization thingy
        private static readonly Random Random = new Random();

        public static string GenerateRandomString()
        {
            var num = SessionKeyLength;
            var rBytes = new byte[num];
            Random.NextBytes(rBytes);
            var rName = new char[num];
            while (num-- > 0)
                rName[num] = PossibleCharsArray[rBytes[num] % PossibleCharsAvailable];
            return new string(rName);
        }
    }
}
