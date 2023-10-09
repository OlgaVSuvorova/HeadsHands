
using System;
using System.Text.RegularExpressions;
namespace HeadsHands // 
{ 
    
//High attack and damage, low health and protection
public class SuperAttackMonster : BaseEntity
{

  
  public SuperAttackMonster() : 
    base( GetLowHealth(), DamagePower.GetHighPower(), 
    GetLowAttackPower(), GetLowProtectionPower() )
  {
    
  }

  protected override string GetEnitityTypeName()
  {
    return "SuperDamageMonster";
  }

}
}