using System;
namespace HeadsHands // 
{
public class FightProcess
{
    private Entity attacking;
    private Entity defending;

    public FightProcess(Entity attacking, Entity defending)
    {
        this.attacking = attacking;
        this.defending = defending;
    }

    public bool Attack()
    {
        Console.WriteLine(attacking.GetName() + " is trying to attacking " + defending.GetName());
        if (CanAttack())
        {
            Console.WriteLine(attacking.GetName() + " " + attacking.GetState() + " is attacking " + defending.GetName()  + " " + defending.GetState());
            defending.ModifyHealth(-attacking.GetDamagePower());
            Console.WriteLine("After attack: " + defending.GetName()  + " " + defending.GetState());
        }
        else{
            Console.WriteLine(attacking.GetName() + " cannot attack " + defending.GetName());
        }
        Console.WriteLine(defending.GetName() + " is alive:" + defending.IsAlive());
        Console.WriteLine("");
        return true;
    }

    private int GetAttackModifier()
    {
        return attacking.GetAttackPower() - defending.GetProtectionPower() + 1;
    }

    private bool CanAttack()
    {
        int throwsNumber = GetAttackModifier();
        if (throwsNumber<1) throwsNumber=1;
        bool success = false;
        int n = 1;
        while (!success & n <= throwsNumber)
        {
            int m = (new Random()).Next(1,7);
            success = ((m==6) || (m == 5));
            n++;
        }
        return success;
    }
}

}