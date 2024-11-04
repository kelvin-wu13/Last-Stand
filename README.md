## About
2D Tower defense game.2 kinds of Unit and survive until the wave is finished,Collect coins to deploy unit and defeat enemy monster.Post processing included.

<tbody>
    <tr>
      <td><img src="https://github.com/kelvin-wu13/kelvin-wu13/blob/main/GIF/LastStand.gif"/></td>
    </tr>
  
<br>

## Scripts and Features
scripts:
|  Script       | Description                                                  | Development Time |
| ------------------- | ------------------------------------------------------------ | -------------- |
| `BasicShooter.cs` | Handles the animation,shoot,and takeDamage for Archer unit  | ≈ 4 hours |
| `Bullet.cs` | Handles the Damage and collider for bulelt  | ≈ 1 hours |
| `Coin.cs` | Handles coin drop and update coins to GameManager  | ≈ 4 hours |
| `CoinSpawner.cs` | Manage coin random generator on the map  | ≈ 3 hours |
| `Enemy.cs` | Handles Enemy animation,attack,stats,and walk  | ≈ 4 hours |
| `EnemySpawner.cs` | Handles random enemy spawner location | ≈ 2 hours |
| `GameManager.cs` | Manage Coins amount,buy unit,Tile to place unit  | ≈ 6 hours |
| `Monk.cs` | Handles monk unit to generate coins | ≈ 2 hours |
| `Tile.cs` | Check either the tiles have unit or not  | ≈ 4 hours |
| `Unit.cs` | Handles unit health amount,animator,unit layer,sprite for unit in tile | ≈ 5 hours |
| `UnitSlot.cs` | Handles inventory to buy unit and show amount of coins  | ≈ 4 hours |
| `etc`  | | ≈ 12 hours |

This project also uses these package:
- Universal RP

Post Processing used:
- Bloom
- Shadows
- Vignette
- Color Adjustment

The game has:
- Monk unit to generate coins
- Archer unit to shoot arrow and defeat enemy
- Monster enemy attack player unit
- Unit and monster animation
- Post Processing 

<br>

## Game controls
The following controls are bound in-game, for gameplay and testing.

| Key Binding       | Function          |
| ----------------- | ----------------- |
| Mouse1             | Deploy unit and collect coins  |

<br>

## Notes
this game is developed in **Unity Editor 2022.3.31f1**

Asset used:
- Background: https://free-game-assets.itch.io/free-elven-land-2d-battle-backgrounds
- Units: https://huberthart.itch.io/2d-character-cute-chibi-free-pack
- Enemy: https://huberthart.itch.io/2d-monster-cute-chibi-demo-pack

 
