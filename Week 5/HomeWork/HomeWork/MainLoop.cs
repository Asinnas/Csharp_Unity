using System;
using System.Collections.Generic;

namespace HomeWork
{
    internal class MainLoop
    {
        Player player;
        List<Enemy> enemyList;
        GridManager gridManager;

        public MainLoop(Player player, List<Enemy> enemyList, GridManager gridManager)
        {
            this.player = player;
            this.enemyList = enemyList;
            this.gridManager = gridManager;
        }

        public void GameLoop()
        {
            while (true)
            {
                gridManager.UpdateGrid(player, enemyList);
                gridManager.DrawGrid();
                PrintStatus();

                if (CheckWinOrLose()) break;

                Console.Write("Nhập hướng (W/A/S/D): ");
                char input = Console.ReadKey().KeyChar;
                Console.WriteLine();
                player.Move(input);
                player.Attack(gridManager.Grid);

                foreach (var e in enemyList)
                {
                    if (e.Health > 0)
                    {
                        e.Move();
                        e.Attack(gridManager.Grid);
                    }
                }
            }
        }

        bool CheckWinOrLose()
        {
            if (player.Health <= 0)
            {
                Console.WriteLine("Bạn đã thua!");
                return true;
            }

            bool allDead = true;
            foreach (var e in enemyList)
                if (e.Health > 0) allDead = false;

            if (allDead)
            {
                Console.WriteLine("Bạn đã thắng!");
                return true;
            }
            return false;
        }

        void PrintStatus()
        {
            Console.WriteLine($"Weapon: {player.CurrentWeapon.Name}");
            Console.WriteLine($"Player HP: {player.Health}");
            for (int i = 0; i < enemyList.Count; i++)
                Console.WriteLine($"Enemy {i + 1}: {enemyList[i].Health} HP");
        }
    }
}
