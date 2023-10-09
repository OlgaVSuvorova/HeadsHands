
using System;
using System.Text.RegularExpressions;
namespace HeadsHands // 
{ 
public class Gamer :  BaseEntity
{
  private int rebornLeft = 4;
  private int initialHealth;

  
  protected override string GetEnitityTypeName()
  {
    return "Gamer";
  }
    
  public Gamer() : base(GetRandomHealth())
  {
      this.initialHealth = GetHealth();
  }

  protected Gamer(int health, DamagePower damagePower, int attackPower, int protectionPower) : 
    base(health, damagePower, attackPower, protectionPower)
  {
      
  }

  
  private bool CanReborn()
  {
    return rebornLeft > 0;
  }

  

  public override void ModifyHealth(int modifier)
  {
    base.ModifyHealth(modifier);
    if (!IsAlive()) Reborn();
  }

  public override string GetState()
  {
    return base.GetState() + " l:" + rebornLeft.ToString();
  }

  private bool Reborn()
  {
    if (CanReborn())
    {
      rebornLeft --; 
      SetHealth((int)(initialHealth * 0.3));
      Console.WriteLine("reborn");
      return true;
    }
    else return false;
  }


  

  

  

  
  

}
}