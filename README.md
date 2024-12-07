https://github.com/user-attachments/assets/3589a3da-f2b4-4b13-90a9-c658798a948c

Mini-Project

Project Name: Zombie Blaster
Name: Mathias Kofoed Hansen

Overview of the Game:
The project’s concept takes inspiration from Call of Duty Zombies, with movement and run and gun shooting more akin to the newer Wolfenstein games. The player is constantly ambushed and rushed by zombies, which spawn in increasing number as the player gets through the waves of zombies. The goal of the game is to survive as long as possible. 

The main parts of the game are:
-	Player: Controlled with WASD in classic FPS style
-	Camera: Controlled with the mouse, again in classic FPS style
-	Enemies: Zombies spawn continuously and constantly try to run towards the player and kill them
-	Shooting: The player can shoot the zombies to kill them, which is the bulk of the gameplay loop
Game features:
-	Each time the player kills a wave of zombies, more spawn in the next wave than the one before, increasing the difficulty as the game goes on.
-	Zombies spawn in random locations each time, improving replayability.
How were the Different Parts of the Course Utilized:
-	The game uses Unity’s character controller as well as camera functionality to handle player inputs, moving the character and rotating the camera. 
-	The zombies in the game utilize Unity’s randomization features combined with NavMesh AI navigation to spawn into the game and follow the player around the level seamlessly, avoiding the level’s obstacles. 
-	Level design and implementation was performed using ProBuilder. 
-	Interactions between the player and zombies are performed through the use of colliders and rigidbodies, which provide the game with the tools to move characters through physics when they hit each other, as well as enabling scripts to perform actions when this happens. 
-	Models imported from Mixamo with animations were used and altered to fit the game’s needs. For this purpose, Unity’s animator and animator controller were used. This includes modifying the player character’s animation to fit the way the player’s experience should be, while the zombies’ animations were largely used as received from Mixamo
-	Unity’s built-in options for lighting effects as well as visual effects were used to create a muzzle flash, which also used randomness to provide realistic differences between each shot.
-	Unity’s ragdoll system was used on the zombie models imported from Mixamo to provide ragdoll effect on the zombie’s when they died.
-	Raycasting was used to make the game’s shooting mechanics, which was developed through the PlayerShooting script.

Project Parts:
-	Scripts:
  
o	PlayerMovement: Handles player movement as well as some general logic regarding the player

o	PlayerShooting: Handles the shooting mechanics and logic possessed and used by the player. This is mostly done through the use of raycasting, which enables the script to gauge whether or not the player hits anything with their shots and apply damage accordingly.

o	CameraController: Handles logic concerning camera rotation

o	EnemyManager: Handles the spawning and death logic of the enemy zombies

o	AIEnemy: Handles movement and logic concerning each individual zombie instance

•	Models & Prefabs:

o	Models and animations downloaded from www.mixamo.com 

o	Model used for the player character’s weapons downloaded from Unity Asset Store

•	Materials:

o	Materials from Unity Asset Store used in most objects

	https://assetstore.unity.com/packages/2d/textures-materials/pbr-materials-sampler-pack-40112 

	https://assetstore.unity.com/packages/2d/textures-materials/concrete/yughues-free-concrete-materials-12951 

	https://assetstore.unity.com/packages/3d/props/guns/modern-russian-assault-rifle-46033 

•	Visual effects:

o	Unity’s visual effects graphs and lighting options were used to make the muzzle flash when shooting. This also included the use of randomization within the visual effect graph to provide differences in each muzzle flash, making them more realistic. Additionally, point lights were used to simulate the actual light emitted by each muzzle flash. 

•	Other Unity components/features

o	NavMesh: Navmesh was used for the AI navigation and placement of the randomly spawned zombies in the game level

o	RIgidbody: Used for registering the collisions between the player character and zombies to enable the player to take damage through scripting when this happened.

o	Character Controller: The character controller was used to handle all movement of the player character within the game level.

o	Ragdoll: Unity’s ragdoll system was used to make ragdolls from the zombie’s models, which was then triggered when they were killed

•	Scenes:

o	The game consists of one scene

•	Testing:

o	The game was tested on Windows.


Used Resources
•	Gemini, used for coding help  

https://gemini.google.com/ 

•	Getting Mixamo and Unity to work

https://discussions.unity.com/t/how-to-getting-mixamo-and-unity-to-work/715933

•	How to make a muzzle flash

https://www.youtube.com/watch?v=EiDxxH9wdq0 
