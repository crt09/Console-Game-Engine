# Console-Game-Engine
The simple lightweight 2D framework to make games in console easier
## Getting started
### Installing
* Create a `Console App (.NET Framework)` project in your IDE
* [Download](https://github.com/crt09/Console-Game-Engine/releases) or compile the Console-Game-Engine repository
* Add references to `WindowsBase.dll` and `ConsoleGameEngine.dll`
### Creating a game
* Create main game class and inherit it from the **GameCore**:
```cs
using ConsoleGameEngine.Core.GameSystems.DefaultSystem;
or
using ConsoleGameEngine.Core.GameSystems.ECS;

// Note: see the examples below for understanding the game systems

...

class Game1 : GameCore {
  public Game1 : base(width: 32, height: 32, name: "Game1") { }
}
```
* Run game in the Program.cs:
```cs
class Program {
  [STAThread] // It's important
  static void Main(string[] args) {
    using (var game = new Game1()) {
      game.Run();
    }
  }
}
```
## Examples
### Default game system
Default system is a MonoGame-like game system
```cs
using ConsoleGameEngine.Core.GameSystems.DefaultSystem;

...

class Game1 : GameCore {
  public Game1 : base(width: 32, height: 32, name: "Game1") { }
  
    Point playerPosition;
    ConsoleTexture playerTexture;

    protected override void Initialize() {
      string[] textureData = new[] {
        " # ",
        "###",
        "# #"
      };
      playerTexture = new ConsoleTexture(3, 3);
      playerTexture.SetData(textureData);
      playerTexture.Normalize();
      base.Initialize();
    }

    protected override void Update() {
      if (Input.IsKeyDown(Key.Right)) {
        playerPosition.X++;
      } else if (Input.IsKeyDown(Key.Left)) {
        playerPosition.X--;
      }				
      base.Update();
    }

    protected override void Draw() {
      Graphics.Clear(' ');
      Graphics.Draw(playerTexture, playerPosition);
      base.Draw();
    }
}
```
### ECS game system
ECS (Entity-Component-System) is an extended Scene/Entity/Component system
```cs
using ConsoleGameEngine.Core.GameSystems.ECS;

...

class Game1 : GameCore {
  public Game1 : base(width: 32, height: 32, name: "Game1") { }
  
    Entity player;

    protected override void Initialize() {
      string[] textureData = new[] {
        " # ",
        "###",
        "# #"
      };
      var playerTexture = new ConsoleTexture(3, 3);
      playerTexture.SetData(textureData);
      playerTexture.Normalize();
      var playerSprite = new Sprite(playerTexture);

      player = new Entity();
      player.AddComponent(playerSprite);
      Scene.AddEntity(player);

      base.Initialize();
    }

    protected override void Update() {
      if (Input.IsKeyDown(Key.Right)) {
        player.Transform.Position += new Point(1, 0);
      } else if (Input.IsKeyDown(Key.Left)) {
        player.Transform.Position += new Point(-1, 0);
      }
      base.Update();
    }
}
```
