# Architecture

## 참고 저장소 분석

Phrynohyas/eve-o-preview는 2022-05-19에 보관된 Windows 로컬 멀티클라이언트 창 전환 도구다. 단일 .NET Framework 4.6.2 WinForms 애플리케이션이 `Process.GetProcesses()`로 `ExeFile` 창을 찾고, DWM 썸네일 또는 스크린샷 호환 모드로 미리보기를 제공한다. 로컬 창을 전경으로 전환하지만 키보드/마우스 입력을 중계하지 않는다. 원격 통신, 인증, 세션, 입력 라우팅 계층은 없다.

## 재사용 결정

- 재사용: 제품 개념 수준의 창 탐지, `MainWindowHandle != 0`, 창 제목/핸들 변경 추적, 읽기 전용 미리보기 UX.
- 직접 복사하지 않음: 원본 WinForms, DWM 썸네일, 프로세스 캐시, Win32 선언과 UI 코드.
- 새 구현: .NET 8, WPF Controller, Worker/Kestrel Agent, gRPC 계약, TLS/페어링, Windows Graphics Capture, 단일 대상 입력 검증, SQLite 감사 로그.

원본은 MIT이므로 복사·수정·배포가 가능하지만 저작권 및 허가 고지를 포함해야 한다. 현재 코드는 원본을 복사하지 않았으며 출처와 라이선스를 `THIRD_PARTY_NOTICES.md`에 기록한다.

## 구성

```text
Controller (WPF)
  -> Protocol (gRPC, 향후 TLS)
      -> Agent (경량 BackgroundService + Kestrel)
          -> Core abstractions/models
          -> Infrastructure (Win32, 향후 WGC/SQLite/DPAPI)
```

- `EveRemote.Core`: 플랫폼 독립 모델과 향후 세션/입력 불변식.
- `EveRemote.Protocol`: 버전이 지정된 protobuf 계약. 브로드캐스트 RPC는 만들지 않는다.
- `EveRemote.Infrastructure`: Win32 및 향후 캡처/입력/저장소 구현.
- `EveRemote.Agent`: 로컬 탐지와 네트워크 서비스. 원격 입력은 5단계 보안 게이트 전에는 노출하지 않는다.
- `EveRemote.Controller`: UI 스레드를 막지 않는 폴링 및 상태 표시.

## 안전하고 단순한 결정

1. Agent 식별자는 기본적으로 컴퓨터 이름이며 이후 페어링 인증서 지문으로 대체한다.
2. 1단계 개발 포트는 HTTP/2 평문 5081이다. LAN 배포 금지이며 TLS 완료 전 localhost 시험 전용이다.
3. Agent는 전체 이력을 보관하지 않고 2초마다 작은 불변 스냅샷 하나만 교체한다.
4. 프로세스 이름은 `appsettings.json`에서 읽고 `.exe` 유무를 정규화한다.
5. 최소화/캡처 실패 시 상태만 보고하며 입력을 생성하지 않는다.
6. 향후 영상 코덱은 `IFrameEncoder` 경계 뒤에 두어 JPEG에서 H.264/WebRTC로 교체 가능하게 한다.

## 단계 계획

1. 기반/탐지/상태 UI — 현재 완료.
2. Windows Graphics Capture와 JPEG 썸네일/선택 화면.
3. 좌표 정규화와 선택된 단일 창의 마우스 입력.
4. 키보드/휠, 순서·만료·Heartbeat 세션 차단.
5. TLS, 6자리 현장 승인 페어링, 인증서 허용 목록, DPAPI, 비상 단축키, 감사 로그.
6. 전체 테스트, 설치 패키지, 운영 문서.
