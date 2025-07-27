# Drag-and-Drop-Game
Unity Version
Unity 2022.3.17f1

Play Instructions
When the game starts, colored shapes (cube, sphere, capsule) will fall from the top of the screen.

Drag and drop each falling object into the matching colored bin at the bottom (e.g., red objects into the red bin).

Correctly sorting an object increases your score.

Incorrectly sorting or missing an object (letting it fall off-screen) reduces your score or lives depending on game mode.

The player has 3 lives initially. Game over occurs when lives reach zero or the score drops below zero, showing a game over screen.

Use the Restart button on the game over screen to start a new game.

Objects rotate as they fall to provide visual interest.

When an object is correctly sorted, the bin lights up briefly with a glow and particle celebration.

If an object is missed (falls below the game area), a penalty is applied by reducing the score.

Notes on Extra Implementations
Timed object cleanup: Objects have a 5-second timer after spawning; if not sorted in time, they are destroyed and the player is penalized by score reduction.

Visual feedback: Bins glow or pulse with a color effect and particle system when a correct match happens.

Score and lives UI: Real-time update of score and lives count during gameplay.

Restart functionality: The game can be restarted at any time from the game over screen.

Rotation animation: Falling objects rotate smoothly to add dynamics without bounce, as per design choice.

Robust off-screen cleanup: Objects leaving the playable area reduce score automatically.

Modular codebase: Scripts separated by function for clarity and ease of expansion.

Flexible penalty options: Support for either score-only or score+lives penalty modes.
