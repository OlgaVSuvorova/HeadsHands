
using System;
using System.Collections;
using System.ComponentModel;
using System.ComponentModel.Design;
namespace HeadsHands // 
{ 
public class BaseEntity : Entity
{
  private const int maxHealth = 30;
  private const int minHealth = 0;
  private const int maxAttackPower = 30;
  private const int minAttackPower = 1;
  private const int maxProtectionPower = 30;
  private const int minProtectionPower = 1;
  private const int maxDamagePower = 6;
  private const int minDamagePower = 1;
  private DamagePower damagePower;
  
  private int number;
  private int health = 0;
  private readonly int attackPower = 0;
  private readonly int protectionPower = 0;

  protected class DamagePower
  {
    private static int maxAllowedPower = 6;
    private static int minAllowedPower = 1; 
    private int minPower;
    private int maxPower; 
    
    public DamagePower(int minPower, int maxPower)
    {
      CheckValue(minPower, minAllowedPower, maxAllowedPower, "minDamagePower");
      CheckValue(maxPower, minAllowedPower, maxAllowedPower, "maxDamagePower");
      if (maxPower < minPower)
        throw new ArgumentException(
         String.Format("maxDamagePower {0} is less then minDamagePower {1}", maxPower, minPower), "damagePower");
      this.minPower = minPower;
      this.maxPower = maxPower;
    }

    public string GetState()
    {
      return minPower + " " + maxPower;
    }

    public static DamagePower GetMeduimPower()
    {
        int middlePower = GetMedium(minAllowedPower, maxAllowedPower);
        return new DamagePower(
          GetRandom(minAllowedPower, middlePower),
          GetRandom(middlePower, maxAllowedPower));
    }

    public static DamagePower GetHighPower()
    {
      return new DamagePower(
          GetHigh(minAllowedPower, maxAllowedPower),
          maxAllowedPower);
    }

    

    public static DamagePower GetLowPower()
    {
        return new DamagePower(
          minAllowedPower,
          GetLow(minAllowedPower, maxAllowedPower));
         
    }

    public int GetDamagePower()
    {
      return new Random().Next(minPower, maxPower+1);
    }
  }
  
  protected class Counter
  {
    private static Hashtable counters = new Hashtable();

    public static int GetNextNumber(string name)
    {
      if (!counters.ContainsKey(name))
      {
        counters.Add(name, 0);
      }
      int i = (int)counters[name];
      i++;
      counters[name] = i;
      return i;
    }
  }
  public string GetName()
  {
    return GetEnitityTypeName() + number.ToString();
  }

  public virtual string GetState()
  {
    return "h:" + health.ToString() + " a:" + attackPower.ToString() 
      + " p:" + protectionPower.ToString()+" d:"+damagePower.GetState();
  }

  protected virtual string GetEnitityTypeName()
  {
    return "BaseEntity";
  }

  protected virtual int NextNumber()
  {
    return Counter.GetNextNumber(GetEnitityTypeName());
  }

  
  protected BaseEntity(int health) : this (health, DamagePower.GetMeduimPower())
  {
  }
 
  protected BaseEntity(int health, DamagePower damagePower) 
    : this (health, damagePower, 
            GetRandomAttackPower(), GetRandomProtectionPower())
  {
  }

  protected BaseEntity(int health, DamagePower damagePower, int attackPower, int protectionPower)
  {
    number = NextNumber();

    SetHealth(health);
    this.damagePower = damagePower;
    CheckValue(attackPower, minAttackPower, maxAttackPower, "attackPower");
    this.attackPower = attackPower;
    CheckValue(protectionPower, minProtectionPower, maxProtectionPower, "protectionPower");
    this.protectionPower = protectionPower;
    
    Console.WriteLine(GetName() + " created");
  }


  private static int GetRandom(int n1, int n2)
  {
    return new Random().Next(n1, n2+1);
  }

  private static int GetMedium(int n1, int n2)
  {
    return (int)((n2-n1)/2);
  }

  private static int GetLow(int n1, int n2)
  {
    return GetRandom(n1, GetMedium(n1, n2));
  }

  private static int GetHigh(int n1, int n2)
  {
    return GetRandom(GetMedium(n1, n2), n2);
  } 
  protected static int GetRandomAttackPower()
  {
    return GetRandom(minAttackPower, maxAttackPower);
  }

  protected static int GetRandomProtectionPower()
  {
    return GetRandom(minProtectionPower, maxProtectionPower);
  }

  protected static int GetRandomHealth()
  {
    return GetRandom(minHealth, maxHealth);
  }

  protected static int GetMediumAttackPower()
  {
    return GetMedium(minAttackPower, maxAttackPower);
  }

  protected static int GetMediumProtectionPower()
  {
    return GetMedium(minProtectionPower, maxProtectionPower);
  }

  protected static int GetMediumHealth()
  {
    return GetMedium(minHealth, maxHealth); 
  }

  protected static int GetLowHealth()
  {
    return GetLow(minHealth, maxHealth);
  }

  protected static int GetLowAttackPower()
  {
    return GetLow(minAttackPower, maxProtectionPower);
  }

  protected static int GetHighProtectionPower()
  {
    return GetHigh(minProtectionPower, maxProtectionPower);
  }

  protected static int GetHighHealth()
  {
    return GetHigh(minHealth, maxHealth);
  }

  protected static int GetHighAttackPower()
  {
    return GetHigh(minAttackPower, maxProtectionPower);
  }

  protected static int GetLowProtectionPower()
  {
    return GetHigh(minProtectionPower, maxProtectionPower);
  }

  public bool IsAlive()
  {
    return (health >0 );
  }

  public virtual void ModifyHealth(int modifier)
  {
    health += modifier;
  }

  public int GetAttackPower()
  {
    return attackPower;
  }
  public int GetProtectionPower()
  {
    return protectionPower;
  }

  public int GetDamagePower()
  {
    return damagePower.GetDamagePower();
  }

  public int GetHealth()
  {
    return health;
  }

  protected void SetHealth(int health)
  {
    CheckValue(health, minHealth, maxHealth, "health");
    this.health = health;
  }

  private static void CheckValue(int value, int minValue, int maxValue, string name)
  {
    if (value < minValue || value > maxValue)
      throw new ArgumentException(
        String.Format("{0} is not an between {1} {2}", value, minValue, maxValue),
        name);
  }

  

}
}