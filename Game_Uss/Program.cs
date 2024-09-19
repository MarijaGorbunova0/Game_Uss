using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Game_Uss.Game_Uss;

namespace Game_Uss
{
    public class Programm
    {
        public static void Main(string[] args)
        {
            int mapWidth = 80;
            int mapHeight = 25;


            Console.Clear();
            Console.ForegroundColor = ConsoleColor.White;

            Walls walls = new Walls(mapWidth, mapHeight);

            int bal = 0; 
            Point p = new Point(4, 5, '*');
            Point p2 = new Point(1, 2, '*');

            
            Snake snake = new Snake(p, 4, Direction.Down);
            Levels levels = new Levels(walls, snake);
            Food createFood = new Food(80, 25, '$');
            Point food = createFood.CreateFood();

            List<Barriers> barriers = new List<Barriers>();
            barriers.Add(new Barriers(new Point(10, 0, '#'), 5, Direction.Down));  // Пример одного препятствия
            barriers.Add(new Barriers(new Point(30, 0, '#'), 4, Direction.Down));  // Ещё одно препятствие
            barriers.Add(new Barriers(new Point(50, 0, '#'), 6, Direction.Down));  // И третье

            string docPath = Path.Combine(Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName, "players.txt");

            PlayersControl pc = new PlayersControl(docPath);

            Menu.PrintMenu();
            Console.SetCursorPosition(30, 10);
            Console.WriteLine("Mis sinu nimi on?");
            Console.SetCursorPosition(30, 11);
            string playerName = Console.ReadLine();


            List<string>? playerData = pc.GetPlayer(playerName);
            Player currentPlayer;

            if (playerData != null)
            {
                currentPlayer = new Player(playerName, int.Parse(playerData[1]));
            }
            else
            {
                currentPlayer = new Player(playerName, 0);
                pc.AddPlayer(currentPlayer);
            }
            bal = currentPlayer.BestScore;
            Console.Clear();



            walls.Draw();
            food.Draw();
            
            snake.Draw();
            levels.DrawLevel();
            levels.DrawScore(bal);
            while (true)
            {
                if (walls.IsHit(snake) || snake.IsHitTail() || snake.HitBarriers(barriers))
                {
                    levels.GameOver();
                    pc.UpdatePlayer(currentPlayer);
                    Thread.Sleep(4000);

                    Console.Clear();

                    Console.WriteLine("Best players: ");

                    List<Player> players = new List<Player>();

                    StreamReader f = new StreamReader(docPath);
                    List<string> lines = f.ReadToEnd().Split("\n").ToList();
                    f.Close();

                    foreach (string line in lines)
                    {
                        if (line.Trim() == "")
                        {
                            continue;
                        }
                        List<string> lineFormated = line.Split(":").ToList();
                        string name = lineFormated[0];
                        int bestScore = int.Parse(lineFormated[1]);

                        Player player = new Player(name, bestScore);
                        players.Add(player);
                    }
                    List<Player> bestPlayer = SortPlayers(players, 5);
                    foreach (var player in bestPlayer)
                    {
                        Console.WriteLine($"{player.Name} - {player.BestScore}");
                    }
                    Console.ReadKey();
                    break;

                }
                else if (snake.Eat(food))
                {
                    food = createFood.CreateFood();
                    food.Draw();
                    currentPlayer.BestScore++;

                    bal = levels.Counter(bal);
         
                }
                else
                {
                    snake.Move();
                    if (levels.CurrentLevel == 1)
                    {
                        foreach (var barrier in barriers)
                        {
                            barrier.AutoMove(mapHeight);
                            barrier.Draw();
                        }
                    }
                    else
                    {
                        foreach (var barrier in barriers)
                        {
                            barrier.Clear();
                        }
                        barriers.Clear(); 
                    }
                }

                Thread.Sleep(levels.Speed);
                if (Console.KeyAvailable)
                {
                    ConsoleKeyInfo key = Console.ReadKey();
                    snake.HandleKey(key.Key);
                }

            }
            static List<Player> SortPlayers(List<Player> players, int playersLimit)
            {
                List<Player> bestPlayers = new List<Player>();
                bool status;
                foreach (Player player in players)
                {
                    status = true;
                    if (bestPlayers.Count == 0)
                    {
                        bestPlayers.Add(player);
                        continue;
                    }
                    for (int i = 0; i < bestPlayers.Count; i++)
                    {
                        if (bestPlayers[i].BestScore < player.BestScore)
                        {
                            bestPlayers.Insert(i, player);
                            status = false;
                            break;
                        }
                    }
                    if (status)
                    {
                        bestPlayers.Add(player);
                    }

                }

                return bestPlayers.GetRange(0, bestPlayers.Count > playersLimit ? playersLimit : bestPlayers.Count);
            }
        }
    }
}
