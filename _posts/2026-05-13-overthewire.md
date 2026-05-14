---
title: "OverTheWire"
categories: [blog-techdocs]
tags: [리눅스, 명령어, HSPACE, 과제]
---



## OverTheWire

# [<<<<<<<<<<<<<<노션 원본 보기>>>>>>>>>>>>>>](https://www.notion.so/OverTheWire-35f0e129ee9b8060b9d4df6269670d7a?source=copy_link)
# [명령어 정리 모음집](https://www.notion.so/35f0e129ee9b8074af01c9aecd672d2a?source=copy_link)

## lv 0

![image.png](/image/20260513overthewire/스크린샷 2026-05-13 210847.png)

![image.png](/image/20260513overthewire/스크린샷 2026-05-13 210912.png)

password == bandit0

## lv 1

![image.png](/image/20260513overthewire/스크린샷 2026-05-13 213158.png)

즉 ZjLjTmM6FvvyRnrb2rfNWOZOTa6ip5If 가 비밀번호이다

![image.png](/image/20260513overthewire/스크린샷 2026-05-13 213328.png)

![image.png](/image/20260513overthewire/스크린샷 2026-05-13 213338.png)

## lv 2

이 문제에서 가장 중요한점은 파일 이름이 “ - “ 라는 것입니다 이것은 cat으로 읽으려고 하여도 옵션으로 해석되어서 ./-로 읽으면 됩니다

![image.png](/image/20260513overthewire/스크린샷 2026-05-13 214117.png)

263JGJPfgU6LtdEvgfWU1XP5yac29mFx

## lv 3

이 문제 에선 --spaces in this filename— 이 파일을 봐야 하는데 띄워쓰기가 있어서 따옴표로 한번 감싸고  - 가 있어서 ./ 를 앞에 붙여서 하면

![image.png](/image/20260513overthewire/스크린샷 2026-05-13 214928.png)

MNk8KNH3Usiio41PRUEoDFPqfxLPlSmx

## lv 4

![image.png](/image/20260513overthewire/스크린샷 2026-05-13 215148.png)

2WmrDFRmJIq3IPxneAaMGhap0pFhF3NJ

## lv 5

![image.png](/image/20260513overthewire/스크린샷 2026-05-13 215814.png)

4oQYVPkxZOOEOO5pTW81FB8j8lxXGUQw

## lv6

find / -user bandit7 -group bandit6 -size 33c

찾는다 하위폴더에서 소유한사람은()이고 그룹은()이고 크기는 33비트인걸

![image.png](/image/20260513overthewire/스크린샷 2026-05-14 123028.png)

![image.png](/image/20260513overthewire/스크린샷 2026-05-14 123120.png)

## lv7

find / -user bandit7 -group bandit6 -size 33c

찾는다 하위폴더에서 소유한사람은()이고 그룹은()이고 크기는 33비트인걸

![image.png](/image/20260513overthewire/스크린샷 2026-05-14 123028.png)

![image.png](/image/20260513overthewire/스크린샷 2026-05-14 123120.png)

morbNTDkSW6jIlUc0ymOdMaLnOlFVAaj

## lv8

![image.png](/image/20260513overthewire/스크린샷 2026-05-14 132153.png)

dfwvzFQi4mU0wfNbFOe9RoWskMLg7eEc

## lv9

![image.png](/image/20260513overthewire/스크린샷 2026-05-14 133700.png)

정렬하고 바로 그 정렬한줄 중복된거 지움

4CKMh1JI91bUIZZPXDqGanal4xvAg0JM

## lv10

![image.png](/image/20260513overthewire/스크린샷 2026-05-14 134626.png)

![image.png](/image/20260513overthewire/스크린샷 2026-05-14 134641.png)

FGUW5ilLVJrxX9kMYMmlN4MgbpfMiqey

## lv11

![image.png](/image/20260513overthewire/스크린샷 2026-05-14 135919.png)

dtR173fZKb0RRsDFSGsg2RWnpNVj3qRr

## lv12

![image.png](/image/20260513overthewire/스크린샷 2026-05-14 144912.png)

한마디로 모든 문자들이 13번씩 밀려있다는 소리이므로

tr ‘바꿀 대상’ ‘바뀔 문자’ 
즉 ‘A-Za-z’ =A부터 Z까지 a부터z까지
'N-ZA-Mn-za-m’ 그걸 13칸씩 민거
N O P Q R S T U V W X Y Z A B C D E F G H I J K L M 로 풀 수 있다

A → N, B → O, C → P, D → Q, ..., M → Z, N → A, O → B, ..., Z → M

