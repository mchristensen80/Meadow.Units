using System.Globalization;
using Xunit;

namespace Meadow.Units.Tests;

public class VolumetricFlowTests
{
    [Fact()]
    public void VolumetricFlowCtors()
    {
        VolumetricFlow v = new(100, VolumetricFlow.UnitType.CubicMetersPerSecond);
        Assert.True(v.CubicMetersPerSecond == 100);

        VolumetricFlow v2 = new();
        Assert.True(v2.CubicMetersPerHour == 0);

        VolumetricFlow v3 = new(150, VolumetricFlow.UnitType.CubicMetersPerSecond);
        Assert.True(v3.CubicMetersPerSecond == 150);

        VolumetricFlow v4 = new(100, VolumetricFlow.UnitType.LitersPerSecond);
        Assert.True(v4.LitersPerSecond == 100);

        VolumetricFlow v5 = new(100);
        Assert.True(v5.CubicMetersPerSecond == 100);
    }

    [Fact()]
    public void VolumetricFlowConversions_UnitsPerHour()
    {
        VolumetricFlow v = new(100, VolumetricFlow.UnitType.CubicMetersPerHour);
        Assert.True(v.CubicCentimetersPerHour.Equals3DigitPrecision(100000000));
        Assert.True(v.CubicMetersPerHour.Equals3DigitPrecision(100));
        Assert.True(v.GallonsPerHour.Equals3DigitPrecision(26417.205235816));
        Assert.True(v.LitersPerHour.Equals3DigitPrecision(100000));
        Assert.True(v.MillilitersPerHour.Equals3DigitPrecision(100000000));
    }

    [Fact()]
    public void VolumetricFlowConversions_UnitsPerMinute()
    {
        VolumetricFlow v = new(100, VolumetricFlow.UnitType.CubicMetersPerMinute);
        Assert.True(v.CubicCentimetersPerMinute.Equals3DigitPrecision(100000000));
        Assert.True(v.CubicMetersPerMinute.Equals3DigitPrecision(100));
        Assert.True(v.GallonsPerMinute.Equals3DigitPrecision(26417.205235815));
        Assert.True(v.LitersPerMinute.Equals3DigitPrecision(100000));
        Assert.True(v.MillilitersPerMinute.Equals3DigitPrecision(100000000));
    }

    [Fact()]
    public void VolumetricFlowConversions_UnitsPerSecond()
    {
        VolumetricFlow v = new(100, VolumetricFlow.UnitType.CubicMetersPerSecond);
        Assert.True(v.CubicCentimetersPerSecond.Equals3DigitPrecision(100000000));
        Assert.True(v.CubicMetersPerSecond.Equals3DigitPrecision(100));
        Assert.True(v.GallonsPerSecond.Equals3DigitPrecision(26417.2052));
        Assert.True(v.LitersPerSecond.Equals3DigitPrecision(100000));
        Assert.True(v.MillilitersPerSecond.Equals3DigitPrecision(100000000));
    }

    [Fact()]
    public void VolumetricFlow_Comparisons()
    {
        VolumetricFlow v1 = new(100, VolumetricFlow.UnitType.CubicMetersPerSecond);
        VolumetricFlow v2 = new(1000, VolumetricFlow.UnitType.CubicMetersPerSecond);

        Assert.True(v1 < v2);
        Assert.True(v1 <= v2);
        Assert.True(v2 > v1);
        Assert.True(v2 >= v1);
        Assert.True(v1 != v2);
        Assert.True(v1 == new VolumetricFlow(100));
    }

    [Fact()]
    public void VolumetricFlow_Equality()
    {
        VolumetricFlow v1 = new(100, VolumetricFlow.UnitType.CubicMetersPerSecond);
        VolumetricFlow v2 = new(100, VolumetricFlow.UnitType.CubicMetersPerSecond);

        Assert.True(v1.Equals(v2));
        Assert.True(v1.Equals(100));
        Assert.False(v1.Equals(null));
    }

    [Fact()]
    public void VolumetricFlow_MathOperations()
    {
        VolumetricFlow v1 = new(200, VolumetricFlow.UnitType.CubicMetersPerSecond);
        VolumetricFlow v2 = new(100, VolumetricFlow.UnitType.CubicMetersPerSecond);
        VolumetricFlow v3 = new(-10.10, VolumetricFlow.UnitType.CubicMetersPerSecond);

        var result1 = v1 + v2;
        Assert.True(result1.Equals(300));
        var result2 = v1 - v2;
        Assert.True(result2.Equals(100));
        var result3 = v1 * 100f;
        Assert.True(result3.Equals(20000));
        var result4 = v1 / 2f;
        Assert.True(result4.Equals(100));
        var result5 = v3.Abs();
        Assert.True(result5.Equals(10.10));
        var result6 = v1.ToString();
        Assert.True(result6 == "200");
        var result7 = v1.ToString(CultureInfo.InvariantCulture);
        Assert.True(result7 == "200");
    }

    [Fact()]
    public void VolumetricFlow_CompareTo()
    {
        VolumetricFlow v1 = new(200, VolumetricFlow.UnitType.CubicMetersPerSecond);

        const int isSmaller = -1;
        const int isEqual = 0;
        const int isLarger = 1;
  
        var result1 = v1.CompareTo(new VolumetricFlow(100));
        Assert.True(result1 == isLarger);
        var result2 = v1.CompareTo(new VolumetricFlow(200));
        Assert.True(result2 == isEqual);
        var result3 = v1.CompareTo(new VolumetricFlow(300));
        Assert.True(result3 == isSmaller);
        var result4 = v1.CompareTo(null);
        Assert.True(result4 == isSmaller);
        var result5 = v1.CompareTo(200);
        Assert.True(result5 == isEqual);
    }
}