using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    private Text tex;
    public void UpdateScore(int value, int wickets, int balls, int targetScore)
    {
        int overs = balls / 6;
        int perover = balls % 6;
        tex.text = "Score " + value + "/" + wickets + "\n" + "Overs: " + overs + "." + perover + "\n" + "Target: " + targetScore;
    }

    private void Awake()
    {
        tex = gameObject.GetComponent<Text>();
    }

}
