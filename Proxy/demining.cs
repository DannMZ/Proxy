using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proxy
{
    interface demining
    {
        public string demine(Point point);
    }
    public class deminer : demining
    {
        int mines_in_game=0;
        int mines_at_all;
        Point Size;
        char[][] board;
        public deminer(Point point,int mines_count) {
        Size = point;
            mines_at_all = mines_count;
        }
        public string demine(Point point)
        {
            return board[point.X][point.Y].ToString();
        }
        private void Set_Mines()
        {
            board = new char[Size.X][];
            for (int i = 0; i < Size.X; i++)
            {
                board[i] = new char[Size.Y];
                for(int j = 0; j < Size.Y; j++)
                {
                    board[i][j] = '0';
                }
            }

            while (mines_in_game < mines_at_all)
            {
                Random random = new Random();
                Point point_of_mine = new Point(random.Next(), random.Next());
                if (board[point_of_mine.X][point_of_mine.Y] != '*')
                {
                    board[point_of_mine.X][point_of_mine.Y] = '*';

                    if (point_of_mine.X != 0)
                    {
                        board[point_of_mine.X - 1][point_of_mine.Y] = Convert.ToChar(board[point_of_mine.X - 1][point_of_mine.Y] + 1);
                    }
                    if (point_of_mine.X != Size.X)
                    {
                        board[point_of_mine.X + 1][point_of_mine.Y] = Convert.ToChar(board[point_of_mine.X + 1][point_of_mine.Y] + 1);
                    }
                    if (point_of_mine.Y != 0)
                    {
                        board[point_of_mine.X][point_of_mine.Y+-1] = Convert.ToChar(board[point_of_mine.X][point_of_mine.Y-1] + 1);
                    }
                    if (point_of_mine.Y != Size.Y)
                    {
                        board[point_of_mine.X][point_of_mine.Y+1] = Convert.ToChar(board[point_of_mine.X][point_of_mine.Y+1] + 1);
                    }
                    mines_in_game++;
                }
            }
        }
    }
    public class ProxyDeminer : demining
    {
        deminer game;
        public ProxyDeminer(Point point, int mines_count) {
            game = new deminer(point, mines_count);
        }
        public string demine(Point point)
        {
            return game.demine(point);
        }
    }

}