![image.png](/image/20260513overthewire/스크린샷 2026-05-14 145524.png)

7k16WNrHIv5YxIuWfsFIdbbtnUTlw9Q4

## lv13

이 문제는 파일의 상태를 지속적으로 확인하고 최종적으로 패스워드를 확인 하면 되는 문제 입니다

이 문제에서 집중적으로 사용한 코드는 file cat gzip bzip2 mv 를 집중적으로 사용 했습니다.

첫번째로 data.txt파일을 temp 파일에 넣고 시작 하였습니다

다음은 파일의 상태를 확인 하였습니다 

만일 파일이 gzip으로 압축 되어 있으면 .gz형식으로 파일을 바꾸고 파일의 압축을 풀고 bzip2으로 압축 되어 있으면 .bz2 형식으로 바꾸어서 압축을 풀고 파일이 묶여있으면 .tar로 형식을 바꿔서 tar명령어로 파일을 풀고 어셈블어로 되어 있으면.txt형식으로 바꾼후 base64명령어로 문제를 풀었습니다 또 16진수 형식으로 되어 있으면 xxd로 풀었습니다

![image.png](/image/20260513overthewire/스크린샷 2026-05-15 072816.png)

FO5dwFsc0cbaIiH0h8J2eUks2vdTDwAn

![image.png](/image/20260513overthewire/스크린샷 2026-05-15 072859.png)

![image.png](/image/20260513overthewire/스크린샷 2026-05-15 072925.png)

![image.png](/image/20260513overthewire/스크린샷 2026-05-15 072947.png)

## lv14

이 문제는 많이 몰라서 ai 도움을 많이 받았습니다

이 문제에선 key파일을 주고 그 파일을 가지고 bandit14로 입장 하는 문제 였습니다

일단 cat 명령어로 sshkey 를 읽어서 그 값을 복사후 저의 개인 우분투 홈 디렉터리로 이동해 그곳에서 sshkey파일 생성후 복사한 값을 붙여넣었습니다

ssh -i sshkey.private [bandit14@bandit.labs.overthewire.org](mailto:bandit14@bandit.labs.overthewire.org) -p 2220

명령어로 key 로 14 사용자로 입장하였습니다
그 과정에서 권한이 너무 많이 열려여있어 chmod 600으로 권한을 좀 줄였습니다

![image.png](/image/20260513overthewire/스크린샷 2026-05-15 073014.png)

MU4VWeTyJk8ROof1qqmcBPaLh7lDCPvS

## lv15

![image.png](/image/20260513overthewire/스크린샷 2026-05-15 073037.png)

8xCjnmgoKbGLhHFAZlGE5Tmu4M2tKJQo

## lv16

![image.png](/image/20260513overthewire/스크린샷 2026-05-15 073057.png)

![image.png](/image/20260513overthewire/스크린샷 2026-05-15 073122.png)

kSkvUpMQ7lBYyCM4GBPvCvT1BfWRy0Dx

## lv17

이 문제는 nmap을 사용해서 열려있는 포트를 확인함과 동시에 -sV로 속성까지 확인해서 ssl을 지원하는 포트를 확인하는 문제 였습니다 

그 다음은14 레벨과 똑같이 실행 하였습니다

![image.png](/image/20260513overthewire/스크린샷 2026-05-15 073202.png)

![image.png](/image/20260513overthewire/스크린샷 2026-05-15 073227.png)

![image.png](/image/20260513overthewire/스크린샷 2026-05-15 073307.png)

![image.png](/image/20260513overthewire/스크린샷 2026-05-15 073339.png)

![image.png](/image/20260513overthewire/스크린샷 2026-05-15 073404.png)

![image.png](/image/20260513overthewire/스크린샷 2026-05-15 073430.png)

EReVavePLFHtFlFsjn3hyzMlvSuSAcRD

## lv18

![image.png](/image/20260513overthewire/스크린샷 2026-05-15 073500.png)

x2gLTTjFwMOhQ8oWNbMN362QKxfRqGlO

## lv19

이 문제의 문제점은 접속하자마자 튕긴다는것인데 그럼 접속과 동시에 파일을 읽어 버리면 이 문제를 해결 할 수 있습니다

![image.png](/image/20260513overthewire/스크린샷 2026-05-15 073523.png)

![image.png](/image/20260513overthewire/스크린샷 2026-05-15 073542.png)

cGWpMaKXVwDUNgPAVJbWYuGHVn9zl3j8

## lv20

setuid : 파일을 실행한 사용자가 아니라 파일 소유자의 권한으로 실행되게 하는 특수 권한

