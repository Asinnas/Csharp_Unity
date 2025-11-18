using System;
using System.Collections.Generic;

namespace HomeWork
{
    internal class GameManager
    {
        Player? player;
        List<Enemy> enemyList = new List<Enemy>();
        GridManager gridManager = new GridManager();
        Random rnd = new Random();
        MainLoop? mainloop;

        public void StartBattle()
        {
            Console.WriteLine("Bắt đầu game!");

            var weapons = new List<Weapon>() {
                new Weapon("Sword", 2, 2),
                new Weapon("Axe", 3, 1),
                new Weapon("Bow", 1, 3)
            };

            Console.WriteLine("Chọn vũ khí:");
            for (int i = 0; i < weapons.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {weapons[i].Name} (DMG: {weapons[i].Damage}, Range: {weapons[i].RangeAttack})");
            }

            int choice;
            while (true)
            {
                Console.Write("Nhập số (1-3): ");
                if (int.TryParse(Console.ReadLine(), out choice) &&
                    choice >= 1 && choice <= weapons.Count)
                {
                    break;
                }

                Console.WriteLine("Lựa chọn không hợp lệ, vui lòng nhập lại!");
            }

            player = new Player(0, 0, weapons[choice - 1]);

            Console.WriteLine("\nChọn chế độ khó:");
            Console.WriteLine("1. Easy (1 quái)");
            Console.WriteLine("2. Normal (2 quái)");
            Console.WriteLine("3. Hard (4 quái)");

            int mode;
            while (true)
            {
                Console.Write("Nhập số (1-3): ");
                if (int.TryParse(Console.ReadLine(), out mode) &&
                    mode >= 1 && mode <= 3)
                {
                    break;
                }
                Console.WriteLine("Lựa chọn không hợp lệ, nhập lại!");
            }

            int enemyAmount = mode switch
            {
                1 => 1, // Easy
                2 => 2, // Normal
                3 => 4, // Hard
                _ => 2
            };

            Console.WriteLine($"Chế độ được chọn => Sinh {enemyAmount} quái!\n");

            enemyList.Clear();
            for (int i = 0; i < enemyAmount; i++)
            {
                enemyList.Add(new Enemy(rnd.Next(0, 10), rnd.Next(0, 10)));
            }

            gridManager.SpawnTile();

            mainloop = new MainLoop(player, enemyList, gridManager);
            mainloop.GameLoop();
        }
    }
}
