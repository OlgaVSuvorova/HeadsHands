
using System;
using System.Text.RegularExpressions;
namespace HeadsHands // 
{ 
public class SuperGamer :  Gamer
{
  
  protected override string GetEnitityTypeName()
  {
    return "SuperGamer";
  }

  //High attack, damage, health and protection  
  public SuperGamer() : base(
    GetHighHealth(), DamagePower.GetHighPower(), 
    GetHighAttackPower(), GetHighProtectionPower())
  {
      
  }

  

  

  

  
 


  

  

  

  
  

}
}