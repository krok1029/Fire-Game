var player:NavMeshAgent; //帶有NavMeshAgent屬性的物件=Player
var target:Transform; //NPC物件

function Update () {
    player.destination=target.position; //玩家終點位置=NPC所在位置

}