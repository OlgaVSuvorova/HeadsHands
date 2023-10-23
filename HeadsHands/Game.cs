using System;

namespace HeadsHands // 
{ 
public class Game
{
    public void Run()
    {
        Console.WriteLine("Game started started");

        List<Entity> monsters = new ();
        List<Entity> gamers = new();

        monsters.Add(new SupeHealthProtectionMonster());
        monsters.Add(new SuperAttackMonster());
        monsters.Add(new SuperAttackMonster());

        gamers.Add(new Gamer());
        gamers.Add(new SuperGamer());

        Console.WriteLine("Gamers:" + gamers.Count + " Monsters:" + monsters.Count);

        while ((gamers.Count > 0) & (monsters.Count > 0))
        {
            int i = 0;
            Random rnd = new Random();
            Random rndMonsters = new Random();
            while (i < gamers.Count && monsters.Count > 0 && i<100)
            {
                Entity gamer = gamers[i];
                Entity monster = monsters[rndMonsters.Next(0, monsters.Count)];
              
                if (rnd.Next(2) == 0)
                {
                    new FightProcess(gamer, monster).Attack();
                    if (!monster.IsAlive())
                        monsters.Remove(monster);
                }
                else 
                {
                    new FightProcess(monster, gamer).Attack();
                    if (!gamer.IsAlive())
                    {
                        gamers.Remove(gamer);
                        i--;
                    }

                }
                i++;
            }
        }

        Console.WriteLine("Game ended");
        Console.WriteLine("Gamers alive:" + gamers.Count + " Monsters alive:" + monsters.Count);
    }
}
}