$SampleAssembly = [Reflection.Assembly]::LoadFile("C:\Users\1579132\source\repos\PcInfoWindows\PcInfoWindows\bin\Debug\PcInfoWindows.dll")
#[PCInfoWindows.PcInfoReader]::
$iReader = New-Object -TypeName 'PCInfoWindows.PcInfoReader'
$iReader.GetPcNameFromWMI()
$iReader.GetHardDriveInfoFromWMI() 
$iReader.GetApplicationEventLog()