---
title: "fuzzing과 fuzzer"
categories: [bugbounty]
tags: [fuzzing, fuzzer, bugbounty, hspace]
---

# fuzzing
퍼징은 비정상적이거나 다양한 입력을 프로그램에 자동으로 반복해서 넣어 충돌, 멈춤, 메모리 오류와 같은 예상치 못한 동작을 찾는 테스트 방식이다. 단순히 무작위 입력만 넣는 것이 아니라 코드 커버리지와 실행 결과를 피드백으로 사용해, 아직 실행되지 않은 코드 경로에 도달할 가능성이 높은 입력을 계속 변형한다. 이때 Sanitizer는 프로그램에 삽입된 검사 로직으로 실행 중 잘못된 메모리 접근을 감시하고 오류 위치를 보고한다. 오류가 발견되면 그 문제를 일으킨 입력값을 저장해 같은 오류를 재현하고 원인을 분석할 수 있다.
## fuzzer
퍼저는 퍼징 과정을 자동화하는 도구다. 초기 입력값 모음인 seed 또는 corpus를 변형하거나 새로운 입력을 생성하고, 대상 프로그램을 반복 실행하면서 충돌, 시간 초과, Sanitizer 경고, 코드 커버리지 등의 결과를 수집한다. 새로운 코드 경로를 실행하거나 오류를 발생시킨 입력은 따로 저장하고 다시 변형해 더 깊은 실행 경로와 새로운 버그를 탐색한다.
### [https://github.com/AFLplusplus/AFLplusplus](https://github.com/AFLplusplus/AFLplusplus)
하단 설명: AFL을 더 강하게 만든 퍼저 프레임워크, AFL++은 구글 AFL의 fork이고 더 빠른 실행, 더 많은 mutation, 더 나은 instrumentation, custom module 지원 등을 목표로 합니다

- **AFL**: 프로그램에 이상한 입력값을 계속 넣어 보면서 버그를 찾는 도구
- **AFL++**: 구글이 만든 AFL 코드를 기반으로 가져와서 따로 발전시킨 프로젝트
- **FORK**: 남이 만든 오픈소스 코드를 복사해서 거기서 새로운 버전으로 발전시키는 것
- **mutation**: 변형시킨다 ⇒ 입력값을 더 다양하게 바꿔서 넣는다
- **instrumentation**: 프로그램 안에서 어떤 코드가 실행됐는지 추적하는 도구

AFL++는 랜덤으로 입력하는 게 아니라 어떤 입력값이 새로운 코드 경로를 실행하는지 보는 것입니다

### [https://github.com/googleprojectzero/Jackalope](https://github.com/googleprojectzero/Jackalope)

하단 설명: 커스터마이징 가능하고 분산 실행이 가능하며 black-box binary에도 사용할 수 있는 coverage-guided 퍼저

- **분산 실행이 가능하다**: 기본적으로 퍼징은 입력값을 엄청 많이 넣어 봐야 하는데 이 과정을 여러 컴퓨터에 분산해서 돌리면 더 빠른 테스트를 할 수 있게 해 준다
- **black-box binary**: 소스 코드가 없어도 실행 파일만 있으면 테스트할 수 있다
    - 보안 분석을 할 때는 소스코드가 없는 프로그램이 많습니다
    - 소스코드가 없는 프로그램은 소스코드를 수정해서 instrumentation을 넣기가 힘듭니다
    - 그래서 Jackalope처럼 바이너리 자체를 계측해서 퍼징하는 도구가 필요합니다
        - **instrumentation**: 프로그램 안에 추적 장치를 심는 것
- **coverage-guided**: 프로그램의 어떤 부분까지 실행됐는지 보면서 입력값을 더 똑똑하게 만드는 퍼저

### [https://github.com/google/honggfuzz](https://github.com/google/honggfuzz)

하단 설명: security-oriented, feedback-driven, evolutionary fuzzer이고, 코드 커버리지를 사용해 버그를 찾는 general-purpose fuzzer

- **security-oriented**: 보안 목적
- **feedback-driven**: 프로그램 실행 결과를 보고 다음 테스트 입력
- **evolutionary**: 입력값을 계속 변형하고 발전시키면서 더 좋은 테스트 케이스를 만듦
- **코드 커버리지를 사용해**: 입력값이 프로그램의 어떤 코드까지 실행했는지 확인하면서 버그를 찾는다
- **general-purpose fuzzer**: 특정 프로그램 하나만을 위한 게 아니라 여러 종류의 프로그램에서 사용 가능

C/C++ 프로그램 테스트, 반복 실행 가능한 라이브러리 테스트, crash, memory bug 찾기 등에 사용 가능

### [https://github.com/aflplusplus/libafl](https://github.com/aflplusplus/libafl)

직접 원하는 방식의 퍼저를 직접 조립해 만드는 부품 모음

---

### [GitHub - google/fuzzing: Tutorials, examples, discussions, research proposals, and other resources related to fuzzing](https://github.com/google/fuzzing/tree/master)

구글이 만든 fuzzing 자료 모음 저장소

하단 설명: fuzzing 관련 tutorial, example, discussion, research proposal, dictionary, documentation 등을 모아 두는 프로젝트

- **discussion**: 퍼징에 대한 토론이나 설명
- **dictionary**: 퍼저가 입력값을 만들 때 참고하는 단어 목록

### [GitHub - uds-se/fuzzingbook: Project page for "The Fuzzing Book"](https://github.com/uds-se/fuzzingbook?utm_source)

random fuzzing, mutation-based fuzzing, grammar-based test generation, symbolic testing 등을 대표 주제로 가지고 있다

- **random**: 무작위 문자열을 계속 만들어 낸다
    - 예상치 못한 입력을 만들 수 있고 적용 방법이 간단하지만 유효 입력 생성 능력이 떨어짐
- **mutation**: 이미 정상적으로 동작하는 입력을 가져와서 조금씩 변경한다
    - 비트를 하나 뒤집는다
    - 특정 바이트 변경
    - 데이터 추가
    - 일부 데이터 삭제
    - 일부분 복사 등
    - random보다 유효 입력률이 높고 기존 입력 corpus를 활용할 수 있지만 seed에 없는 구조를 만들기 어렵다
- **grammar**: 문법 기반 테스트 생성, 즉 프로그램이 받는 입력의 문법을 알려주는 방식
    - 예) 계산기 테스트
        1. 계산기가 받을 수 있는 문법 정의
            1. 1, 2, 3, 4, 5…
        2. 그러면 퍼저가 이것을 이용
            1. 1+2, 3+4…를 만든다
    - 문법적으로는 정상인데 프로그램이 예상하지 못한 입력을 생성한다
    - 문법적으로 유효한 입력을 많이 생성하고 복잡한 파일 형식에 강하지만 만들기가 엄청 어렵다
- **symbolic**: 이전은 테스트 입력 방식을 먼저 만들고 프로그램에 넣는 것이었지만 심볼릭은 프로그램 코드를 분석해서 특정 코드 경로에 들어가기 위해 필요한 입력을 역으로 계산한다

### [GitHub - SoftSec-KAIST/Fuzzing-Survey: The Art, Science, and Engineering of Fuzzing: A Survey](https://github.com/SoftSec-KAIST/Fuzzing-Survey?utm_source)

[https://fuzzing-survey.org/?utm_source](https://fuzzing-survey.org/?utm_source)

퍼저들의 역사와 특징을 정리
