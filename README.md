# Habang Blog

GitHub Pages에서 바로 배포할 수 있는 Jekyll 기반 마크다운 블로그입니다.

## 카테고리

- `development`
- `ctf-wargame`
- `bugbounty`
- `blog-techdocs`
- `papers-conferences`
- `contests-certifications`

## 글 작성 방법

1. `_posts` 폴더에 `YYYY-MM-DD-title.md` 파일을 만듭니다.
2. 아래 front matter를 맨 위에 넣습니다.

```md
---
title: "글 제목"
categories: [development]
tags: [tag1, tag2]
---
```

3. 아래에 마크다운 본문을 작성합니다.

## 새 글 템플릿

```md
---
title: "글 제목"
categories: [development]
tags: []
---

## 개요

내용 작성
```

## GitHub Pages 배포

1. GitHub에 `habang2222.github.io` 저장소를 만듭니다.
2. 현재 폴더 내용을 push 합니다.
3. 저장소의 `Settings > Pages`에서 배포 브랜치를 `main`으로 설정합니다.

GitHub Pages는 Jekyll을 기본 지원하므로 별도 빌드 없이 마크다운 글 업로드만으로 운영할 수 있습니다.
