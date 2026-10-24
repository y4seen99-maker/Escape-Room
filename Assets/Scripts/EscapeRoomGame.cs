using UnityEngine;

// A self-contained starter puzzle. Replace the placeholder room as the project grows.
public sealed class EscapeRoomGame : MonoBehaviour
{
    bool key, drawer, escaped;
    string code = "";
    string message = "Find a key, inspect the room, then unlock the exit.";

    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.AfterSceneLoad)]
    static void StartGame()
    {
        if (Object.FindFirstObjectByType<EscapeRoomGame>() == null)
            new GameObject("Escape Room Game").AddComponent<EscapeRoomGame>();
    }

    void Awake()
    {
        var cameraObject = new GameObject("Room Camera");
        var camera = cameraObject.AddComponent<Camera>();
        camera.transform.position = new Vector3(0, 5, -8);
        camera.transform.LookAt(new Vector3(0, 1, 1));
        camera.backgroundColor = new Color(0.06f, 0.08f, 0.12f);
        camera.clearFlags = CameraClearFlags.SolidColor;
        var light = new GameObject("Room Light").AddComponent<Light>();
        light.type = LightType.Directional;
        light.transform.rotation = Quaternion.Euler(45, -30, 0);
        Box("Floor", new Vector3(0, -0.1f, 1), new Vector3(8, .2f, 7), Color.gray);
        Box("Back Wall", new Vector3(0, 1.5f, 4), new Vector3(8, 3, .2f), Color.gray);
        Box("Exit Door", new Vector3(2, 1.2f, 3.8f), new Vector3(1.5f, 2.4f, .25f), new Color(.3f, .15f, .06f));
        Box("Desk", new Vector3(-2, .6f, 2), new Vector3(2, 1.2f, 1), new Color(.45f, .25f, .1f));
    }

    static void Box(string name, Vector3 position, Vector3 scale, Color color)
    {
        var box = GameObject.CreatePrimitive(PrimitiveType.Cube);
        box.name = name;
        box.transform.position = position;
        box.transform.localScale = scale;
        box.GetComponent<Renderer>().material.color = color;
    }

    void OnGUI()
    {
        float width = Mathf.Min(460, Screen.width - 24);
        GUILayout.BeginArea(new Rect(12, 12, width, Screen.height - 24), GUI.skin.box);
        GUILayout.Label(escaped ? "YOU ESCAPED!" : "ESCAPE ROOM");
        GUILayout.Label(message);
        if (!escaped)
        {
            if (GUILayout.Button("Inspect under the rug"))
            {
                key = true;
                message = "You found a small key.";
            }
            if (GUILayout.Button("Open the desk drawer"))
            {
                if (key) { drawer = true; message = "A note reads: the exit code is 2148."; }
                else message = "The drawer is locked. Find its key.";
            }
            GUILayout.Label("Exit keypad");
            code = GUILayout.TextField(code, 4);
            if (GUILayout.Button("Unlock exit"))
            {
                escaped = drawer && code == "2148";
                message = escaped ? "The door opens. Well done!" : "The door stays locked. Search for a clue.";
            }
        }
        if (GUILayout.Button("Restart puzzle"))
        {
            key = drawer = escaped = false;
            code = "";
            message = "Find a key, inspect the room, then unlock the exit.";
        }
        GUILayout.EndArea();
    }
}
