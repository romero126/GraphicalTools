
// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Management.Automation;
using System.Reflection;
using System.Runtime.InteropServices;

namespace Microsoft.PowerShell.GraphicalTools {

    public class MatterBridge {
        private Process _process;

        public event DataReceivedEventHandler OutputDataReceived {
            add {
                _process.OutputDataReceived += value;
            }
            remove {
                _process.OutputDataReceived -= value;
            }
        }
        public event DataReceivedEventHandler ErrorDataReceived {
            add {
                _process.ErrorDataReceived += value;
            }
            remove {
                _process.ErrorDataReceived -= value;
            }
        }
        //public ZipFileItemInfo(ZipArchiveEntry item, ZipFilePSDriveInfo drive)
        public MatterBridge(string item)
        {
            Console.WriteLine("MatterBridge!!");
        }
        public MatterBridge() 
        {
            _process = new Process();
            _process.StartInfo.FileName = GetMatterBridgeApplicationLocation();

            Console.WriteLine(_process.StartInfo.FileName);
            _process.StartInfo.CreateNoWindow = true;
            _process.StartInfo.UseShellExecute = false;

            _process.StartInfo.RedirectStandardInput = true;
            _process.StartInfo.RedirectStandardOutput = true;
            _process.StartInfo.RedirectStandardError = true;

            _process.ErrorDataReceived += (sender, data) =>
            {
                Console.WriteLine(data.Data);
            };
            _process.OutputDataReceived += (sender, data) =>
            {
                Console.WriteLine(data.Data);
            };

            // Start but not care about bridge yet
            _process.Start();
        }


        public void Call(string command)
        {
            _process.StandardInput.WriteLine(command);
        }
        public bool CanRead()
        {
            return true;
        }
        public object Receive()
        {
            return null;
        }

        public void WaitForExit()
        {
            _process.WaitForExit();
        }

        public void CloseProcess()
        {
            _process.Close();
        }
        public bool IsClosed()
        {
            if (_process == null || _process.HasExited)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public string GetMatterBridgeApplicationLocation()
        {
            string osRid;
            string executableName;
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            {
                osRid = "win-x64";
                executableName = "Microsoft.PowerShell.GraphicalTools.MatterBridge.Gui.exe";
            }
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
            {
                osRid = "osx-x64";
                executableName = "Microsoft.PowerShell.GraphicalTools.MatterBridge.Gui";
            }
            else
            {
                osRid = "linux-x64";
                executableName = "Microsoft.PowerShell.GraphicalTools.MatterBridge.Gui";
            }

            return Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "MatterBridge", osRid, executableName);
        }
    }

}