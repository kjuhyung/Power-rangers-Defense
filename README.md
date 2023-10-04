# 🏎 Power-rangers-Defense
 내일배움캠프 유니티 숙련 프로젝트 : 타워 디펜스 게임 제작 
<br/>

## 🧑‍💻 팀 소개 및 팀원

**3팀 - 주형파워레인저스**

|이름|담당|깃허브 주소|
|------|---|------|
|김주형|팀장(레드)|[링크](https://github.com/kjuhyung)|
|김연우|팀원|[링크](https://github.com/kimyeonwoo1234)|
|문준권|팀원|[링크](https://github.com/MoonJunkwon?tab=repositories)|
|정재호|팀원|[링크](https://github.com/Jaero0)|
|함영주|팀원|[링크](https://github.com/HamYoungjoo)|

<br/>

## 🖥 프로젝트 소개 
### [프로젝트명]  Power rangers Defense  (ref game - Plants vs. Zombies) 
**소개**
- **버그 악당들로부터 코딩지구를 지키는 파워레인저! 변신!**  
- 파워레인저들을 강화시켜서 몰려오는 적들을 막고 지구를 지키는 디펜스 게임입니다!
<br/>

### [개발기간] 2023.09.25 ~ 2023.10.02
<br/>

### [프로젝트 기획]
- 와이어프레임 :
[링크](https://miro.com/app/board/uXjVMhkLt0w=/?share_link_id=257604247295)

<br/>

![1](https://github.com/kjuhyung/Power-rangers-Defense/assets/141566906/547e5b99-1c56-4855-a814-6073044671b3)



<br/>


### [작업 환경]
- 유니티 : 2022.3.2f 버전
- 프로젝트 해상도 : 1920 * 1080
<br/>

### [게임 플레이 설명]
1. 시작 버튼을 누른 뒤 스테이지를 선택한 후, 레인저들을 정해진 위치에 배치 해 적들이 지구에 닿지 않도록 타워를 세워 공격합니다.
2. 파워레인저 타워는 골드를 이용해 세울 수 있으며, 골드는 게임 시작 시 1000이 기본으로 주어지고, 게임에서 적을 해치우면서 얻을 수 있습니다.
3. 파워레인저 타워는 8초간 유지됩니다. 8초 뒤 타워가 사라지면 골드를 이용해 다시 설치 할 수 있습니다. 
4. 주어진 시간동안 적들을 막아내면 승리합니다. 만약 적이 지구에 도착한다면 주어진 5개의 목숨이 하나씩 사라지고 목숨을 모두 잃으면 패배합니다.
5. 승리를 통해 얻게 된 다이아를 이용해 스테이지 선택 화면에서 파워레인저 타워의 기능을 강화 할 수 있습니다. (추후 업데이트 예정)
<br/>

### [역할 분담]

- 김주형 - 몬스터 :
        1. 체력, 속도, 공격력 등 속성
        2. 고정된 이동 경로, 충돌 시 로직
        3. 생성 및 움직임
        4.  처치 시 얻는 골드
  
- 김연우 - 게임 상태:
        1. 타워 관리 창
        2. 게임 맵, 스테이지 구현
        3. 진행도 완료시 승리 - 강화 자원 
        4. 게임 시작과 종료 조건 (몬스터 지구에 도달)

- 문준권 - 사운드 및 UI : 
        1. 효과음 ( 몬스터 및 타워 공격, 소환)
        2. 배경음악 (시작, 관리창, 메인)
        3. 자원, 현재 라운드, 진행도 UI
  
- 정재호 - 타워 :
        1. 적을 감지하고 일정 거리 안에 들어오면 공격
        2. 타워 타입에 따라 다른 행동
        3. 체력, 공격력, 효과 등 속성
  
- 함영주 - 플레이어 상태 :
        1. 플레이어 체력 표시
        2. 1회성 인게임 자원 ( 타워 설치용 )
        3. 영구성 강화용 자원 ( 타워 강화용 )
  

  

 <br/>
 

<br/>

## ✅ 기능 상세 설명 

### Start Scene
![스크린샷 2023-10-02 오후 8 58 34](https://github.com/kjuhyung/Power-rangers-Defense/assets/141566906/665229e5-5143-47da-a628-89b95601bd2e)

기능 설명 
1. Start 버튼을 누르면 레벨 선택 화면으로 이동한다.
2. 배경음악, 상단 이펙트(파티클), 애니메이션

<br/>

### Stage Scene
![10 2 stage select scene](https://github.com/kjuhyung/Power-rangers-Defense/assets/141553708/a1da4467-4e60-4446-b328-f59377b6a0d8)

1. 게임 맵을 선택 할 수 있다.
2. 옵션 버튼을 눌러 사운드를 조절 할 수 있다. 

<br/>

### MainScene
스테이지 1 
![스크린샷 2023-10-02 오후 8 58 54](https://github.com/kjuhyung/Power-rangers-Defense/assets/141566906/18ea2840-8391-4e92-8fd7-ee718bc4747c)
![스크린샷 2023-10-02 오후 9 01 44](https://github.com/kjuhyung/Power-rangers-Defense/assets/141566906/7ece0065-9db3-4cb8-ba71-e618787ccc92)
![스크린샷 2023-10-02 오후 9 01 04](https://github.com/kjuhyung/Power-rangers-Defense/assets/141566906/c861e9e1-dcc6-4ada-860a-7f5d697be046)

1. 상,중,하단 에서 랜덤으로 몬스터가 나옵니다.
2. 몬스터가 지구에 도달하면 왼쪽 상단 player hp 가 감소합니다.
3. 하단의 타워들을 적절한 위치에 배치해서 몬스터들을 막거나 공격할 수 있습니다.
4. 타워는 배치할 때 마다 골드가 감소하고 8초간 유지되었다가 사라집니다.
5. 시간이 지날수록 몬스터가 나오는 주기가 짧아집니다.
6. 30초를 버티면 승리, hp 5개가 모두 감소하면 패배가 됩니다.

<br/>












