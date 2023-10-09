
using System;
using System.Text.RegularExpressions;
namespace HeadsHands // 
{ 

//super health and protection, medium attack, damage
public class SupeHealthProtectionMonster : BaseEntity
{
  
  public SupeHealthProtectionMonster() : base(
    GetHighHealth(), DamagePower.GetMeduimPower(),
    GetMediumAttackPower(), GetHighAttackPower())
  {
  }

  protected override string GetEnitityTypeName()
  {
    return "SupeHealthMonster";
  }

 

}
}