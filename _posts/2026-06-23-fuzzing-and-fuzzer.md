---
title: "퍼징과 퍼저"
categories: [bugbounty]
tags: [fuzzing, fuzzer, bugbounty, hspace]
---

# 퍼징과 퍼저

[노션 원본 보기](https://app.notion.com/p/3880e129ee9b8041a4eac98df8758610?pvs=1)

## 퍼징

퍼징은 비정상적이거나 다양한 입력을 프로그램에 자동으로 반복해서 넣어 충돌, 멈춤, 메모리 오류와 같은 예상치 못한 동작을 찾는 테스트 방식이다. 단순히 무작위 입력만 넣는 것이 아니라 코드 커버리지와 실행 결과를 피드백으로 사용해, 아직 실행되지 않은 코드 경로에 도달할 가능성이 높은 입력을 계속 변형한다. 이때 Sanitizer는 프로그램에 삽입된 검사 로직으로 실행 중 잘못된 메모리 접근을 감시하고 오류 위치를 보고한다. 오류가 발견되면 그 문제를 일으킨 입력값을 저장해 같은 오류를 재현하고 원인을 분석할 수 있다.

## 퍼저

퍼저는 퍼징 과정을 자동화하는 도구다. 초기 입력값 모음인 seed 또는 corpus를 변형하거나 새로운 입력을 생성하고, 대상 프로그램을 반복 실행하면서 충돌, 시간 초과, Sanitizer 경고, 코드 커버리지 등의 결과를 수집한다. 새로운 코드 경로를 실행하거나 오류를 발생시킨 입력은 따로 저장하고 다시 변형해 더 깊은 실행 경로와 새로운 버그를 탐색한다.

### [AFL++](https://github.com/AFLplusplus/AFLplusplus)

하단 설명: AFL을 더 강하게 만든 퍼저 프레임워크이다. AFL++은 구글 AFL의 포크이며, 더 빠른 실행, 더 많은 mutation, 더 나은 instrumentation, custom module 지원 등을 목표로 한다.

- `AFL`: 프로그램에 계속 이상한 입력값을 넣어 보면서 버그를 찾는 도구
- `AFL++`: 구글이 만든 AFL 코드를 기반으로 가져와 따로 발전시킨 프로젝트
- `fork`: 다른 사람이 만든 오픈소스 코드를 복사해 새로운 버전으로 발전시키는 것
- `mutation`: 입력값을 더 다양하게 변형해서 넣는 것
- `instrumentation`: 프로그램 안에서 어떤 코드가 실행됐는지 추적하는 장치 또는 기법

AFL++는 단순히 랜덤으로 입력하는 것이 아니라, 어떤 입력값이 새로운 코드 경로를 실행하게 만드는지를 보면서 동작한다.

### [Jackalope](https://github.com/googleprojectzero/Jackalope)

하단 설명: 커스터마이징이 가능하고 분산 실행이 가능하며, black-box binary에도 사용할 수 있는 coverage-guided 퍼저이다.

- 분산 실행 가능: 퍼징은 기본적으로 입력값을 엄청 많이 넣어 봐야 하는데, 이 과정을 여러 컴퓨터에 분산해서 돌리면 더 빠르게 테스트할 수 있다.
- `black-box binary`: 소스코드가 없어도 실행 파일만 있으면 테스트할 수 있다.

보안 분석을 할 때는 소스코드가 없는 프로그램이 많다. 소스코드가 없는 프로그램은 소스코드를 수정해서 instrumentation을 넣기 어렵다. 그래서 Jackalope처럼 바이너리 자체를 계측해서 퍼징하는 도구가 필요하다.

- `instrumentation`: 프로그램 안에 추적 장치를 심는 것
- `coverage-guided`: 프로그램의 어떤 부분까지 실행됐는지 보면서 입력값을 더 똑똑하게 만드는 퍼저

### [google/fuzzing](https://github.com/google/fuzzing/tree/master)

구글이 만든 fuzzing 자료 모음 저장소이다.

하단 설명: fuzzing 관련 tutorial, example, discussion, research proposal, dictionary, documentation 등을 모아 둔 프로젝트이다.

- `discussion`: 퍼징에 대한 토론이나 설명
- `dictionary`: 퍼저가 입력값을 만들 때 참고하는 단어 목록

### [Honggfuzz](https://github.com/google/honggfuzz)

하단 설명: security-oriented, feedback-driven, evolutionary fuzzer이며, 코드 커버리지를 사용해 버그를 찾는 general-purpose fuzzer이다.

- `security-oriented`: 보안 목적
- `feedback-driven`: 프로그램 실행 결과를 보고 다음 테스트 입력을 조정하는 방식
- `evolutionary`: 입력값을 계속 변형하고 발전시키면서 더 좋은 테스트 케이스를 만드는 방식
- 코드 커버리지 사용: 입력값이 프로그램의 어떤 코드까지 실행했는지 확인하면서 버그를 찾음
- `general-purpose fuzzer`: 특정 프로그램 하나만을 위한 것이 아니라 여러 종류의 프로그램에서 사용할 수 있는 퍼저

C/C++ 프로그램 테스트, 반복 실행 가능한 라이브러리 테스트, crash와 memory bug 탐지 등에 사용할 수 있다.

### [LibAFL](https://github.com/aflplusplus/libafl)

직접 원하는 방식의 퍼저를 조립해 만들 수 있는 부품 모음이다.
