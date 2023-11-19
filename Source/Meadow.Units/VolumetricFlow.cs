using System;
using System.ComponentModel;
using System.Diagnostics.Contracts;
using System.Runtime.InteropServices;
using Meadow.Units.Conversions;

namespace Meadow.Units
{
    [Serializable]
    [ImmutableObject(true)]
    [StructLayout(LayoutKind.Sequential)]
    public struct VolumetricFlow :
        IComparable, IFormattable, IConvertible,
        IEquatable<double>, IComparable<double>
    {
        public VolumetricFlow(double value, UnitType type = UnitType.CubicMetersPerSecond)
        {
            Value = VolumetricFlowConversions.Convert(value, type, UnitType.CubicMetersPerSecond);
        }

        public VolumetricFlow(VolumetricFlow volumetricFlow)
        {
            Value = volumetricFlow.Value;
        }

        private readonly double Value;

        public enum UnitType
        {
            CubicCentimetersPerHour,
            CubicCentimetersPerMinute,
            CubicCentimetersPerSecond,
            CubicMetersPerHour,
            CubicMetersPerMinute,
            CubicMetersPerSecond,
            GallonsPerHour,
            GallonsPerMinute,
            GallonsPerSecond,
            LitersPerHour,
            LitersPerMinute,
            LitersPerSecond,
            MillilitersPerHour,
            MillilitersPerMinute,
            MillilitersPerSecond
        }

        // Fill out public properties for each unit type here   
        public double CubicCentimetersPerHour => From(UnitType.CubicCentimetersPerHour);
        public double CubicCentimetersPerMinute => From(UnitType.CubicCentimetersPerMinute);
        public double CubicCentimetersPerSecond => From(UnitType.CubicCentimetersPerSecond);
        public double CubicMetersPerHour => From(UnitType.CubicMetersPerHour);
        public double CubicMetersPerMinute => From(UnitType.CubicMetersPerMinute);
        public double CubicMetersPerSecond => From(UnitType.CubicMetersPerSecond);
        public double GallonsPerHour => From(UnitType.GallonsPerHour);
        public double GallonsPerMinute => From(UnitType.GallonsPerMinute);
        public double GallonsPerSecond => From(UnitType.GallonsPerSecond);
        public double LitersPerHour => From(UnitType.LitersPerHour);
        public double LitersPerMinute => From(UnitType.LitersPerMinute);
        public double LitersPerSecond => From(UnitType.LitersPerSecond);
        public double MillilitersPerHour => From(UnitType.MillilitersPerHour);
        public double MillilitersPerMinute => From(UnitType.MillilitersPerMinute);
        public double MillilitersPerSecond => From(UnitType.MillilitersPerSecond);

        [Pure] public double From(UnitType convertTo)
        {
            return VolumetricFlowConversions.Convert(Value, UnitType.CubicMetersPerSecond, convertTo);
        }

        [Pure] public override bool Equals(object obj)
        {
            if (obj is null) { return false; }
            if (Equals(this, obj)) { return true; }
            return obj.GetType() == GetType() && Equals((VolumetricFlow)obj);
        }

        public override int GetHashCode() => Value.GetHashCode();

        [Pure] public bool Equals(VolumetricFlow other) => Value.Equals(other.Value);

        [Pure] public static bool operator ==(VolumetricFlow left, VolumetricFlow right) => left.Equals(right);

        [Pure] public static bool operator !=(VolumetricFlow left, VolumetricFlow right) => !left.Equals(right);

        [Pure] public int CompareTo(VolumetricFlow other) => Value.Equals(other.Value) ? 0 : Value.CompareTo(other.Value);

        [Pure] public static bool operator <(VolumetricFlow left, VolumetricFlow right) => left.CompareTo(right) < 0;

        [Pure] public static bool operator <=(VolumetricFlow left, VolumetricFlow right) => left.CompareTo(right) <= 0;

        [Pure] public static bool operator >(VolumetricFlow left, VolumetricFlow right) => left.CompareTo(right) > 0;

        [Pure] public static bool operator >=(VolumetricFlow left, VolumetricFlow right) => left.CompareTo(right) >= 0;

        [Pure] public static VolumetricFlow operator +(VolumetricFlow left, VolumetricFlow right) => new (left.Value + right.Value);

        [Pure] public static VolumetricFlow operator -(VolumetricFlow left, VolumetricFlow right) => new (left.Value - right.Value);

        [Pure] public static VolumetricFlow operator *(VolumetricFlow value, double operand) => new (value.Value * operand);

        [Pure] public static VolumetricFlow operator /(VolumetricFlow value, double operand) => new (value.Value / operand);

        [Pure] public VolumetricFlow Abs() => new (Math.Abs(Value));

        [Pure] public override string ToString() => Value.ToString();

        [Pure] public string ToString(string format, IFormatProvider formatProvider) => Value.ToString(format, formatProvider);

        [Pure] public int CompareTo(object obj) => Value.CompareTo(obj);

        [Pure] public TypeCode GetTypeCode() => Value.GetTypeCode();

        [Pure] public bool ToBoolean(IFormatProvider provider) => ((IConvertible)Value).ToBoolean(provider);

        [Pure] public byte ToByte(IFormatProvider provider) => ((IConvertible)Value).ToByte(provider);

        [Pure] public char ToChar(IFormatProvider provider) => ((IConvertible)Value).ToChar(provider);

        [Pure] public DateTime ToDateTime(IFormatProvider provider) => ((IConvertible)Value).ToDateTime(provider);

        [Pure] public decimal ToDecimal(IFormatProvider provider) => ((IConvertible)Value).ToDecimal(provider);

        [Pure] public double ToDouble(IFormatProvider provider) => ((IConvertible)Value).ToDouble(provider);

        [Pure] public short ToInt16(IFormatProvider provider) => ((IConvertible)Value).ToInt16(provider);

        [Pure] public int ToInt32(IFormatProvider provider) => ((IConvertible)Value).ToInt32(provider);

        [Pure] public long ToInt64(IFormatProvider provider) => ((IConvertible)Value).ToInt64(provider);

        [Pure] public sbyte ToSByte(IFormatProvider provider) => ((IConvertible)Value).ToSByte(provider);

        [Pure] public float ToSingle(IFormatProvider provider) => ((IConvertible)Value).ToSingle(provider);

        [Pure] public string ToString(IFormatProvider provider) => ((IConvertible)Value).ToString(provider);

        [Pure] public object ToType(Type conversionType, IFormatProvider provider) => ((IConvertible)Value).ToType(conversionType, provider);

        [Pure] public ushort ToUInt16(IFormatProvider provider) => ((IConvertible)Value).ToUInt16(provider);

        [Pure] public uint ToUInt32(IFormatProvider provider) => ((IConvertible)Value).ToUInt32(provider);

        [Pure] public ulong ToUInt64(IFormatProvider provider) => ((IConvertible)Value).ToUInt64(provider);

        [Pure] public int CompareTo(double? other) => (other is null) ? -1 : Value.CompareTo(other.Value);

        [Pure] public bool Equals(double other) => Value.Equals(other);

        [Pure] public int CompareTo(double other) => Value.CompareTo(other);
    }
}