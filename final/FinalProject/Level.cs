using Raylib_cs;

public class Level
{
    List<List<int>> _levelSpace = new List<List<int>>();
    FileSystem _fileSystem = new FileSystem();

    private const int _screenWidth = 1200; 
    private const int _screenHeight = 700; 
    private const int _FPS = 60; 
    static int _blockSize = 64;

    private string _levelName;

    protected List<Entity> _entities = new List<Entity>();
    protected List<Tile> _tiles = new List<Tile>();

    Player _player = new Player(0, 0, _blockSize, _blockSize, Color.Red, 600f, -400f, 20, _screenWidth, _screenHeight);

    public Level(string levelName)
    {
        _levelName = levelName;
    }

    public void Main()
    {
        Raylib.InitWindow(_screenWidth, _screenHeight, "Survivor");
        Raylib.SetTargetFPS(_FPS);

        LoadLevel(_levelName);

        while (!Raylib.WindowShouldClose())
        {
            float dt = Raylib.GetFrameTime();

            Update(dt);

            Raylib.BeginDrawing();
            Raylib.ClearBackground(Color.White);

            Draw();

            Raylib.EndDrawing();
        }
    }

    public void Update(float dt)
    {
        foreach (Entity entity in _entities)
        {
            entity.Draw();
            entity.Move(dt, _tiles);
        }

        foreach (Tile tile in _tiles)
        {
            tile.Update(dt);
        }
    }

    public void Draw()
    {
        foreach (Tile tile in _tiles)
        {
            tile.Draw();
        }

        foreach (Entity entity in _entities)
        {
            entity.Draw();
        }
    }

    public void LoadLevel(string levelName)
    {
        _levelSpace = _fileSystem.GetFile(levelName);
        if (_levelSpace.Count == 0) Console.WriteLine("The list is empty!");
        for (int i = 0; i < _levelSpace.Count; i++)
        {
            for (int j = 0; j < _levelSpace[i].Count; j++)
            {
                if (_levelSpace[i][j] == 1)
                {
                    _player._rect.X = j * _blockSize;
                    _player._rect.Y = i * _blockSize;
                    _entities.Add(_player);
                }
                else if (_levelSpace[i][j] == 2)
                {
                    Stone stone = new Stone(j * _blockSize, i * _blockSize, _blockSize, _blockSize, Color.Gray);
                    Console.WriteLine(_levelSpace[i][j]);
                    _tiles.Add(stone);
                }
            }
        }
    }
}