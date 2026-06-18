---
title: "유튜브 영상 다운로드 앱"
categories: [development]
tags: [Android, APK, 유튜브, 다운로드, 앱제작]
---

# 유튜브 영상 다운로드 앱

우리가 제작한 유튜브 영상 다운로드 앱의 안드로이드 설치 파일입니다.

[APK 다운로드](/downloads/youtube-video-downloader-3.3.apk)

## 주요 기능

- YouTube 링크 저장
- 전체 화면 YouTube 홈 WebView에서 실제 모바일 YouTube 탐색/검색/시청
- 전체 화면 Shorts WebView에서 실제 YouTube Shorts 탐색/시청
- YouTube 모바일 WebView 자체 플레이어로 영상 재생
- 홈/Shorts에서 하단 탭바를 숨기고 하단 손잡이를 탭하거나 위로 드래그해 표시
- 현재 기기의 WebView 기반 모바일 Chrome 사용자 에이전트와 모바일 YouTube 고정 URL 사용
- 시스템 라이트/다크 모드에 맞춰 YouTube WebView 테마 보조 적용
- 홈/Shorts 우측 숨김 패널을 왼쪽으로 드래그해 현재 영상 갤러리 저장
- WebView 플레이어 팝업, 전체화면, 보호 미디어 권한 처리로 YouTube 재생 안정화
- YouTube 광고 프리롤 감지 시 스킵 버튼을 누르고 비정상 고속 재생을 자동 복구
- YouTube 시청 페이지의 상태바 겹침 제거와 검은 화면을 만들던 강제 플레이어 CSS 제거
- YouTube 시청 페이지에서 비디오 내부 요소는 건드리지 않고 플레이어 래퍼 높이만 보정
- 홈/앱 전환 시 재생 중이면 Picture-in-Picture 팝업 자동 전환
- Picture-in-Picture에서는 YouTube WebView 렌더링을 강제 CSS로 바꾸지 않아 검은 화면을 줄임
- Picture-in-Picture 중에는 백그라운드 ExoPlayer 오디오를 중복 실행하지 않아 소리 끊김 완화
- Picture-in-Picture 진입은 fl_pip 방식처럼 Activity PIP 파라미터만 사용하고 WebView 내부 화면은 건드리지 않음
- 재생 중 yt-dlp/ExoPlayer 사전 준비 작업을 멈춰 PIP 시청 중 끊김 원인을 줄임
- 재생 중 foreground service로 오디오 포커스와 웨이크락 유지 보강
- 재생 중 백그라운드 오디오 스트림을 미리 준비해 화면 꺼짐 후 15초 안팎으로 멈추는 현상 완화
- 저장한 YouTube 링크를 앱에서 바로 열기
- 저장한 YouTube 링크 삭제
- 저장한 YouTube 링크를 갤러리에 저장
- 다운로드 전에 yt-dlp 엔진을 주기적으로 업데이트
- 저장한 영상의 제목/썸네일을 앱 안에 보존
- 저장한 영상을 원클릭 삭제
- 앱 안에서 저장된 영상 오프라인 시청
- 화면이 꺼져도 소리 재생
- 재생 감지 후에만 오디오 포커스, 부분 웨이크락, 백그라운드 오디오 보조 적용
- 재생/멈춤, 1.5x, 2x, 3x 배속, 더블탭 10초 건너뛰기
- 자동 다음 영상 재생 또는 현재 영상 반복 선택
- 재생목록 만들기, 편집, 영상 제거
- 모바일 데이터 다운로드 경고

## 설치 방법

1. 안드로이드 기기에서 위 링크를 눌러 APK를 다운로드합니다.
2. 다운로드한 APK 파일을 엽니다.
3. 설치 차단 안내가 나오면 브라우저 또는 파일 관리자에 대해 `알 수 없는 앱 설치 허용`을 켭니다.
4. 다시 APK 파일을 열어 설치합니다.

현재 APK는 최신 안드로이드 기기에서 주로 사용하는 `arm64-v8a`용으로 빌드했습니다.

## 파일 위치

APK 파일은 아래 경로에 올리면 됩니다.

```text
downloads/youtube-video-downloader.apk
```

사이트에 배포되면 다운로드 주소는 아래와 같습니다.

```text
https://habang2222.github.io/downloads/youtube-video-downloader.apk
```
