# TargetVisibilitySystem

This project is just a sample of my code.

The principle of its operation is very simple:
- If the creature is invisible to the player, it disappears from the player's line of sight and vice versa.
- If for any reason its visibility is limited (for example, it is in dense vegetation) then the object enters the obscured state, which means that only the banner above its head will disappear (a marker assigned to the creature, defining its faction and attitude towards the player). Banner's disappearance is initiated by an animation.

Move the wall between the creatures and the player to make them invisible to the player.
To switch to the obscured state, turn on/off the "Is Obscured" checkbox on the chosen creatures (WIP).

Unity 2021.3.7f1
