
using System;
using System.Text.RegularExpressions;

namespace HeadsHands // 
{ 
public class MediumMonster : MonsterEntity
{
  public MediumMonster() : base(
    GetMediumHealth(), DamagePower.GetMeduimPower(),
    GetMediumAttackPower(), GetMediumProtectionPower())
  {
    
  }

  protected override string GetEnitityTypeName()
  {
    return "MediumMonster";
  }

 

}
}