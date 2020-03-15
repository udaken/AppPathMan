using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using Microsoft.Win32;

namespace AppPathMan
{
    public class AppPathInfo : INotifyPropertyChanged, IEquatable<AppPathInfo>
    {
        public const string AppPathKeyName = @"SOFTWARE\Microsoft\Windows\CurrentVersion\App Paths";
        private const string DefaultValueName = "";

        string _Name;
        static readonly PropertyChangedEventArgs _NamePropertyChangedArgs = new PropertyChangedEventArgs(nameof(Name));
        RegSz _Value;
        static readonly PropertyChangedEventArgs _ValuePropertyChangedArgs = new PropertyChangedEventArgs(nameof(Value));
        RegSz _Path;
        static readonly PropertyChangedEventArgs _PathPropertyChangedArgs = new PropertyChangedEventArgs(nameof(Path));
        string _DropTarget;
        static readonly PropertyChangedEventArgs _DropTargetPropertyChangedArgs = new PropertyChangedEventArgs(nameof(DropTarget));
        uint? _UseUrl;
        static readonly PropertyChangedEventArgs _UseUrlPropertyChangedArgs = new PropertyChangedEventArgs(nameof(UseUrl));
        uint? _DontUseDesktopChangeRouter;
        static readonly PropertyChangedEventArgs _DontUseDesktopChangeRouterPropertyChangedArgs = new PropertyChangedEventArgs(nameof(DontUseDesktopChangeRouter));

        bool _disposed = false;

        public event PropertyChangedEventHandler PropertyChanged;

        AppPathInfo(bool isSystem, string name, RegSz value = default, RegSz path = default, uint? useUrl = null, string dropTarget = default, uint? dontUseDesktopChangeRouter = default)
        {
            IsSystem = isSystem;
            _Name = name ?? throw new ArgumentNullException(nameof(name));
            _Value = value;
            _Path = path;
            _UseUrl = useUrl;
            _DropTarget = dropTarget;
            _DontUseDesktopChangeRouter = dontUseDesktopChangeRouter;

        }

        public bool IsSystem
        {
            get;
        }

        public string Name
        {
            get => _Name;
            set
            {
                CheckDisposed();
                if (_Name != value)
                {
                    using var appPathKey = OpenRegKeyForWrite(AppPathKeyName);
                    var err = NativeMethods.RegRenameKey(appPathKey.Handle, _Name, value);
                    if (err != 0)
                        throw new Win32Exception(err);

                    _Name = value;
                    PropertyChanged?.Invoke(this, _NamePropertyChangedArgs);
                }
            }
        }

        public RegSz Value
        {
            get => _Value;
            set
            {
                CheckDisposed();
                if (_Value != value)
                {
                    UpdateValue(DefaultValueName, value);
                    _Value = value;
                    PropertyChanged?.Invoke(this, _ValuePropertyChangedArgs);
                }
            }
        }

        public RegSz Path
        {
            get => _Path;
            set
            {
                CheckDisposed();
                if (_Path != value)
                {
                    UpdateValue(nameof(Path), value);
                    _Path = value;
                    PropertyChanged?.Invoke(this, _PathPropertyChangedArgs);
                }
            }
        }

        public string DropTarget
        {
            get => _DropTarget;
            set
            {
                CheckDisposed();
                if (_DropTarget != value)
                {
                    UpdateValue(nameof(DropTarget), value);
                    _DropTarget = value;
                    PropertyChanged?.Invoke(this, _DropTargetPropertyChangedArgs);
                }
            }
        }

        public uint? UseUrl
        {
            get => _UseUrl;
            set
            {
                CheckDisposed();
                if (_UseUrl != value)
                {
                    UpdateValue(nameof(UseUrl), value);
                    _UseUrl = value;
                    PropertyChanged?.Invoke(this, _UseUrlPropertyChangedArgs);
                }
            }
        }

        public uint? DontUseDesktopChangeRouter
        {
            get => _DontUseDesktopChangeRouter;
            set
            {
                CheckDisposed();
                if (_DontUseDesktopChangeRouter != value)
                {
                    UpdateValue(nameof(DontUseDesktopChangeRouter), value);
                    _DontUseDesktopChangeRouter = value;
                    PropertyChanged?.Invoke(this, _DontUseDesktopChangeRouterPropertyChangedArgs);
                }
            }
        }

