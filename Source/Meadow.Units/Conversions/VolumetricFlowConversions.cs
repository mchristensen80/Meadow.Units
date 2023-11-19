namespace Meadow.Units.Conversions
{
    internal static class VolumetricFlowConversions
    {
        public static double Convert(double value, VolumetricFlow.UnitType from, VolumetricFlow.UnitType to)
        {
            if (from == to)
            {
                return value;
            }
            return value * volumetricFlowConversions[(int)to] / volumetricFlowConversions[(int)from];
        }

        // must align to enum. base unit is CubicMetersPerSecond
        private static readonly double[] volumetricFlowConversions =
        {
            3600000000.0,//		cm3/h
            60000000.0,//		cm3/min
            1000000.0,//		cm3/s
            3600.0,//		    m3/h
            60.0,//		        m3/min
            1.0,//		        m3/s
            951019.38848936,//  gal/h
            15850.323141489,//  gal/min
            264.17205235815,//  gal/s
            3600000.0,//        l/h
            60000.0,//          l/min
            1000,//             l/s
            3600000000.0,//		ml/h
            60000000.0,//		ml/min
            1000000.0,//		ml/s
        };
    }
}