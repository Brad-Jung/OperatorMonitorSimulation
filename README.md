# Simulation Application for Operator Monitor
## protoc compile
C#의 경우, protoc을 사용할 경우, deserialize 시에 아래 url의 내용과 같은 exception이 발생하며 정상 동작이 되지 않는다.
https://stackoverflow.com/questions/11564914/protobuf-net-error-type-is-not-expected-and-no-contract-can-be-inferred-block
  
protobuf의 .net 버전의 경우, 두 가지 패키지가 있다고 한다.  
 - protobuf-csharp-port  
 - protobuf-net  
  
현재 코드는 protobuf-net패키지를 사용하고 있다.  
그래서 protogen을 이용해서 .proto파일을 cs파일로 변환하도록 했다.  

## protogen(.proto -> .cs)
 - VehicleGateway에서 사용하는 VehicleCANData.proto파일을 MonitoringAppSimulation\tool\에 업데이트.  
 - MonitoringAppSimulation\tool 디렉토리의 protogen.bat파일을 실행하면 VehicleCANData.cs파일이 생성됨.  

## Application 실행
 - MonitoringAppSimulation\MonitoringAppSimulation.sln을 열어서 실행 또는,
 - MonitoringAppSimulation\bin\Debug\MonitoringAppSimulation.exe파일을 실행.