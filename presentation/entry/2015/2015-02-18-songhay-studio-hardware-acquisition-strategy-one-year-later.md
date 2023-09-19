---json
{
  "documentId": 0,
  "title": "Songhay Studio: Hardware Acquisition Strategy, One Year Later",
  "documentShortName": "2015-02-18-songhay-studio-hardware-acquisition-strategy-one-year-later",
  "fileName": "index.html",
  "path": "./entry/2015-02-18-songhay-studio-hardware-acquisition-strategy-one-year-later",
  "date": "2015-02-18T08:00:00Z",
  "modificationDate": "2015-02-18T08:00:00Z",
  "templateId": 0,
  "segmentId": 0,
  "isRoot": false,
  "isActive": true,
  "sortOrdinal": 0,
  "clientId": "2015-02-18-songhay-studio-hardware-acquisition-strategy-one-year-later",
  "tag": "{\r\n  \"extract\": \"Almost exactly one year ago, in a typical Blog entry, I committed to continuing my hardware journey by getting a graphics card that supports at least two monitors, another Ergotron LX monitor arm and a decent-but-inexpensive monitor.Last night I installe...\"\r\n}"
}
---

# Songhay Studio: Hardware Acquisition Strategy, One Year Later

[<img alt="XFX Double D R9 290X 1000MHz 4GB DDR5 DP HDMI 2XDVI Graphics Card" src="https://farm8.staticflickr.com/7420/15950559094_020867dfe2_m_d.jpg">](http://www.amazon.com/XFX-Double-1000MHz-Graphics-R9290XEDFD/dp/B00HHIPN5A%3FSubscriptionId%3D1SW6D7X6ZXXR92KVX0G2%26tag%3Dthekintespacec00%26linkCode%3Dxm2%26camp%3D2025%26creative%3D165953%26creativeASIN%3DB00HHIPN5A "XFX Double D R9 290X 1000MHz 4GB DDR5 DP HDMI 2XDVI Graphics Card")

Almost exactly one year ago, in [a typical Blog entry](http://songhayblog.azurewebsites.net/Entry/Show/songhay-studio-hardware-acquisition-strategy), I committed to continuing my hardware journey by getting a graphics card that supports at least two monitors, another Ergotron LX monitor arm and a decent-but-inexpensive monitor.

Last night I installed a [XFX Double D R9 290X 1000MHz 4GB DDR5 DP HDMI 2XDVI Graphics Card](http://www.amazon.com/XFX-Double-1000MHz-Graphics-R9290XEDFD/dp/B00HHIPN5A%3FSubscriptionId=1SW6D7X6ZXXR92KVX0G2&tag=thekintespacec00&linkCode=xm2&camp=2025&creative=165953&creativeASIN=B00HHIPN5A), taken from the [PC Perspective Leaderboard](http://www.pcper.com/hwlb). Soon after Windows 8.1 rebooting with [this entry](http://answers.microsoft.com/en-us/windows/forum/windows_8-hardware/event-id-20-whea-logger-amd-northbridge/b69d3256-05a9-4aa7-b7ef-f0ed662c0f6f) in the Event Log:

```console
Event ID 20 - WHEA-Logger
A fatal hardware error has occurred.
Component: AMD Northbridge
Error Source: Machine Check Exception
Error Type: HyperTransport Watchdog Timeout Error
Processor APIC ID: 0
```

This error started while running a “modern” (“metro”) Windows app. This morning I’ve been burning in the card on the standard Windows Desktop for over an hour with no rebooting (and the temperature under 42°C).

<span style="text-decoration:line-through;">I suspect that the AMD Radeon drivers are </span><span style="text-decoration:line-through;">*seriously*</span><span style="text-decoration:line-through;"> incompatible with “modern” Windows 8</span>—which may explain why so many serious PC enthusiasts hate any version Windows after Windows 7. I ran Windows Update a few times thinking that Microsoft has a ‘better,’ more stable video driver than the manufacturer. This thinking is probably behind the times…

## Update: 1:43 PM

I suspect that the issue is related to simple overheating. First of all the system rebooted in error within 30 minutes in the Windows Desktop (while streaming video was playing)—which throws out my “metro” theory. Secondly, the system ran without rebooting for at least an hour in the Windows Desktop (while streaming video was playing) while under-clocked and **Enable manual fan control** was enabled and turned up (to very noisy levels) in [AMD OverDrive](http://www.amd.com/en-us/markets/game/downloads/overdrive).

So the message I’m hearing now is <span style="text-decoration:line-through;">my default cooling (here in California) is not “good” enough—or the default XFX settings for AMD OverDrive are too aggressive</span>.

## Update: 8:28 PM

I returned the [XFX Double D R9 290X 1000MHz 4GB DDR5 DP HDMI 2XDVI Graphics Card](http://www.amazon.com/XFX-Double-1000MHz-Graphics-R9290XEDFD/dp/B00HHIPN5A%3FSubscriptionId=1SW6D7X6ZXXR92KVX0G2&tag=thekintespacec00&linkCode=xm2&camp=2025&creative=165953&creativeASIN=B00HHIPN5A). I guess that my motherboard simply cannot handle it or (very unlikely) my power supply cannot handle it. I’ve remembered that I’m an Amazon Prime dude so I can order another experimental card (from a year ago) [Sapphire Radeon R9 270X 2GB GDDR5 DVI-I/DVI-D/HDMI/DP Dual-X with Boost and OC Version PCI-Express Graphics Card 11217-01-20G](http://www.amazon.com/Sapphire-Version-PCI-Express-Graphics-11217-01-20G/dp/B00B3WTWXU%3FSubscriptionId=1SW6D7X6ZXXR92KVX0G2&tag=thekintespacec00&linkCode=xm2&camp=2025&creative=165953&creativeASIN=B00B3WTWXU) and get it by the end of the week.

<https://github.com/BryanWilhite/>
