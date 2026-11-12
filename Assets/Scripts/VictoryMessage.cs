    using UnityEngine;

public class VictoryMessage : MonoBehaviour
{

    public GameObject GManager;
    private Level3GameManager gComplete;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        GManager = GameObject.Find("GameManager");
        gComplete = GManager.GetComponent<Level3GameManager>();

        gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (gComplete.completed == true)
        {
            gameObject.SetActive(true);
        }
    }
}
