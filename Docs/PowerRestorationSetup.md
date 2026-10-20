# Yaseen's puzzle and level design — Power Restoration

## Goal
Build a small electrical maintenance room with **three wall switches** and a **locked security door**. Players discover a clue that hints at the correct switch order. Switches must be activated in the correct sequence; an incorrect press resets progress.

This is a **working C# starter**, not a finished Unity scene. Unity scene objects and art must be created in the Editor.

## Scene layout (simple, achievable version)
1. Create a new **3D** Unity project with **Unity 6000.3.19f1**.
2. Make a floor Cube scaled to `(12, 0.5, 10)`. Add four wall Cubes around its perimeter.
3. Create an empty GameObject called `PowerPuzzleManager`, and add `PowerSequencePuzzle`.
4. Create three wall-mounted Cubes named `Switch_A`, `Switch_B`, `Switch_C`. Give each a collider and `PowerSwitch` component. Optional: child mesh with a coloured indicator Renderer.
5. Create a `DoorHinge` GameObject positioned on the hinge side of the doorway. Add `SecurityDoor` to `DoorHinge`. Put the door mesh and collider beneath it as children, offset so the pivot rotates like a real hinged door.
6. Add a camera and player controller of your choice. Put `PlayerSwitchInteractor` on the player object; drag the camera into its **Player Camera** field. In **Edit > Project Settings > Player > Active Input Handling**, choose **Both** (or **Input Manager (Old)**).
7. On each `PowerSwitch`, drag `PowerPuzzleManager` into its **Puzzle** field. Assign each switch's indicator Renderer if present.
8. On `PowerPuzzleManager`, set Switches size to **3** and drag Switch B to element 0, Switch A to element 1, Switch C to element 2. Drag `DoorHinge` into **Security Door**.
9. Add a clue on the wall: **"The emergency protocol: BLUE → RED → GREEN"**. Label Switch B blue, Switch A red and Switch C green. These are clue colours; the active indicator colour can be green.
10. Enter Play mode. Stand within three metres, look at switches and press **E**.

## Expected behaviour
- B → A → C: the door unlocks and smoothly swings open.
- A first, or another incorrect switch at any step: all switch indicators reset.
- Additional presses after success do not reset the solved puzzle.
- The Console displays progress messages to help testing.

## Team integration
- Keep this feature in a separate branch and merge through a pull request.
- For scene-level integration, save the room to `Assets/Scenes/PowerRestoration.unity`, then commit the generated `.unity` and `.meta` files.
-
- Optional later upgrades: an interact prompt UI, sound cues, lights that turn on as power returns, and a keypad for a second puzzle.

## Testing checklist
- [ ] Correct switch order opens the door
- [ ] Wrong switch order resets the puzzle
- [ ] Player cannot activate switches outside interaction range
- [ ] Unity Console has no red errors
- [ ] Entire scene loads after cloning the repository
