# dotcrawler
A dungeon crawler written in C# using the .NET framework
## Sections
- Technical
  - Prerequisites
  - Run the application
  - Class overview
- Game
  - Controls
  - Game mechanics

## Technical
### Prerequisites
To run this app you need:
1. .NET SDK
2. ASP.NET Runtime
### Run the application
#### Play the game
Start the app with:
```
$ dotnet run
```
#### Create maps
First start the app with the argument `--server` / `-s`:
```
$ dotnet run -- --server
```
Then open [http://127.0.0.1:8080](http://127.0.0.1:8080) in your browser of choice.<br>
(to close the server just press CTRL+C in the terminal)
### Class overview
![](https://raw.githubusercontent.com/AstronomyOverdrive/dotcrawler/refs/heads/main/plantuml.png)

## Game
### Controls
- W/S = Move
- A/D = Turn
- E = Interact/Attack
- Q = Quit map (will void any gold collected during that run)
### Game mechanics
This is an example of how the game looks:<br>
There are two doors, one down the corridor and one to the left.<br>
The corridor continues to the right.
```
------------------------------------
|_|___|____||          ||_|___|____|
|___|___|__||==========||___|___|__|
|_|___|____||        O ||_|___|____|
|___|___|__||==========||___|___|__|
-------------          -------------
------------
|---|   |--|
|   |---|  |
|---|   |--|
|   |---|  |
------------
------------            ------------
|  ||  ||  |            |---|   |--|
|  ||()||  |            |   |---|  |
|  ||  ||  |            |---|   |--|
|  ||  ||  |            |   |---|  |
------------            ------------
------------            ------------
|---|   |--|  (Player)  |---|   |--|
```

Your goal is to collect gold and find the exit.
```
------------     ------------
|          |     |   E  E   |
|=E=X=I=T==|     |   X()X   |
|        O |     |   I  I   |
|=E=X=I=T==|     |   T  T   |
-          -     ------------
```

Gold can be found in chests.
```
              ____
  ____       /    \
 /____\      \____/
 |====|      |====|
(Closed)     (Open)
```

Or a lesser amount by defeating enemies, which is also how you regain HP.
```
 ()
/[]\
 ][
/  \
```

Gold is kept between dungeon runs as long as you don't die.
