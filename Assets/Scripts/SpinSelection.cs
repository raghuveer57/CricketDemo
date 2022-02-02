using UnityEngine;
using UnityEngine.UI;

public class SpinSelection : MonoBehaviour
{
    private GameManager manager;
    private Text text;
    // Update is called once per frame
    public void UpdateSelection()
    {
        if (!manager.isSelectionPending)
        {
            manager.ToggleBowlingMode();
            text.text = manager.GetBowlingMode() ? "SPIN" : "FAST";
        }
    }

    private void Awake()
    {
        manager = FindObjectOfType<GameManager>();
        text = gameObject.GetComponent<Text>();
    }
}
