# Escape Room — first-person starter

Open this project in Unity 6000.6.7f1, open Assets/Scenes/EscapeRoom.unity and press Play. The room and player are created at runtime; the saved scene is intentionally empty.

## Controls
- WASD: walk, with collision and gravity.
- Mouse: look around.
- E: interact with the object under the crosshair when within 2.5 metres.
- Escape: close the keypad or pause. Resume releases/recaptures the mouse appropriately.
- Door keypad: click digits or type numbers, Backspace to delete, Enter to submit.

## Puzzle
Walk to the red rug, look down and press E to slide it aside. Look at the revealed brass key and press E to collect it. Walk to the desk and interact with its drawer to unlock it and read the exit-code clue. Walk to the door or wall keypad, press E and enter the code. The door swings open; walk through it to escape. The pause and win menus offer Restart room.

The exit accepts its code even if guessed before reading the clue. No player model/arms or third-party art are included; this is a first-person character controller with a room made from placeholder geometry.

## Collaboration
Commit Assets and .meta files, Packages and ProjectSettings. Library, Temp, Logs and UserSettings are generated locally and ignored. The package lock and Unity-generated project settings are included.

## Validation
Compiled and ran in Unity 6000.6.7f1 on macOS. Verified walking, opening the door keypad by approaching the door and pressing E, incorrect-code rejection, correct-code unlock, and walking through the doorway to the win screen. The complete rug/key/drawer interaction route and standalone builds remain unverified.
