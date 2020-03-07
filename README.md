[![Build Status](https://dev.azure.com/davidhodel6/DaHo.MyStrom/_apis/build/status/Davee02.DaHo.MyStrom?branchName=master)](https://dev.azure.com/davidhodel6/DaHo.MyStrom/_build/latest?definitionId=2&branchName=master) ![Nuget version](https://img.shields.io/nuget/v/DaHo.MyStrom) ![Nuget downloads](https://img.shields.io/nuget/dt/DaHo.MyStrom) ![GitHub](https://img.shields.io/github/license/Davee02/DaHo.MyStrom)

# DaHo.MyStrom

Inofficial MyStrom REST API C# implementation. All supported endpoint can be found on [their API description-page](https://api.mystrom.ch/).

The following MyStrom devices are supported:

- Switch v1 & v2
- Bulb
- Button & Button+
- LED strip

This library is not official, developed, supported or endorsed by MyStrom AG. For questions and other inquiries, please use the issue tracker in this repo.


## Installation

Install DaHo.MyStrom via NuGet package manager

```powershell
Install-Package DaHo.MyStrom
```

## Example Usages

All API calls can be made synchronously or asynchronously. Asynchronous calls are suffixed with `Async` (i.e. `GetInfo() → GetInfoAsync()`) and return a Task. So in order to access the result, you need to `await` the call.

### Discover Devices in the same network

```csharp
var cts = new CancellationTokenSource();
cts.CancelAfter(TimeSpan.FromSeconds(5));
IMyStromDeviceDetector detector = new MyStromDeviceDetector(cts.Token);

await detector.GetLocalMyStromDevices(device => Console.WriteLine($"{device.IpAddress}: {device.DeviceType}") );
```

### Turn Switch on

```csharp
IMyStromSwitchApi switchApi = new MyStromSwitchApi("http://192.168.1.101");
await switchApi.SetSwitchPowerStateAsync(SwitchPowerState.On);
```

### Get Switch temperature

```csharp
IMyStromSwitchApi switchApi = new MyStromSwitchApi("http://192.168.1.101");
TemperatureMeasurement temp = await switchApi.GetTemperatureAsync();
Console.WriteLine($"Temp.: {temp.Compensated}");
```

### Set Bulb color to red

```csharp
IMyStromBulbApi bulbApi = new MyStromBulbApi("http://192.168.1.130");
GeneralInfo info = await bulbApi.GetGeneralInfoAsync();
BulbResponse colorResponse = await bulbApi.SetColorAsync(info.MacAddress, new BulbColorParameters
{
    ColorMode = BulbColorMode.Wrgb,
    Color = "00FF0000",
    Notifyurl = "",
    PowerMode = PowerMode.On,
    TransitionTime = 50
});
```

### Get Bulb color

```csharp
IMyStromBulbApi bulbApi = new MyStromBulbApi("http://192.168.1.130");
BulbColorSettings colorSettings = await bulbApi.GetColorSettingsAsync();
Console.WriteLine($"Color mode: ${colorSettings.ColorMode}; Color in WRGB: ${colorSettings.Wrgb}");
```

### Set LED strip light effect #3

```csharp
IMyStromLedStripApi ledStripApi = new MyStromLedStripApi("http://192.168.1.130");
await ledStripApi.SetLightEffectAsync(3, new List<LightEffect>
{
    new LightEffect
    {
        Color = "FF000000",
        EffectTime = 2,
        TransitionTime = 10
    },
    new LightEffect
    {
        Color = "00FF0000",
        EffectTime = 2,
        TransitionTime = 10
    }
});
```

### Set Button action for interaction type `single`

```csharp
IMyStromButtonApi buttonApi = new MyStromButtonApi("http://192.168.1.130");
await buttonApi.SetButtonActionsAsync(ButtonActionType.Single, new List<ButtonAction>
{
    ButtonAction.FromString("post://192.168.1.42:9000?key1=value1&key2=value2"),
    new ButtonAction
    {
        RequestType = ButtonRequestType.Put,
        RequestAddress = "192.168.1.50",
        RequestPort = 5000,
        RequestData = "key1=value2&key2=value1"
    }
});
```

## License

DaHo.MyStrom is licensed under MIT, for more details check LICENSE.
