# Build and run

## 요구사항

- Windows 10/11 x64
- .NET 8 SDK

## 빌드와 테스트

```powershell
dotnet restore EveRemoteManager.sln
dotnet build EveRemoteManager.sln -c Release --no-restore
dotnet test EveRemoteManager.sln -c Release --no-build
```

## 1단계 로컬 실행

터미널 1:

```powershell
dotnet run --project src/EveRemote.Agent/EveRemote.Agent.csproj
```

터미널 2:

```powershell
dotnet run --project src/EveRemote.Controller/EveRemote.Controller.csproj
```

다른 PC를 시험하려면 Controller의 `appsettings.json`에 Agent 주소를 추가한다. TLS가 없는 1단계에서는 신뢰할 수 있는 격리 LAN에서만 시험하고 Windows 방화벽으로 허용 대상을 제한한다.

## VM 경량화

- Agent는 창/Tray UI 없이 실행하며 2초 폴링과 최신 상태 스냅샷 하나만 유지한다.
- `DiscoveryIntervalMs`를 늘리면 CPU 사용이 더 줄어든다.
- 선택되지 않은 영상 5 FPS, 선택 영상 20 FPS는 2단계에서 변화 감지와 함께 적용한다.
- 서비스 배포 시 Release, x64, framework-dependent 빌드를 우선해 디스크 중복을 줄인다.
