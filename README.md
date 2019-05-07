# Console-Game-Engine
The simple lightweight 2D framework to make console games easier
## Getting started
### Install
* Create a `Console App (.NET Framework)` project in your IDE
* [Download](https://github.com/crt09/Console-Game-Engine/releases) or compile the Console-Game-Engine repository
* Add references to the `WindowsBase.dll` and `ConsoleGameEngine.dll` assemblies
### First step
* Create a main game class and inherit it from the **GameCore** class:
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
* Run the game from **Program.cs**:
```cs
class Program {
  [STAThread] // That's important
  static void Main(string[] args) {
    var game = new Game1();
    game.Run();
  }
}
```
## Examples
### Default game system
The default system is a MonoGame-like game system
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
      playerTexture = new ConsoleTexture(textureData);
      playerTexture.Normalize();
      
      base.Initialize();
    }

    protected override void Update() {
      if (Input.IsKeyDown(Key.Right)) {
        playerPosition.X++;
      }
      if (Input.IsKeyDown(Key.Left)) {
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
The ECS (Entity-Component-System) is an extended game system with greater flexibility
```cs
using ConsoleGameEngine.Core.GameSystems.ECS;

...

class Game1 : GameCore {
  public Game1 : base(width: 32, height: 32, name: "Game1") { }
  
    Entity player;

    protected override void Initialize() {
      player = new Entity();
      Scene.AddEntity(player);
      
      string[] textureData = new[] {
        " # ",
        "###",
        "# #"
      };
      var playerTexture = new ConsoleTexture(textureData);
      playerTexture.Normalize();
      var playerSprite = new Sprite(playerTexture);      
      player.AddComponent(playerSprite);      

      base.Initialize();
    }

    protected override void Update() {
      if (Input.IsKeyDown(Key.Right)) {
        player.Transform.Position += new Point(1, 0);
      }
      if (Input.IsKeyDown(Key.Left)) {
        player.Transform.Position += new Point(-1, 0);
      }
      
      base.Update();
    }
}
```
