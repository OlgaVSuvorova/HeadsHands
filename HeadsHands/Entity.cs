

using System;
namespace HeadsHands // 
{

public interface Entity
{
  public abstract bool IsAlive();

  public abstract void ModifyHealth(int modifier);


  public string GetName();

  public abstract int GetHealth();
  public abstract int GetAttackPower();
  public abstract int GetProtectionPower();

  public abstract int GetDamagePower();

  public abstract String GetState();

}
}