이 문제는 19번 사용자의 권한으로 20번 사용자의 페이지 내부를 볼수있게 된다는 의미 입니다

./bandit20-do 로 실행 가능합니다

./bandit20-do cat /etc/bandit_pass/bandit20

따라서 0qXahG8ZjOVMN9Ghs7iOWsCfZyXOUbYO

![image.png](/image/20260513overthewire/스크린샷 2026-05-15 073606.png)

## lv21

지금 부터 모든 문제는 ai의 설명을 보고도 컴퓨터, 네트워크 등의 지식 부족으로 이해 하지 못하는 문제들 이였습니다

이 문제에서 제가 해야할 문제는

1. 내가 직접 서버를 하나 열어둔다
2. 그 서버가 bandit20 비밀번호를 보내게 한다
3. setuid 파일을 실행해서 그 포트로 접속하게 한다
4. setuid 파일이 bandit21 비밀번호를 돌려준다

![image.png](/image/20260513overthewire/스크린샷 2026-05-15 073630.png)

![image.png](/image/20260513overthewire/스크린샷 2026-05-15 073652.png)

여기서 nc -l -p 12345는 12345 번 포트에서 서버처럼 대기 한다는 뜻이고
echo 비밀번호 | 는 접속한 쪽에게 비밀번호 한줄을 보낸다는 뜻입니다

![image.png](/image/20260513overthewire/스크린샷 2026-05-15 073708.png)

setuid 파일을 실행해서 방금 연 포트로 접속시킵니다

EeoULMCra2q0dSkYj561DX7s1CpBuOBt

## lv22

이 문제도 이해를 잘 못했지만

![image.png](/image/20260513overthewire/스크린샷 2026-05-15 073732.png)

/etc/cron.d/ 디렉터리 안에 있는 cron작업 파일들을 확인

![image.png](/image/20260513overthewire/스크린샷 2026-05-15 073750.png)

매 분마다 bandit22 사용자 권한으로 /usr/bin/cronjob_bandit22.sh를 실행

![image.png](/image/20260513overthewire/스크린샷 2026-05-15 073816.png)

bandit22 비밀번호를 읽어서 /tmp/t706…… 파일에 저장한다 그리고 그 파일을 다른 사용자도 읽을수 있게 바꾼다

![image.png](/image/20260513overthewire/스크린샷 2026-05-15 073840.png)

tRae0UfB9v0UzbCdn9cY0gQnds9GF58Q

## lv23

이 문제는 22번과 비슷하지만 스크립트가 파일 이름을 계산하고 그 위치에 비밀번호를 저장하는 구조 입니다

![image.png](/image/20260513overthewire/스크린샷 2026-05-15 073903.png)

매 분마다 23권한으로 usr/bin/……. 실행

![image.png](/image/20260513overthewire/스크린샷 2026-05-15 073925.png)

cron 이  이 스크립트를 23 사용자 권한으로 실행 함으로

![image.png](/image/20260513overthewire/스크린샷 2026-05-15 073948.png)

0Zf11ioIjMVN551jX3CmStKLYqjk54Ga

## lv24

![image.png](/image/20260513overthewire/스크린샷 2026-05-15 074015.png)

매분 24번 권한으로 /usr/bin/…… 실행

![image.png](/image/20260513overthewire/스크린샷 2026-05-15 074039.png)

디렉터리 만들어서

![image.png](/image/20260513overthewire/스크린샷 2026-05-15 074102.png)

권한 풀로 다 줍니다

#!/bin/bash
cat /etc/bandit_pass/bandit24 > /tmp/mybandit24/password

이 명령어를 적은 파워쉘 명령어 파일 만들어서 이것또한 풀로 권한을 줍니다

![image.png](/image/20260513overthewire/스크린샷 2026-05-15 074134.png)

gb8KRRCsshuZXI0tUuR6ypOFjiZbf3G8

## lv25

이 문제는 30002번 호스트에 데몬이 열려있고 24번 비밀번호+4자리 숫자 pin을 주면 25비밀번호를 줍니다 

pin은 0000~9999 까지 전부 시도 하면 됩니다

![image.png](/image/20260513overthewire/스크린샷 2026-05-15 074205.png)

임시파일에서

서버 한번에 보내기를 합니다

그럼 실패가 나오다가 패스워드가 나오는데 패스워드만 나오게 바꾼후 하면 

iCi86ttT4KSNe1armKiwbQNmB3YJP3q4

![image.png](/image/20260513overthewire/스크린샷 2026-05-15 074616.png)