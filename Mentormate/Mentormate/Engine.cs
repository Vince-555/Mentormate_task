using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mentormate
{
    public class Engine
    {
        public int[,] Grid { get; set; }
        public int[,] NextGenGrid { get; set; }
        public int Y { get; set; } //Rows
        public int X { get; set; } //Columns

        public Engine(int y, int x)
        {
            this.X = x;
            this.Y = y;
            this.Grid = new int[y, x];
            this.NextGenGrid = new int[y, x];
        }
       public int NextGenColorCheck (int y, int x, int greenNeighboursCount)
       {
            if ((this.Grid[y,x] == 0)&&(greenNeighboursCount==3||greenNeighboursCount==6))
            {
                return 1;
            }
            else if((this.Grid[y,x]==1)&&(greenNeighboursCount==0||greenNeighboursCount==1
                ||greenNeighboursCount==4||greenNeighboursCount==5||greenNeighboursCount==7
                || greenNeighboursCount==8))
                 {
                    return 0;
                 }
            else { return this.Grid[y, x]; }
       }
       public int GreenNeighboursCount(int y, int x)
        {
            List<int> Values = new List<int>();
            if (TryGetCoordinatesValue(y-1,x-1)) { Values.Add(this.Grid[y - 1, x - 1]); } else { Values.Add(0); }
            if (TryGetCoordinatesValue(y - 1, x )) { Values.Add(this.Grid[y - 1, x]); } else { Values.Add(0); }
            if (TryGetCoordinatesValue(y - 1, x+1)) { Values.Add(this.Grid[y - 1, x+1]); } else { Values.Add(0); }
            if (TryGetCoordinatesValue(y, x-1)) { Values.Add(this.Grid[y, x-1]); } else { Values.Add(0); }
            if (TryGetCoordinatesValue(y, x+1)) { Values.Add(this.Grid[y, x+1]); } else { Values.Add(0); }
            if (TryGetCoordinatesValue(y+1, x-1) ){ Values.Add(this.Grid[y+1, x-1]); } else { Values.Add(0); }
            if (TryGetCoordinatesValue(y+1, x)) { Values.Add(this.Grid[y+1, x]); } else { Values.Add(0); }
            if (TryGetCoordinatesValue(y+1, x+1)) { Values.Add(this.Grid[y+1, x+1]); } else { Values.Add(0); }
            return Values.Sum();
        }
        private bool TryGetCoordinatesValue(int y, int x)
        {
            try
            {
                var test = this.Grid[y, x];
                return true;
            }
            catch (Exception Ex)
            {

                return false;
            }

        }
    }
}
