# GE2-Assignment
# Final project:

Video:

[![YouTube](https://img.youtube.com/vi/icx3BPPs_5c/0.jpg)](https://www.youtube.com/watch?v=icx3BPPs_5c)

The story is about Kerr - a rebel who has secured Queen execution orders from the Empire. He must deliver the message to the General, so that the rescue is organised to save the Queen as nobody knows she is in peril.

### Scene 1:
Scene starts by looking at Kerr leaving the planet. An story intro monologue is told to the viewer by Kerr. From there Hyperdrive activates and Kerr leaves the planet behind.

### Scene 2: 
It appears that Kerr was followed by 2 Tie Fighters who exit the hyperdrive and chase Kerr. Using swift movements, Kerr manages to avoid the fire and enters a field of asteroids. One enemy crashes into an asteroid, while the other closely chases Kerr and doesn't stop for a second. As the distance closes in, a rebel ship appears behind the Tie Fighter and shoots it down. It turns out his name is Don, and he asks Kerr to help him as there is a Star Destroyer nearby and rebels are shot down in all out battle. Kerr decides to help and follows Don.

### Scene 3:
Kerr and Don look around and there is mayhem everywhere. Projectiles are flying around them and ships are shot down. Don tells Kerr that they need to destroy the spherical radio transmitter on top of the Star Destroyer Ship to disable the communication between it and Tie fighters. On the way to transmitter, they fight off the enemies. Once at the transmitter, they coordinate the attack and destroy it. Shortly after the Star Destroyer flies away in hyperspeed as they cannot continue combat without communication. Don thanks Kerr who shortly after flies off to finish his mission, and deliver the execution orders to the General. 

### Scene 4:
A brief black screen ending scene with subtitles telling the viewer about the success of Kerr's mission before the end.

---
## Modified course behaviours:

- Pursuit
- Offset Pursuit
- Path Follow
- Seek
- Arrive

## Custom Behaviours:

- GoToTarget: Finds all target entities in a radius and goes to the closest target. 

## Custom Classes

- AsteroidManager - Creates a random field of asteroids within a specified radius of a sphere from prefabs.
- CollisionManager - Manages the chain of events when an object collided with another (eg. Destruction, followed by sound, followed by particle explosion)
- MusicManager - Manages the track list of the background music.
- StarParticles - Creates a particle effect attached to camera, that helps to make a visual impression of movement in space. (Followed tutorial at https://www.youtube.com/watch?v=YuPEmRXtwIg)
- EnemySpawner - Much like Asteroid Manager, creates a specified amount of Enemies with preset behaviours to start combat when scene goes live.
- SceneManager - Holds and manages children objects as scenes based on their SceneStatus.
- Turret - Shoots a prefab at the target from specified guns on the ship. (x-wing has 4, tie fighter 2)
- Laser - the "bullet" class.
- SelfDestruct - For scripting purposes, some ships blow up at a specified time, so that they can be seen by the viewer instead of somewhere out of camera frame.

Note: EnemySpawner was disabled in the Demo, the models are very detailed and the scale of the area was too large to even see the ships in the background. Too much lag when 500 ships were in scene on a higher end PC.

## Waypoint Trigger Classes:

- WarpController - Controls at what waypoint the warp visual and particle system is enabled.
- WarpLeave - Controls the boid properties at a waypoint such as speed and force when "leaving" warp (sudden slow effect).
- BoidModifier - Adjust boid properties at a waypoint.
- PathFollowEnable - Enables Path Following at a waypoint.
- SceneStatus - Switches to next scene at a waypoint.

## Camera Classes:

- CameraController - A single instance per scene, Contains a list of Camera Objects and switches them based on current waypoint of protagonist.
- CameraOptions - Each Camera object has this script to activate things like Following a target, moving towards the target, letting manager know to switch to next camera.
- FollowObject - Enables the camera to leave its initial position and catch up to the object, then attach to it.

## Text Narrative Classes:

- TextManager - A singleton responsible for writing text on specified text field. (Used bits from this tutorial: https://www.youtube.com/watch?v=ZVh4nH8Mayg)
- TextPlayer - A container which uses coroutines to display subtitles at specified time using TextManager

## 3D Models

- X-Wing: https://www.cgtrader.com/free-3d-models/space/spaceship/star-wars-t-65
- Tie Fighter: https://www.cgtrader.com/free-3d-models/space/spaceship/star-wars-7af15e6a-7b88-4ed7-8555-bf67fe170589
- Star Destroyer: https://www.cgtrader.com/free-3d-models/aircraft/military/star-wars-victory-class-2-star-destroyer

---
---
---
---
---
---
---
---

# Initial idea:
## Space Battle
(**Note:** Currently Star Wars models are used, but might change later in the development since Star Wars franchise is "overdone to death". )

The battle is not necessarily from any movies, it is a fictional battle where the good faction's space ship is carrying a valuable message disk stolen from the enemy faction's messenger (because the speed of light is very slow when it comes to transmitting information between different galaxies, a message disk must be carried by the messenger to the other galaxy using hyperspeed quantum travel). It is said that the message is an execution order of the good faction's most valuable royal member who is held captive by the enemy in the destination galaxy.


### Scene 1:
The protagonist ship carrying the message receives an emergency signal from nearby and leaves the hyperspeed travel. It turns out the enemy was chasing it all along and so it is being pursued through an asteroid field. The main protagonist uses his agility to avoid the obstacles while the enemy crashes into one of the slowly turning asteroids.

**Behaviours used:**

- Protagonist Ship: Path Following, Obstacle avoidance behaviour
- Enemy: Path Following into an asteroid


### Scene 2:
The asteroid field is behind. Now the protagonist faces a bigger challenge. The emergency transmission that he received was due to the battle between the two factions taking place nearby. While the current odds look promising, the enemy mothership dispatches more enemies, making the battle almost one sided in enemy's favour. The two factions commit to a fierce space combat. The protagonist must now choose whether to keep going and deliver the message or to help his brothers in combat using his supernatural agility and talent. The protagonist decides to help.

**Behaviours used:**

- Protagonist Ship: Path Following, Shooting nearby enemies on the path
- Good Faction Ships: Enemy Seeking and Combat
- Enemy Faction Ships: Enemy Seeking and Combat
- Mothership: Release new enemy units periodically (Ships are in formation).

### Scene 3: 
The protagonist creates a window of opportunity by destroying enemies around it, then proceeds to fly towards the mothership's weak spot - the command bridge. As he approaches closer to the mothership, the energy shields protecting it no longer can defend it as the bridge is in close range and the action takes place within the shield's ineffective range. The protagonist fires a heavy missile towards it quickly turning doing a U-turn and escaping the blast radius.

**Behaviours used:**
- Protagonist Ship: Path Following, Missile launching towards the target.
- Mothership: Explosion and destruction upon receiving a hit.

### Scene 4:
The protagonist helps others finish off the remaining forces, once that is done he enters the hyperspeed and leaves to destroy the message.

**Behaviours used:**
- Protagonist Ship: Enemy Seeking and Combat, Path Following after
- Good Faction Ships: Enemy Seeking and Combat
- Enemy Faction Ships: Enemy Seeking and Combat

## Cameras:
Third person protagonist
Third person missile hitting mothership
Overall Battle camera as seen from above

