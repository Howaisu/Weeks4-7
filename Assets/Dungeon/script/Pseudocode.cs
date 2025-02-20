////////////////////////READ ONLY/////////////////////////////////////////
///


/*
 * Pseudocode

----------Player Controller---------------------
playerMove() 
The player can choose from three paths in the game: top, middle, and bottom, each assigned a code (0, 1, 2). 
Players input their current number using key codes; pressing up decreases the code by 1 (-1), pressing down increases it by 1 (+1). 
Any number less than 0 defaults to 0, and any number greater than 2 defaults to 2.


attack()
When the player is within a short distance from an obstacle (distance < 20f),
pressing a key can destroy the obstacle.
<A specific obstacle, like vines, will be added to this function later>


--------------Collision Checker-------------------
 Components: Monster, Player, Loot, Arrow, Knives Values: Health, Score
lootCheck()
When the player's sprite renderer is nearly at a zero distance from an object, the player scores points.

ArrowCheck()
When the player's sprite renderer is nearly at a zero distance from an object (arrow), it causes damage.

KnivesCheck() 
When the player's sprite renderer is nearly at a zero distance from an object (knives), it causes damage.

Status()
This is essentially equivalent to health points, but the display is determined by the distance from the monster. 
<I am considering placing the monster's asset on a slider to create a UI that displays the distance to the player.>
The closer the monster gets to the player, as the player takes more hits,
the monster follows the player closely when only one hit point remains; one more hit results in game over.

----------------Hazard Controller----------------------
respawn()
Hazards are spawned at various screen locations through random numbers.

arrowMove()
Component: Arrow If it doesn't contact the player, it moves from the right side of the screen to the left and disappears.

knivesMove() 
It extends horizontally and blocks one or two of the player's paths.
If it does not contact the player, it retracts and disappears after a set time (about 5 seconds); 
otherwise, it disappears immediately (current plan).

boxMove()
A box appears on the road, blocking the player's movement (temporarily shifts the player a
long with the box's x-axis, timer starts) until the player moves in another direction (timer 
stops). If the timer reaches 2 seconds, it deducts one health point from the player.

warning() 
The goal is to create a warning effect that alerts the player before a hazard appears,
using opacity changes to achieve blinking: a red sprite appears horizontally or vertically,
depending on the hazard, and aligns with the hazard's x or y axis. A counter value is used 
to track the number of appearances, then an animation curve for opacity runs inside a for-loop; 
each execution resets t to zero until the counter (usually 3 times) is reached.

------------Other Aesthetic Effects---------------

Effects like the road continuously extending to the right. Several sprite sections connect and
then move leftward, deleting at a set position. Random generation of grass at certain locations.


 */




