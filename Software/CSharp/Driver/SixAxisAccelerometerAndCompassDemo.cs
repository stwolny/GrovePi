using System;
using System.Threading.Tasks;
using GrovePi;
using Config = GrovePi.I2CDevices.Configuration;

namespace Driver
{
    internal static class SixAxisAccelerometerAndCompassDemo
    {
        public static void Run(IBuildGroveDevices deviceFactory)
        {
            // create sensor and configure it with default values
            // configuration is shown for demonstration only as creating sensor already configures it with defaults
            var sensor = deviceFactory.SixAxisAccelerometerAndCompass().Configure(c =>
            {
                c.AccelerationAxes(Config.AccelerationAxes.XYZ);
                c.AccelerationDataRate(Config.AccelerationDataRate.Hz_50);
                c.AccelerationDataUpdateMode(Config.AccelerationDataUpdateMode.Continuous);
                c.AccelerationScale(Config.AccelerationScale.G_2);

                c.MagneticDataRate(Config.MagneticDataRate.Hz_50);
                c.MagneticMode(Config.MagneticMode.ContinousConversion);
                c.MagneticResolution(Config.MagneticResolution.Low);
                c.MagneticScale(Config.MagneticScale.Gs_4);
            });

            var reading = new double[3];
            var value = default(double);

            while (true)
            {
                System.Diagnostics.Debug.WriteLine($"{sensor.DeviceId()}");

                reading = sensor.GetAcceleration();

                System.Diagnostics.Debug.WriteLine($"acceleration: [{reading[0]:N3},{reading[1]:N3},{reading[2]:N3}]");

                Task.Delay(100).Wait();

                reading = sensor.GetMagnetic();

                System.Diagnostics.Debug.WriteLine($"magnetic: [{reading[0]:N3},{reading[1]:N3},{reading[2]:N3}]");

                Task.Delay(100).Wait();

                value = sensor.GetHeading();

                System.Diagnostics.Debug.WriteLine($"heading: [{value:N3}]");

                Task.Delay(100).Wait();

                value = sensor.GetTiltHeading();

                System.Diagnostics.Debug.WriteLine($"tilt heading: [{value:N3}]");

                Task.Delay(100).Wait();
            }
        }
    }
}