using System.Collections.Generic;

/// <summary>
/// Defines a maze using a dictionary.
/// </summary>
public class Maze
{
    private readonly Dictionary<(int, int), bool[]> _maze;
    private int _x = 1;
    private int _y = 1;

    public Maze(Dictionary<(int, int), bool[]> maze)
    {
        _maze = maze;
    }

    public void MoveLeft()
    {
        var currPos = (_x, _y);
        if (_maze.TryGetValue(currPos, out var directions) && directions[0])
        {
            _x -= 1;
        }
        else
        {
            System.Console.WriteLine("Can't go that way!");
        }
    }

    public void MoveRight()
    {
        var currPos = (_x, _y);
        if (_maze.TryGetValue(currPos, out var directions) && directions[1])
        {
            _x += 1;
        }
        else
        {
            System.Console.WriteLine("Can't go that way!");
        }
    }

    public void MoveUp()
    {
        var currPos = (_x, _y);
        if (_maze.TryGetValue(currPos, out var directions) && directions[2])
        {
            _y -= 1;
        }
        else
        {
            System.Console.WriteLine("Can't go that way!");
        }
    }

    public void MoveDown()
    {
        var currPos = (_x, _y);
        if (_maze.TryGetValue(currPos, out var directions) && directions[3])
        {
            _y += 1;
        }
        else
        {
            System.Console.WriteLine("Can't go that way!");
        }
    }

    public string GetStatus()
    {
        return $"Current location (x={_x}, y={_y})";
    }
}