        public void Delete()
        {
            CheckDisposed();
            using var appPathKey = OpenRegKeyForWrite(AppPathKeyName);
            appPathKey.DeleteSubKey(Name);
            _disposed = true;
        }

        void CheckDisposed()
        {
            if (_disposed)
                throw new ObjectDisposedException(Name);
        }


        RegistryKey OpenRegKeyForWrite(string name)
        {
            var rootKey = IsSystem ? Registry.LocalMachine : Registry.CurrentUser;
            return rootKey.OpenSubKey(name, true);
        }

        void UpdateValueCore<T>(string name, T value, Func<T, (object value, RegistryValueKind kind)> converter)
        {
            using var key = OpenRegKeyForWrite(AppPathKeyName + @"\" + Name);

            var tmp = converter(value);
            if (tmp.value == null)
            {
                if (ValueExist(key, name))
                    key.DeleteValue(name);
            }
            else
                key.SetValue(name, tmp.value, tmp.kind);
        }

        void UpdateValue(string name, RegSz value)
        {
            UpdateValueCore(name, value, v => (v.Value, v.IsExpandString ? RegistryValueKind.ExpandString : RegistryValueKind.String));
        }

        void UpdateValue(string name, string value)
        {
            UpdateValueCore(name, value, v => (v, RegistryValueKind.String));
        }

        void UpdateValue<T>(string name, T? value) where T : struct
        {
            UpdateValueCore(name, value, v => (v ?? null, RegistryValueKind.Unknown));
        }

        static T? TryConvertTo<T>(object value) where T : struct => value is T b ? b : (T?)null;

        static bool ValueExist(RegistryKey key, string name) => key.GetValueNames().Contains(name, StringComparer.InvariantCultureIgnoreCase);

        static RegSz GetRegSz(RegistryKey key, string name) => new RegSz(
            key.GetValue(name, "", RegistryValueOptions.DoNotExpandEnvironmentNames) as string,
            ValueExist(key, name) && key.GetValueKind(name) == RegistryValueKind.ExpandString);

        public static List<AppPathInfo> Load(bool isSystem)
        {
            var rootKey = isSystem ? Registry.LocalMachine : Registry.CurrentUser;
            using var appPathKey = rootKey.OpenSubKey(AppPathKeyName);

            var list = new List<AppPathInfo>();
            foreach (var name in appPathKey.GetSubKeyNames())
            {
                using var key = appPathKey.OpenSubKey(name);
                list.Add(FromReg(isSystem, key, name));
            }

            return list;
        }

        public static AppPathInfo Create(bool isSystem, string name, RegSz value = default, RegSz path = default, uint? useUrl = null)
        {
            var rootKey = isSystem ? Registry.LocalMachine : Registry.CurrentUser;
            using var appPathKey = rootKey.OpenSubKey(AppPathKeyName, true);
            using var key = appPathKey.CreateSubKey(name, true);
            var info = FromReg(isSystem, key, name);
            info.Value = value;
            info.Path = path;
            info.UseUrl = useUrl;
            return info;
        }

        static AppPathInfo FromReg(bool isSystem, RegistryKey key, string name)
        {
            var value = GetRegSz(key, DefaultValueName);
            if (value.Value == null)
                throw new KeyNotFoundException();

            return new AppPathInfo(isSystem, name, value,
                path: GetRegSz(key, nameof(Path)),
                useUrl: TryConvertTo<uint>(key.GetValue(nameof(UseUrl))),
                dropTarget: key.GetValue(nameof(DropTarget)) as string,
                dontUseDesktopChangeRouter: TryConvertTo<uint>(key.GetValue(nameof(DontUseDesktopChangeRouter))));
        }

        public bool Equals(AppPathInfo info)
            => IsSystem == info.IsSystem && Name == info.Name && Value.Equals(info.Value) && Path.Equals(info.Path) && DropTarget == info.DropTarget && UseUrl == info.UseUrl && DontUseDesktopChangeRouter == info.DontUseDesktopChangeRouter;
        
        public override bool Equals(object obj) => obj is AppPathInfo info && Equals(info);

        public override int GetHashCode()
            => HashCode.Combine(IsSystem, Name, Value, Path, DropTarget, UseUrl, DontUseDesktopChangeRouter);

        public static bool operator ==(AppPathInfo left, AppPathInfo right) => EqualityComparer<AppPathInfo>.Default.Equals(left, right);
        
        public static bool operator !=(AppPathInfo left, AppPathInfo right) => !(left == right);
    }
}
