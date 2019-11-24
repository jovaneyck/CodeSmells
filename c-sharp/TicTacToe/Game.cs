using System;
using System.Linq;
using System.Collections.Generic;

namespace TicTacToe
{
    public class Tile
    {
        public char Symbol {get; set;}
        public Location Location { get; set; }
    }

    public class Board
    {
       private List<Tile> _plays = new List<Tile>();
       
        public Board()
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    _plays.Add(new Tile{ Location = new Location(i,j), Symbol = ' '});
                }  
            }       
        }

        public Tile TileAt(Location location)
       {
           return _plays.Single(tile => tile.Location.Equals(location));
       }

       public void AddTileAt(char symbol, Location location)
       {
           TileAt(location).Symbol = symbol;
       }
    }

    public class Location
    {
        private readonly int _x;
        private readonly int _y;

        public Location(int x, int y)
        {
            _x = x;
            _y = y;
        }

        protected bool Equals(Location other)
        {
            return _x == other._x && _y == other._y;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Location) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return (_x * 397) ^ _y;
            }
        }
    }

    public class Game
    {
        private char _lastSymbol = ' ';
        private Board _board = new Board();

        public void Play(char symbol, Location location)
        {
            //if first move
            if (_lastSymbol == ' ')
            {
                //if player is X
                if (symbol == 'O')
                {
                    throw new Exception("Invalid first player");
                }
            }
            //if not first move but player repeated
            else if (symbol == _lastSymbol)
            {
                throw new Exception("Invalid next player");
            }
            //if not first move but play on an already played tile
            else if (_board.TileAt(location).Symbol != ' ')
            {
                throw new Exception("Invalid position");
            }

            // update game state
            _lastSymbol = symbol;
            _board.AddTileAt(symbol, location);
        }

        public char Winner()
        {   //if the positions in first row are taken
            if(_board.TileAt(new Location(0, 0)).Symbol != ' ' &&
               _board.TileAt(new Location(0, 1)).Symbol != ' ' &&
               _board.TileAt(new Location(0, 2)).Symbol != ' ')
               {
                    //if first row is full with same symbol
                    if (_board.TileAt(new Location(0, 0)).Symbol == 
                        _board.TileAt(new Location(0, 1)).Symbol &&
                        _board.TileAt(new Location(0, 2)).Symbol == 
                        _board.TileAt(new Location(0, 1)).Symbol )
                        {
                            return _board.TileAt(new Location(0, 0)).Symbol;
                        }
               }
                
             //if the positions in first row are taken
             if(_board.TileAt(new Location(1, 0)).Symbol != ' ' &&
                _board.TileAt(new Location(1, 1)).Symbol != ' ' &&
                _board.TileAt(new Location(1, 2)).Symbol != ' ')
                {
                    //if middle row is full with same symbol
                    if (_board.TileAt(new Location(1, 0)).Symbol == 
                        _board.TileAt(new Location(1, 1)).Symbol &&
                        _board.TileAt(new Location(1, 2)).Symbol == 
                        _board.TileAt(new Location(1, 1)).Symbol)
                        {
                            return _board.TileAt(new Location(1, 0)).Symbol;
                        }
                }

            //if the positions in first row are taken
             if(_board.TileAt(new Location(2, 0)).Symbol != ' ' &&
                _board.TileAt(new Location(2, 1)).Symbol != ' ' &&
                _board.TileAt(new Location(2, 2)).Symbol != ' ')
                {
                    //if middle row is full with same symbol
                    if (_board.TileAt(new Location(2, 0)).Symbol == 
                        _board.TileAt(new Location(2, 1)).Symbol &&
                        _board.TileAt(new Location(2, 2)).Symbol == 
                        _board.TileAt(new Location(2, 1)).Symbol)
                        {
                            return _board.TileAt(new Location(2, 0)).Symbol;
                        }
                }

            return ' ';
        }
    }
}