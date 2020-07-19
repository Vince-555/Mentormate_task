using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mentormate
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] xAndY = Console.ReadLine().Split(new string[] { ", " },StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int x = xAndY[0]; int y = xAndY[1]; //rows are always Y , columns are always X [y,x]
            Game GameOne = new Game();
            GameOne.GameEngine = new Engine(y,x);
            for (int i = 0; i < y; i++)
            {
                char[] valuesRow = Console.ReadLine().ToCharArray();
                for (int j = 0;j<valuesRow.Length;j++)
                {
                    GameOne.GameEngine.Grid[i, j] = (int)char.GetNumericValue(valuesRow[j]);
                }
            }
            int[] finalInput = Console.ReadLine().Split(new string[] { ", " }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            GameOne.GameCellX = finalInput[0];
            GameOne.GameCellY = finalInput[1];
            GameOne.NumberOfTurns = finalInput[2];

            

            for (int i = 0; i < GameOne.NumberOfTurns; i++)
            {
                GameOne.GameEngine.NextGenGrid = new int[GameOne.GameEngine.Y, GameOne.GameEngine.X];
                for (int j = 0; j < y; j++)
                {
                    for (int k = 0; k < x; k++)
                    {
                        var GreenCount = GameOne.GameEngine.GreenNeighboursCount(j, k);
                        var NextGenColour = GameOne.GameEngine.NextGenColorCheck(j, k, GreenCount);
                        GameOne.GameEngine.NextGenGrid[j, k] = NextGenColour;
                    }
                }
                
                if (GameOne.GameEngine.NextGenGrid[GameOne.GameCellY,GameOne.GameCellX]==1) { GameOne.TimesGreen++; }
                GameOne.GameEngine.Grid = GameOne.GameEngine.NextGenGrid;
            }

            Console.WriteLine(GameOne.TimesGreen); 


        }

    }
}
