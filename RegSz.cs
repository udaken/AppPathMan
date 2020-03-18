using System;

namespace AppPathMan
{
    public struct RegSz : IEquatable<RegSz>
    {
        public RegSz(string value, bool isExpandString = false)
        {
            Value = value;
            IsExpandString = isExpandString;
        }

        public bool IsExpandString
        {
            get;
        }

        public string? Value
        {
            get;
        }

        public override bool Equals(object? obj) => obj is RegSz sz && Equals(sz);

        public bool Equals(RegSz other) => IsExpandString == other.IsExpandString && Value == other.Value;

        public string ExpandedString => Value != null ? Environment.ExpandEnvironmentVariables(Value) : "";

        public override int GetHashCode() => HashCode.Combine(IsExpandString, Value);

        public static explicit operator string?(RegSz self) => self.Value;
        //public static explicit operator RegSz(string str) => new RegSz(str);
        public static implicit operator RegSz(string str) => new RegSz(str, str.Contains("%"));

        public static bool operator ==(RegSz left, RegSz right) => left.Equals(right);

        public static bool operator !=(RegSz left, RegSz right) => !(left == right);

        public override string ToString() => Value ?? "";
    }
}
