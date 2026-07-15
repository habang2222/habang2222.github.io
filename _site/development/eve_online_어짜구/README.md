# EveRemoteManager

Windows 전용 다중 PC EVE Online **수동 원격 관리** 프로그램입니다. Controller에서 Agent와 EVE 창 상태를 확인하고, 이후 단계에서 사용자가 선택한 창 하나만 화면으로 보며 직접 조작하도록 설계합니다.

## 현재 구현 범위: 1단계

- .NET 8 솔루션 및 5개 제품 프로젝트, 3개 테스트 프로젝트
- 설정 가능한 프로세스 이름으로 EVE 최상위 창 탐지
- Agent의 읽기 전용 gRPC 상태/Heartbeat 서비스
- Controller의 Agent 연결 상태, 지연시간, EVE 창 수와 창 메타데이터 표시
- 입력과 화면 스트리밍 RPC는 계약 확장 지점만 존재하며 실행 구현은 없음

## 의도적으로 지원하지 않음

자동 플레이, 매크로, 반복 입력, 조건부 입력, 화면 인식 자동화, 게임 메모리 읽기, DLL 주입, 패킷 조작 및 입력 브로드캐스팅은 지원하지 않습니다. 하나의 실제 사용자 입력은 활성 세션에서 선택된 클라이언트 하나에만 한 번 전달하는 것이 이후 단계의 강제 불변식입니다.

## 참고 프로젝트

[Phrynohyas/eve-o-preview](https://github.com/Phrynohyas/eve-o-preview)는 로컬 EVE 창 탐지와 미리보기 UX를 분석하기 위한 참고 자료로만 사용했습니다. 소스 코드를 복사하지 않았습니다. 자세한 내용은 `THIRD_PARTY_NOTICES.md`와 `ARCHITECTURE.md`를 참고하세요.

빌드와 실행은 `BUILD.md`, 보안 모델은 `SECURITY.md`, 미구현 범위는 `KNOWN_LIMITATIONS.md`, 검증 결과는 `TEST_RESULTS.md`에 있습니다. 최초 6자리 페어링은 5단계 항목이며 현재 버전에는 의도적으로 제공되지 않습니다.
