$currentDir = (Get-Item -Path ".\" -Verbose).FullName
[Net.ServicePointManager]::SecurityProtocol = [Net.SecurityProtocolType]::T