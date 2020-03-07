using DaHo.MyStrom.Models;
using System;
using System.Threading.Tasks;

namespace DaHo.MyStrom.Abstractions
{
    public interface IMyStromDeviceDetector
    {
        Task GetLocalMyStromDevices(Action<MyStromDevice> onDeviceFound);
    }
}