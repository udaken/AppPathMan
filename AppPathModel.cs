using System;
using System.Linq;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.InteropServices;
using Microsoft.Win32;
using Microsoft.Win32.SafeHandles;

namespace AppPathMan
{
    public class AppPathModel : INotifyPropertyChanged
    {
        bool _IsSystem = false;
        static readonly PropertyChangedEventArgs _IsSystemPropertyChangedArgs = new PropertyChangedEventArgs(nameof(IsSystem));

        public event PropertyChangedEventHandler PropertyChanged;

        public event EventHandler<AppPathKeyNotFoundEventArgs> AppPathKeyNotFoundEvent;

        public AppPathModel(EventHandler<AppPathKeyNotFoundEventArgs> appPathKeyNotFoundEvent = null)
        {
            AppPathKeyNotFoundEvent = appPathKeyNotFoundEvent;
            CopyTo(Load(), List);
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
                    PropertyChanged?.Invoke(this, _IsEditablePropertyChangedArgs);
                    PropertyChanged?.Invoke(this, _ReadOnlyPropertyChangedArgs);

                    List.Clear();
                    CopyTo(Load(), List);
                }
            }
        }
        public string RootKeyName => IsSystem ? "HKLM" : "HKCU";

        public BindingList<AppPathInfo> List { get; } = new BindingList<AppPathInfo>();

        public List<AppPathInfo> Load()
        {
            var rootKey = IsSystem ? Registry.LocalMachine : Registry.CurrentUser;

            RegistryKey appPathKey;
            using (appPathKey = rootKey.OpenSubKey(AppPathInfo.AppPathKeyName))
            {
                if (appPathKey == null)
                {
                    var e = new AppPathKeyNotFoundEventArgs(rootKey.Name + @"\" + AppPathInfo.AppPathKeyName) { };
                    AppPathKeyNotFoundEvent?.Invoke(this, e);

                    if (e.DoCreateKey)
                        appPathKey = rootKey.CreateSubKey(AppPathInfo.AppPathKeyName);
                }

                var list = new List<AppPathInfo>();
                foreach (var name in appPathKey.GetSubKeyNames())
                {
                    using var key = appPathKey.OpenSubKey(name);
                    list.Add(AppPathInfo.FromReg(IsSystem, key, name));
                }

                return list;
            }
        }

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
        public void Delete(int index)
        {
            var item = List[index];
            item.Delete();
            List.RemoveAt(index);
        }

        static readonly System.Security.Principal.WindowsPrincipal _Principal = new System.Security.Principal.WindowsPrincipal(System.Security.Principal.WindowsIdentity.GetCurrent());
        public bool IsEditable => IsSystem ? _Principal.IsInRole(System.Security.Principal.WindowsBuiltInRole.Administrator) : true;
        static readonly PropertyChangedEventArgs _IsEditablePropertyChangedArgs = new PropertyChangedEventArgs(nameof(IsEditable));
        
        public bool ReadOnly => !IsEditable;
        static readonly PropertyChangedEventArgs _ReadOnlyPropertyChangedArgs = new PropertyChangedEventArgs(nameof(ReadOnly));

    }
    static class NativeMethods
    {
        [DllImport("advapi32", CharSet = CharSet.Unicode)]
        public static extern int RegRenameKey(SafeRegistryHandle hKey, string oldname, string newname);
    }

    public class AppPathKeyNotFoundEventArgs
    {
        internal AppPathKeyNotFoundEventArgs(string keyName) => KeyName = keyName;
        public string KeyName
        {
            get;
        }
        public bool DoCreateKey
        {
            get; set;
        }
    }
}
