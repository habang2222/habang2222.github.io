# Known limitations

- 현재 1단계이며 화면 캡처, 썸네일, 원격 입력, SQLite, 설치 패키지는 아직 구현되지 않았다.
- gRPC는 개발용 평문 HTTP/2다. TLS와 Controller 허용 목록 전에는 인터넷이나 신뢰할 수 없는 LAN에 노출하면 안 된다.
- 최초 6자리 페어링과 인증서 발급은 5단계 TODO다. 현재 `appsettings.json`에 개발 Agent 주소를 직접 넣는다.
- Agent는 Windows 서비스 설치가 아닌 콘솔 호스트 형태다. 서비스/Tray 패키징은 6단계 TODO다.
- 프로세스의 `MainWindowHandle`이 0이면 의도적으로 제외한다.
- 현재 화면 스트림 및 입력 RPC 구현이 없으므로 원격 제어는 불가능하다.
- 자동화, 매크로, 반복 입력, 조건부 동작, 입력 브로드캐스팅은 향후에도 구현하지 않는다.
