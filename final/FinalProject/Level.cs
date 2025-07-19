using System;
using System.Numerics;               
using Raylib_cs;
using RayRectangle = Raylib_cs.Rectangle;

public class Level
{

    public Level(string levelName, int screenWidth, int screenHeight)
    {
        _levelName = levelName;
        _screenWidth = screenWidth;
        _screenHeight = screenHeight;

        LoadLevel(_levelName);
    }
    List<List<int>> _levelSpace = new List<List<int>>();
    FileSystem _fileSystem = new FileSystem();

    private float _bulletTimer = 2f;

    static int _screenWidth = 1200;
    static int _screenHeight = 700;
    private const int _FPS = 60;
    static int _blockSize = 64;

    private bool _gameWon = false;
    private bool _playerIsDead = false;

    private string _levelName;

    protected List<Entity> _entities = new List<Entity>();
    protected List<Tile> _tiles = new List<Tile>();

    static Player _player = new Player(0, 0, _blockSize, _blockSize, Color.Blue, "player", 700f, -700f, 4, _screenWidth, _screenHeight);
    private Gun _gun;

    private List<Bullet> _bullets = new List<Bullet>();

    Camera2D cam = new()
    {
        Offset = new Vector2(_screenWidth / 2f - _player._rect.Width / 2f, _screenHeight / 2f - _player._rect.Height / 2f),
        Rotation = 0,
        Zoom = 1f
    };



    public void Main()
    {
        float dt = Raylib.GetFrameTime();

        Update(dt);

        cam.Target = new Vector2(_player._rect.X + _player._rect.Width / 2f, _player._rect.Y + _player._rect.Height / 2f);

        Raylib.ClearBackground(Color.White);

        Raylib.DrawText($"Health: {_player.GetHealth()}", 10, 10, 30, Color.Black);

        Raylib.BeginMode2D(cam);
        Draw();
        Raylib.EndMode2D();

    }

    public void Update(float dt)
    {
        _player.DamageByEnemy(_entities);
        CreateBullets(dt);
        DestroyBullets();
        BulletCollisions();
        _player.HasWon(_tiles);
        SetPlayerIsDead();

        for (int i = 0; i <= _entities.Count() - 1; i++)
        {
            _entities[i].Update(dt);
            _entities[i].Move(dt, _tiles);

            if (_entities[i].IsDead())
            {
                _entities.RemoveAt(i);
            }


        }

        foreach (Bullet bullet in _bullets)
        {
            bullet.Update(dt);
        }

        foreach (Tile tile in _tiles)
        {
            tile.Update(dt);
            if (tile.GetType() == "winBlock")
            {
                if (tile.GetTrigger())
                {
                    _gameWon = true;
                }
                else
                {
                    _gameWon = false;
                }
            }
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



        _gun.Draw(_player);

        foreach (Bullet bullet in _bullets)
        {
            bullet.Draw(_gun);
        }
    }

    public void CreateBullets(float dt)
    {
        _bulletTimer += dt;
        if (Raylib.IsKeyDown(KeyboardKey.Space) && _bulletTimer >= .5f)
        {
            Bullet bullet = new Bullet(0, 0, 8, 8, 1, 8, _gun);
            _bullets.Add(bullet);
            _bulletTimer = 0;
        }

    }

    public void BulletCollisions()
    {
        foreach (Tile tile in _tiles)
        {
            for (int i = 0; i <= _bullets.Count() - 1; i++)
            {
                if (Raylib.CheckCollisionCircleRec(new Vector2(_bullets[i].GetRect().X + _bullets[i].GetRect().Width / 2f, _bullets[i].GetRect().Y + _bullets[i].GetRect().Height / 2f), _bullets[i].GetRect().Width / 2f, tile.GetRect()))
                {
                    _bullets.RemoveAt(i);
                }
            }
        }

        for (int i = 0; i <= _entities.Count() - 1; i++)
        {
            if (_entities[i].GetType() == "enemy")
            {
                _entities[i].BulletCollisions(_bullets);
            }
        }
    }

    public void DestroyBullets()
    {
        for (int i = 0; i <= _bullets.Count() - 1; i++)
        {
            if (_bullets[i].GetTimer() >= 1.5f)
            {
                _bullets.RemoveAt(i);
            }
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
                    Stone stone = new Stone(j * _blockSize, i * _blockSize, _blockSize, _blockSize, Color.Gray, "stone");
                    _tiles.Add(stone);
                }
                else if (_levelSpace[i][j] == 3)
                {
                    Enemy enemy = new Enemy(j * _blockSize, i * _blockSize, _blockSize, _blockSize, Color.Red, "enemy", 400f, -700f, 3, _screenWidth, _screenHeight);
                    _entities.Add(enemy);
                }
                else if (_levelSpace[i][j] == 4)
                {
                    WinBlock winBlock = new WinBlock(j * _blockSize, i * _blockSize, _blockSize, _blockSize, Color.Yellow, "winBlock");
                    _tiles.Add(winBlock);
                }
                _gun = new Gun(_player._rect.X + _player._rect.Width - 16, _player.GetRect().Y + 20, 54, 16, 1);
            }
        }
    }

    public void SetPlayerIsDead()
    {
        if (_player.GetHealth() <= 0 || _player.GetRect().Y >= 3500)
        {
            _playerIsDead = true;
        }
    }

    public bool GameWon()
    {
        return _gameWon;
    }

    public bool PlayerDead()
    {
        return _playerIsDead;
    }

    public void Reset()
    {
        _gameWon = false;
        _playerIsDead = false;
        _entities.Clear();
        _tiles.Clear();
        _player.ResetHealth();
        LoadLevel(_levelName);
    }

}