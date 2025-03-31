# Galagsis  
## Game Project for UBC Course COSC 416  

Full Play Video on YouTube: https://youtu.be/vv7KCFuyR8E
https://github.com/user-attachments/assets/71161248-2071-4eed-9a11-1b489e63a245


### Assets  
Assets downloaded from the Unity Asset Store.

### Nariman Milanfar's Workload  

- **Importing Assets:** Player, missile, enemy, and environment scene assets.
- **Environment Setup:** Placing and configuring the environment elements.
- **Player Movement:** Basic movement and mechanic setup.  
- **Obstacle Interaction:** Handling movement limits with obstacles.  
- **Camera Settings:** Adjusting camera behavior.  
- **Player Tilt:** Tilting the player while moving.  
- **Colliders & Rigidbody:** Setting up colliders and rigid bodies for obstacles, shots, players, and enemies.   
- **Particles:** Configuring the particle system for the player’s and missile's engine, and adding particle effects upon collision with the player or player's missiles.  
- **Level Progression:** Shifting the player prefab after Level 1.  
- **Scoring System:** Implementing score counting.  
- **Health System:** Decreasing health upon damage.  
- **Lives & Levels:** Setting up 3 lives and 3 levels with state transitions, including scene images.
- **Shoot Functionality:** Implementing shooting mechanics for the player.  
- **Collision Conditions:** Handling interactions between player shots and enemies, enemies colliding with the player, and other in-game collisions.
- **Destroy Enemy & Missiles:** Removing enemies and missiles upon collision or after leaving the game area.
- **Enemy Spawning:** Spawning enemies.  
- **Enemy Movement:** Implementing enemy movement behavior.  
- **Enemy Leveling:** Configuring different enemy movement patterns and speeds per level.
- **Enemy Spawn Stop:** Stop enemy spawning after the game is over or won.  
- **Game Over & Game Won State:** Implementing conditions to determine when the game is over or won, with appropriate state transitions.

### Salma Vikha Ainindita's Workload  

- Reset/Restart Functionality (PR #1)
- Main Menu (PR #3)
- Camera Shake with level up screen (PR #10)
- Added some assets, images, and sound effects


### Madelyn DeGruchy's Workload
- **Game Timer** Added functionality for the game timer (PR #2)
- **Game Over & Game Won** Created GameOver and GameWon methods and disabled Score and Health depletion once the game ends to implement different music during each condition. (PR #8)
- **AudioManager** Created AudioManager and set up methods to play sound effects and background music (PR #8)
- **Imported Audios** Imported CC0 Background Music, Game Over music, Game Won music, and SFX for the ship engine, buttons clicking on menu screens, shooting bullets, and collisions (enemy hits player, bullet hits player, bullet destroys enemy). (PR #8)
- **Enemy Glow & Particle Circle** Added emmissive property to all enemy materials so they appear to "glow" or have lights on the wings. Also added was a particle effect to indicate where the enemy initially spawns. (PR #13)

### Lexi Loudiadis's Workload
- **Game Status UI:** Imported fonts for game status bar, made a health bar, made custom designs with Canva for UI elements such as the levels, multipliers, and 'You Win' image. (PR #5, PR #6, PR #17 + throughout other PRs)
- **Health Bar Pickups:** Imported health bar object that spawns in the place of an enemy after it has been shot. If it gets picked up, a custom designed '+10' image pops up in its place. (PR #7)
- **Score Multipliers:** Implemented x2 and x3 score multipliers that are activated after hitting consecutive enemies in a row. Custom designed 'x2' and 'x3' images pop up beside the score in the game status bar when these multipliers are active. (PR #9)
- **Scoring Systme:** Score lowers when the player misses an enemy and the enemy collides with the obstacle behind the player. (PR #14)
- **High Score Feature:** Player's high score is locally saved when playing starting from the first level. Takes into account the amount of time left as well as the score (PR #17)
