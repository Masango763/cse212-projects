namespace week03.code;

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

    /// <summary>
    /// Check to see if you can move left. If you can, then move. If you
    /// can't, print "Can't go that way!".
    /// </summary>
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

    /// <summary>
    /// Check to see if you can move right. If you can, then move. If you
    /// can't, print "Can't go that way!".
    /// </summary>
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

    /// <summary>
    /// Check to see if you can move up. If you can, then move. If you
    /// can't, print "Can't go that way!".
    /// </summary>
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

    /// <summary>
    /// Check to see if you can move down. If you can, then move. If you
    /// can't, print "Can't go that way!".
    /// </summary>
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
