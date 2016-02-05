using System;
using GrovePi;
using Windows.ApplicationModel.Background;

namespace Driver
{
    public sealed class SimpleDriver : IBackgroundTask
    {
        private readonly IBuildGroveDevices _deviceFactory = DeviceFactory.Build;

        public void Run(IBackgroundTaskInstance taskInstance)
        {
            SixAxisAccelerometerAndCompassDemo.Run(_deviceFactory);
        }
    }
}