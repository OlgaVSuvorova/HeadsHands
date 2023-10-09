
using System;
using System.Text.RegularExpressions;
namespace HeadsHands // 
{ 

  
public class MonsterEntity : BaseEntity
{
  
  protected MonsterEntity(int health, DamagePower damagePower, int attackPower, int protectionPower) : 
    base(health, damagePower, attackPower, protectionPower)
  {
  }

  protected override string GetEnitityTypeName()
  {
    return "Monster";
  }

}
}