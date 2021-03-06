﻿#region copyright
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
using System.ServiceModel;
using System.ServiceModel.Description;
using UFO.Server.Properties;
using UFO.Server.Services;

namespace UFO.Server
{
    class Program
    {
        static void Main()
        {
            var host = Settings.Default.WebAccessServiceAdress;
            var port = Settings.Default.WebAccessServicePort;

            var adminAccessName = "AdminAccess";
            var viewAccessName = "ViewAccess";

            ServiceHost adminAccessServiceHost = null;
            ServiceHost viewAccessServiceHost = null;
            try
            {
                // Base Address for StudentService
                var adminAccessUri = new Uri($"{host}:{port}/{adminAccessName}");
                var viewAccessUri = new Uri($"{host}:{port}/{viewAccessName}");

                // Instantiate ServiceHost
                adminAccessServiceHost = new ServiceHost(typeof(AdminAccessWs), adminAccessUri);
                viewAccessServiceHost = new ServiceHost(typeof(ViewAccessWs), viewAccessUri);

                // Add Endpoint to Host
                adminAccessServiceHost.AddServiceEndpoint(typeof(AdminAccessWs), new WSHttpBinding(), "");
                viewAccessServiceHost.AddServiceEndpoint(typeof(ViewAccessWs), new WSHttpBinding(), "");

                // Metadata Exchange
                var serviceBehavior = new ServiceMetadataBehavior { HttpGetEnabled = true };
                adminAccessServiceHost.Description.Behaviors.Add(serviceBehavior);
                viewAccessServiceHost.Description.Behaviors.Add(serviceBehavior);

                // Open
                adminAccessServiceHost.Open();
                Console.WriteLine($"Service is live now at: {adminAccessUri}");
                viewAccessServiceHost.Open();
                Console.WriteLine($"Service is live now at: {viewAccessUri}");

                Console.WriteLine("Press any key to exit the application...");
            }
            catch (Exception ex)
            {
                adminAccessServiceHost?.Abort();
                adminAccessServiceHost = null;
                viewAccessServiceHost?.Abort();
                viewAccessServiceHost = null;
                Console.WriteLine($"There is an issue with AdminAccessBll: {ex.Message}");
            }
            Console.ReadLine();
            adminAccessServiceHost?.Close();
            viewAccessServiceHost?.Close();
        }
    }
}
