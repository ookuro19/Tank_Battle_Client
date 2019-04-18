# 滑雪3.0接口文档
本文档为3代滑雪接口参考文档。由于KBEngine的特性，应用在unity中需要生成sdk，所以API分为两部分：
1. 客户端与sdk之间的API
2. sdk与服务器之间的API

## 1. 登录部分

Send:
| C | C/S | S |
|:-: | :-: | :-: |
| PlayerLogin(string name, string pwd) | sdk内置 | kbe内置 |

Callback:
| C | C/S | S |
|:-: | :-: | :-: |
| onLoginSuccessfully() | Avatar.onLoginSuccessfully(UInt64 rndUUID, Int32 eid, KBEngine.Avatar accountEntity)() | kbe内置

## 2. 匹配部分

Send:
| C | C/S | S |
|:-: | :-: | :-: |
| StartMatching(int map, int mode) | StartMatching(int map, int mode) | base.StartMatching(int map, int mode) |
| UpdateLoadingProgress(int tProcess) | Avatar.updateProgress(int tprogerss) | cell.regProgress(int tprogerss) |

Callback:
| C | C/S | S |
|:-: | :-: | :-: |
| public void onEntityEnterWorld(UInt64 rndUUID, Int32 eid, KBEngine.Avatar account) | Avatar.onEnterWorld() | kbe内置 |
| onMatchingFinish(int suc) | onMatchingFinish(int arg1) | base.onMatchingFinish(int suc) |

## 3. 比赛部分

Send:
| C | C/S | S |
|:-: | :-: | :-: |
| ReachDestination() | Avatar.reachDestination() | cell.reachDestination()|
| GetProps(int type) | Avatar.getProps(int type)| cell.getProps(int type) |
|useSkill(targetID, skill) | Avatar.useSkill(targetID, skill) | cell.otherClients.useSkill(id,target_id,skill)
|skillResult(int userID, int targetID, int suc)|Avatar.skillResult(int userID, int targetID, int suc)|cell.room.skillResult(int userID, int targetID, int suc)|

Callback:
| C | C/S | S |
|:-: | :-: | :-: |
| onReachDestination(int eid, float time) | Avatar.reachDestination() | cell.reachDestination() |
| onGetProps(int type) | Avatar.onGetProps(int eid, int type) | otherClients.onGetProps(type)
| onTimerChanged(int sec) | Avatar.onTimerChanged(int sec) | cell.onTimerChanged(int sec) |
| onExitRoom(int suc) | Avatar.onExitRoom(int suc) | base.onExitRoom(int suc)|
| onUseSkill(userID, targetID, skill) | Avatar.onUseSkill(userID, targetID, skill) | onUseSkill(userID, targetID, skill)|
|onSkillResult(int userID, int targetID, int skill)| Avatar.onSkillResult(int userID, int targetID, int skill)| cell.room.onSkillResult(int userID, int targetID, int skill)|

