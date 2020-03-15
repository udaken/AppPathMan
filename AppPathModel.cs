using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.InteropServices;
using Microsoft.Win32.SafeHandles;

namespace AppPathMan
{
    public class AppPathModel : INotifyPropertyChanged
    {
        bool _IsSystem = false;
        static readonly PropertyChangedEventArgs _IsSystemPropertyChangedArgs = new PropertyChangedEventArgs(nameof(IsSystem));

        public event PropertyChangedEventHandler PropertyChanged;

        public AppPathModel()
        {
            CopyTo(AppPathInfo.Load(IsSystem), List);
        }

        public bool IsSystem
        {
            get => _IsSystem;
            set
            {
                if (_IsSystem != value)
                {
                    _IsSystem = value;
                    PropertyChanged?.Invoke(this, _IsSystemPropertyChangedArgs);

                    List.Clear();
                    CopyTo(AppPathInfo.Load(IsSystem), List);
                }
            }
        }
        public string RootKeyName => IsSystem ? "HKLM" : "HKCU";

        public BindingList<AppPathInfo> List { get; } = new BindingList<AppPathInfo>();

        static void CopyTo<T>(IEnumerable<T> source, IList<T> dest)
        {
            foreach (var item in source)
            {
                dest.Add(item);
            }
        }

        public string Export(string filename)
        {
            var startInfo = new ProcessStartInfo(Environment.ExpandEnvironmentVariables(@"%WINDIR%\system32\reg.exe"))
            {
                Arguments = $"EXPORT \"{ RootKeyName + @"\" + AppPathInfo.AppPathKeyName}\" \"{filename}\" /y",
                CreateNoWindow = true,
                ErrorDialog = true,
                UseShellExecute = false,
                RedirectStandardError = true,
            };
            using var process = new Process()
            {
                StartInfo = startInfo,
            };
            process.Start();
            process.WaitForExit();

            return process.ExitCode != 0 ? process.StandardError.ReadToEnd() : null;
        }
        public void Remove(int index)
        {
            var item = List[index];
            item.Delete();
            List.RemoveAt(index);
        }
        public bool IsEditable
        {
            get
            {
                if (IsSystem)
                {
                    var identity = System.Security.Principal.WindowsIdentity.GetCurrent();
                    var principal = new System.Security.Principal.WindowsPrincipal(identity);
                    return principal.IsInRole(System.Security.Principal.WindowsBuiltInRole.Administrator);
                }
                else
                    return true;
            }
        }
        public bool ReadOnly => !IsEditable;

    }
    static class NativeMethods
    {
        [DllImport("advapi32", CharSet = CharSet.Unicode)]
        public static extern int RegRenameKey(SafeRegistryHandle hKey, string oldname, string newname);
    }
}
