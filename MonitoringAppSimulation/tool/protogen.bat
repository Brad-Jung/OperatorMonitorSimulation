@ECHO OFF
rem protoc VehicleCANData.proto --csharp_out=.\ --proto_path=.\

if exist ".\VehicleCANData.cs" (
	echo VehicleCANData.cs files is already exist!
rem	timeout 2
rem	exit 0
	DEL .\VehicleCANData.cs
)

if exist "..\VehicleCANData.cs" (
	echo VehicleCANData.cs files is already exist!
rem	timeout 2
rem	exit 0
	DEL ..\VehicleCANData.cs
)

protogen.exe .\VehicleCANData.proto --csharp_out=.\
if exist ".\VehicleCANData.cs" (
	MOVE .\VehicleCANData.cs ..\
) else (
	echo protogen error!
	timeout 2
	exit 0
)

echo protogen completed!
PAUSE