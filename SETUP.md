# Escape Room — Unity starter

This is a new starter project, not a completed game. It contains a small placeholder room and a point-and-click puzzle: find the key under the rug, open the desk drawer, then enter its code on the exit keypad.

## Open and play
1. Install Unity Hub and Unity Editor 6000.6.7f1 (Unity 6).
2. Clone or download this repository.
3. In Unity Hub, choose Add project from disk and select the repository folder (the folder containing Assets, Packages and ProjectSettings).
4. Allow Unity to import the project and generate its default settings.
5. Open Assets/Scenes/EscapeRoom.unity and press Play.

The room is created by EscapeRoomGame.cs when Play starts, so the saved scene is intentionally empty. Use File > Build Profiles to build for your installed target platform; the scene is included in the build settings.

## Collaboration
Commit Assets (including .meta files), Packages and ProjectSettings. The repository includes Unity-generated project settings and the package lock file. Commit any changes to these after editing. Library, Temp, Logs and user settings are ignored because Unity recreates them.

No downloaded models, textures or third-party assets are included. All room objects use Unity primitives.

## Validation
Imported and compiled in Unity 6000.6.7f1 on macOS. Opened EscapeRoom.unity and confirmed the room and puzzle interface run in Play mode. The complete puzzle interaction sequence and standalone builds have not been verified.
