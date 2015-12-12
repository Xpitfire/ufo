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
using UFO.Server.Bll.Common;

namespace UFO.Commander.Proxy
{
    public enum BllType
    {
        WebService,
        Local
    }

    public static class BllFactory
    {
        public static IAdminAccessBll CreateAdminAccessBll(BllType type = BllType.WebService)
        {
            switch (type)
            {
                case BllType.WebService:
                    return new AdminAccessProxy();

                default:
                    throw new ArgumentException("Unsupported type for BLL Factory instance creation.");
            }
        }

        public static IViewAccessBll CreateViewAccessBll(BllType type = BllType.WebService)
        {
            switch (type)
            {
                case BllType.WebService:
                    return new ViewAccessProxy();

                default:
                    throw new ArgumentException("Unsupported type for BLL Factory instance creation.");
            }
        }

    }
}
