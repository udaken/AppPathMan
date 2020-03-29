using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using Microsoft.Win32;

namespace AppPathMan
{
    public class AppPathInfo : INotifyPropertyChanged
    {
        public const string AppPathKeyName = @"SOFTWARE\Microsoft\Windows\CurrentVersion\App Paths";
        private const string DefaultValueName = "";

        string _Name;
        static readonly PropertyChangedEventArgs _NamePropertyChangedArgs = new PropertyChangedEventArgs(nameof(Name));
        RegSz _Value;
        static readonly PropertyChangedEventArgs _ValuePropertyChangedArgs = new PropertyChangedEventArgs(nameof(Value));
        RegSz _Path;
        static readonly PropertyChangedEventArgs _PathPropertyChangedArgs = new PropertyChangedEventArgs(nameof(Path));
        string? _DropTarget;
        static readonly PropertyChangedEventArgs _DropTargetPropertyChangedArgs = new PropertyChangedEventArgs(nameof(DropTarget));
        uint? _UseUrl;
        static readonly PropertyChangedEventArgs _UseUrlPropertyChangedArgs = new PropertyChangedEventArgs(nameof(UseUrl));
        uint? _DontUseDesktopChangeRouter;
        static readonly PropertyChangedEventArgs _DontUseDesktopChangeRouterPropertyChangedArgs = new PropertyChangedEventArgs(nameof(DontUseDesktopChangeRouter));

        bool _disposed = false;

        public event PropertyChangedEventHandler? PropertyChanged;

        AppPathInfo(bool isSystem, string name, RegSz value = default, RegSz path = default, uint? useUrl = null, string? dropTarget = default, uint? dontUseDesktopChangeRouter = default)
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
                if (_Name == value)
                {
                    return;
                }
                using var appPathKey = OpenRegKeyForWrite(AppPathKeyName);
                var err = NativeMethods.RegRenameKey(appPathKey.Handle, _Name, value);
                if (err != 0)
                    throw new Win32Exception(err);

                _Name = value;
                PropertyChanged?.Invoke(this, _NamePropertyChangedArgs);
            }
        }

        public RegSz Value
        {
            get => _Value;
            set
            {
                CheckDisposed();
                if (_Value == value)
                {
                    return;
                }
                UpdateValue(DefaultValueName, value);
                _Value = value;
                PropertyChanged?.Invoke(this, _ValuePropertyChangedArgs);
            }
        }

        public RegSz Path
        {
            get => _Path;
            set
            {
                CheckDisposed();
                if (_Path == value)
                {
                    return;
                }
                UpdateValue(nameof(Path), value);
                _Path = value;
                PropertyChanged?.Invoke(this, _PathPropertyChangedArgs);
            }
        }

        public string? DropTarget
        {
            get => _DropTarget;
            set
            {
                CheckDisposed();
                if (_DropTarget == value)
                {
                    return;
                }
                UpdateValue(nameof(DropTarget), value);
                _DropTarget = value;
                PropertyChanged?.Invoke(this, _DropTargetPropertyChangedArgs);
            }
        }

        public uint? UseUrl
        {
            get => _UseUrl;
            set
            {
                CheckDisposed();
                if (_UseUrl == value)
                {
                    return;
                }
                UpdateValue(nameof(UseUrl), value);
                _UseUrl = value;
                PropertyChanged?.Invoke(this, _UseUrlPropertyChangedArgs);
            }
        }

        public uint? DontUseDesktopChangeRouter
        {
            get => _DontUseDesktopChangeRouter;
            set
            {
                CheckDisposed();
                if (_DontUseDesktopChangeRouter == value)
                {
                    return;
                }
                UpdateValue(nameof(DontUseDesktopChangeRouter), value);
                _DontUseDesktopChangeRouter = value;
                PropertyChanged?.Invoke(this, _DontUseDesktopChangeRouterPropertyChangedArgs);
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

        void UpdateValueCore<T>(string name, T value, Func<T, (object? value, RegistryValueKind kind)> converter)
        {
            using var key = OpenRegKeyForWrite(AppPathKeyName + @"\" + Name);

            var converted = converter(value);
            if (converted.value is null)
            {
                if (ValueExist(key, name))
                    key.DeleteValue(name);
            }
            else
                key.SetValue(name, converted.value, converted.kind);
        }

        void UpdateValue(string name, RegSz value) => UpdateValueCore(name, value, v => (v.Value, v.IsExpandString ? RegistryValueKind.ExpandString : RegistryValueKind.String));

        void UpdateValue(string name, string? value) => UpdateValueCore(name, value, v => (v, RegistryValueKind.String));

        void UpdateValue<T>(string name, T? value) where T : struct => UpdateValueCore(name, value, v => (v ?? null, RegistryValueKind.Unknown));

        static T? TryConvertTo<T>(object value) where T : struct => value is T b ? b : (T?)null;

        static bool ValueExist(RegistryKey key, string name) => key.GetValueNames().Contains(name, StringComparer.InvariantCultureIgnoreCase);

        static RegSz GetRegSz(RegistryKey key, string name) => new RegSz(
            (string)key.GetValue(name, "", RegistryValueOptions.DoNotExpandEnvironmentNames),
            ValueExist(key, name) && key.GetValueKind(name) == RegistryValueKind.ExpandString);

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

        public static AppPathInfo FromReg(bool isSystem, RegistryKey key, string name)
        {
            var value = GetRegSz(key, DefaultValueName);
            if (value.Value is null)
                throw new KeyNotFoundException();

            return new AppPathInfo(isSystem, name, value,
                path: GetRegSz(key, nameof(Path)),
                useUrl: TryConvertTo<uint>(key.GetValue(nameof(UseUrl))),
                dropTarget: key.GetValue(nameof(DropTarget)) as string,
                dontUseDesktopChangeRouter: TryConvertTo<uint>(key.GetValue(nameof(DontUseDesktopChangeRouter))));
        }

    }
}
