using UnityEngine;
using UnityEngine.UI;

public class Status : MonoBehaviour
{
    private Text text;    
    public void UpdateStatus(string status)
    {
        text.text = status;
    }

    public void AppendStatus(string status)
    {
        text.text += ("\n" + status);
    }
    private void Awake()
    {
        text = GetComponent<Text>();
    }
}
