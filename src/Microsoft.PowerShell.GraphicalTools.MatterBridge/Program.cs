// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Avalonia;
using Avalonia.Logging.Serilog;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;

//Used to run the module directly from Dotnet
namespace OutGridView.Application
{
    public class Program
    {
        // Initialization code. Don't use any Avalonia, third-party APIs or any
        // SynchronizationContext-reliant code before AppMain is called: things aren't initialized
        // yet and stuff might break.
        [STAThread]
        public static void Main(string[] args)
        {
        }
    }
}
