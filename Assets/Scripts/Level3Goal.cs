using UnityEngine;

public class Level3Goal : MonoBehaviour
{

    public GameObject SManager;
    public GameObject GManager;
    public GameObject winMessage;
    private Level3SwitchManager sCount;
    private Level3GameManager gComplete;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        SManager = GameObject.Find("SwitchManager");
        sCount = SManager.GetComponent<Level3SwitchManager>();
        GManager = GameObject.Find("GameManager");
        gComplete = GManager.GetComponent<Level3GameManager>();

        gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (sCount.totalSwitches == 3)
        {
            gameObject.SetActive(true);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "Player" && sCount.totalSwitches == 3)
        {
            gComplete.completed = true;
            winMessage.SetActive(true);
            Destroy(gameObject);
        }
    }

}
