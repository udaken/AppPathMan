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
        static readonly PropertyChangedEventArgs _IsEditablePropertyChangedArgs = new PropertyChangedEventArgs(nameof(IsEditable));
        static readonly PropertyChangedEventArgs _IsSystemPropertyChangedArgs = new PropertyChangedEventArgs(nameof(IsSystem));
        static readonly System.Security.Principal.WindowsPrincipal _Principal = new System.Security.Principal.WindowsPrincipal(System.Security.Principal.WindowsIdentity.GetCurrent());
        static readonly PropertyChangedEventArgs _ReadOnlyPropertyChangedArgs = new PropertyChangedEventArgs(nameof(ReadOnly));
        bool _IsSystem = false;
        public AppPathModel(EventHandler<AppPathKeyNotFoundEventArgs>? appPathKeyNotFoundEvent = null)
        {
            AppPathKeyNotFoundEvent = appPathKeyNotFoundEvent;
            CopyTo(Load(), List);
        }

        public event EventHandler<AppPathKeyNotFoundEventArgs>? AppPathKeyNotFoundEvent;

        public event PropertyChangedEventHandler? PropertyChanged;
        public bool IsEditable => IsSystem ? _Principal.IsInRole(System.Security.Principal.WindowsBuiltInRole.Administrator) : true;

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
        public BindingList<AppPathInfo> List { get; } = new BindingList<AppPathInfo>();
        public bool ReadOnly => !IsEditable;
        public string RootKeyName => IsSystem ? "HKLM" : "HKCU";
        public void Delete(int index)
        {
            var item = List[index];
            item.Delete();
            List.RemoveAt(index);
        }

        public string? Export(string filename, IntPtr errorDialogParentHandle)
        {
            var startInfo = new ProcessStartInfo(Environment.ExpandEnvironmentVariables(@"%WINDIR%\system32\reg.exe"))
            {
                Arguments = $"EXPORT \"{ RootKeyName + @"\" + AppPathInfo.AppPathKeyName}\" \"{filename}\" /y",
                CreateNoWindow = true,
                ErrorDialog = true,
                ErrorDialogParentHandle = errorDialogParentHandle,
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

        private List<AppPathInfo> Load()
        {
            var rootKey = IsSystem ? Registry.LocalMachine : Registry.CurrentUser;

            RegistryKey appPathKey;
            using (appPathKey = rootKey.OpenSubKey(AppPathInfo.AppPathKeyName))
            {
                if (appPathKey == null)
                {
                    var e = new AppPathKeyNotFoundEventArgs(rootKey.Name + @"\" + AppPathInfo.AppPathKeyName);
                    AppPathKeyNotFoundEvent?.Invoke(this, e);

                    if (e.DoCreateKey)
                        appPathKey = rootKey.CreateSubKey(AppPathInfo.AppPathKeyName);
                }

                if (appPathKey == null)
                    throw new InvalidOperationException();

                return appPathKey.GetSubKeyNames().Select(name =>
                {
                    using var key = appPathKey.OpenSubKey(name);
                    return AppPathInfo.FromReg(IsSystem, key, name);
                }).ToList();
            }
        }

        static void CopyTo<T>(IEnumerable<T> source, IList<T> dest)
        {
            foreach (var item in source)
            {
                dest.Add(item);
            }
        }
    }
    static class NativeMethods
    {
        [DllImport("advapi32", CharSet = CharSet.Unicode)]
        public static extern int RegRenameKey(SafeRegistryHandle hKey, string oldname, string newname);
    }
    public class AppPathKeyNotFoundEventArgs
    {
        internal AppPathKeyNotFoundEventArgs(string keyName) => KeyName = keyName;
        public bool DoCreateKey
        {
            get;
            set;
        }

        public string KeyName
        {
            get;
        }
    }

}
