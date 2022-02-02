using UnityEngine;

public class RunSelection : MonoBehaviour
{
    private GameManager manager;
    private void Awake()
    {
        manager = FindObjectOfType<GameManager>();
    }
    public void Enable()
    {
        gameObject.SetActive(true);
    }

    public void Disable()
    {
        gameObject.SetActive(false);
    }
}
