---
title: "EVE Remote Manager - 멀티 PC EVE 창 관리 도구"
date: 2026-07-15
categories: [development]
permalink: /development/eve_online_어짜구/
description: "여러 Windows PC에서 실행되는 EVE Online 창을 메인 PC에서 확인하기 위한 경량 원격 관리 도구"
---

# EVE Remote Manager

여러 Windows PC에서 실행 중인 EVE Online 창을 메인 컴퓨터에서 한곳에 모아 확인하기 위한 **수동 원격 관리 도구**입니다.

현재 공개 버전은 **Stage 1 프로토타입**입니다. 원격 PC의 Agent를 찾고 EVE 창 개수, 창 제목, PID, 해상도, 최소화 상태와 연결 지연을 표시합니다. 화면 미리보기와 마우스·키보드 원격 제어는 다음 개발 단계에서 추가할 예정입니다.

<div style="display:flex;gap:12px;flex-wrap:wrap;margin:24px 0">
  <a href="/downloads/eve-remote-manager-stage1-windows-x64.zip" style="display:inline-block;padding:12px 18px;background:#2563eb;color:#fff;border-radius:7px;text-decoration:none;font-weight:700">Windows x64 실행 파일 다운로드</a>
  <a href="/downloads/eve-remote-manager-stage1-source.zip" style="display:inline-block;padding:12px 18px;background:#334155;color:#fff;border-radius:7px;text-decoration:none;font-weight:700">Stage 1 소스 코드 다운로드</a>
</div>

> 이 버전은 기능 확인용 초기 프로토타입입니다. 아직 실제 EVE 화면 전송이나 원격 입력 기능은 없습니다.

## 주요 특징

- Controller: 메인 PC에서 사용하는 WPF 관리 화면
- Agent: 각 원격 Windows PC에서 실행하는 경량 백그라운드 프로그램
- 설정 가능한 EVE 프로세스 이름 탐지
- PC 연결 상태와 지연시간 표시
- EVE 창 제목, PID, 해상도, 최소화 상태 표시
- .NET 8, gRPC, Windows 전용
- Agent 약 51MB, Controller 약 156MB 수준의 초기 메모리 사용량
- 경고 0개·오류 0개 Release 빌드, xUnit 테스트 통과

## 설치 전 요구 사항

- Windows 10 또는 Windows 11 x64
- [.NET 8 Desktop Runtime](https://dotnet.microsoft.com/ko-kr/download/dotnet/8.0)
- Agent PC에는 ASP.NET Core Runtime 8도 필요
- 같은 로컬 네트워크 또는 Tailscale/WireGuard 연결 권장

## 설치 및 실행

1. 위의 `Windows x64 실행 파일 다운로드`를 눌러 ZIP을 받습니다.
2. ZIP 파일을 원하는 폴더에 압축 해제합니다.
3. EVE가 실행되는 원격 PC에서 `Agent 실행.cmd`를 실행합니다.
4. 메인 PC에서 `Controller/appsettings.json`을 열어 Agent 주소를 수정합니다.

```json
{
  "Controller": {
    "Agents": [
      {
        "Name": "EVE PC 1",
        "Address": "http://192.168.0.20:5081"
      }
    ]
  }
}
```

5. 메인 PC에서 `Controller 실행.cmd`를 실행합니다.
6. Controller 왼쪽에 원격 PC가 녹색 `연결됨` 상태로 표시되는지 확인합니다.

여러 PC를 등록하려면 `Agents` 배열에 항목을 추가합니다.

## VM에서 가볍게 사용하기

- Agent는 별도 UI 없이 실행됩니다.
- 기본 EVE 창 탐지 주기는 2초입니다.
- 최신 상태 스냅샷 하나만 메모리에 유지합니다.
- `Agent/appsettings.json`의 `DiscoveryIntervalMs`를 늘리면 CPU 사용량을 더 줄일 수 있습니다.
- 화면 스트리밍 단계에서는 선택하지 않은 창을 5 FPS, 선택한 창을 최대 20 FPS로 제한할 예정입니다.

## 보안 주의사항

Stage 1은 개발용 평문 HTTP/2 통신을 사용합니다.

- Agent의 5081 포트를 인터넷에 직접 공개하지 마세요.
- 신뢰할 수 있는 LAN 또는 Tailscale/WireGuard 안에서만 시험하세요.
- TLS, 6자리 현장 페어링, 인증서 허용 목록은 후속 단계에서 구현됩니다.
- 화면 전송과 입력 기능은 보안 기능이 완성되기 전까지 활성화하지 않습니다.

## 자동화 기능을 지원하지 않습니다

다음 기능은 현재뿐 아니라 향후에도 의도적으로 구현하지 않습니다.

- 자동 플레이, 자동 타게팅, 자동 채굴, 자동 이동, 자동 공격, 자동 판매
- 매크로, 반복 클릭, 조건부 동작
- 하나의 입력을 여러 EVE 클라이언트에 보내는 입력 브로드캐스팅
- 게임 메모리 읽기, DLL 주입, 패킷 조작
- 화면 인식 기반 자동화

향후 원격 입력은 사용자가 현재 선택한 EVE 창 하나에 직접 수행한 입력만 한 번 전달하도록 제한합니다.

## 현재 개발 단계

| 단계 | 내용 | 상태 |
|---|---|---|
| 1 | Agent 탐지, gRPC 상태, Controller 목록 UI | 완료 |
| 2 | Windows Graphics Capture, JPEG 썸네일 | 예정 |
| 3 | 선택된 창 하나의 마우스 입력 | 예정 |
| 4 | 키보드·휠, 순서·만료·Heartbeat | 예정 |
| 5 | TLS, 페어링, DPAPI, 비상 차단 | 예정 |
| 6 | 설치 패키지와 전체 테스트 | 예정 |

## 참고 프로젝트와 라이선스

창 탐지와 미리보기 UX는 MIT 라이선스의 [EVE-O Preview](https://github.com/Phrynohyas/eve-o-preview)를 참고했습니다. 원본 소스는 직접 복사하지 않았고 .NET 8 구조로 새로 작성했습니다.

EVE Online 및 관련 명칭과 자산은 CCP hf.의 지식재산입니다. 이 프로젝트는 CCP hf.와 제휴하거나 보증받은 제품이 아닙니다.

