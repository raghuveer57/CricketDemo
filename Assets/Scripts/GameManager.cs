using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private int score;
    private int balls;
    private bool isSpin;
    [HideInInspector]
    public bool isSelectionPending;
    private const int TARGET_SCORE = 30;
    private int wickets;
    private bool isWon;
    private bool isEndGame;
    private Score scoretext;
    private Status status;
    private RunSelection runsSelection;
    private int randomNumber;

    //probabilties for the outcomes 
    Dictionary<int,int> successProbabiltyMap =
        new Dictionary<int,int>
        {
            { 0, 90 },
            { 1, 85 },
            { 2, 60 },
            { 4, 35 },
            { 6, 20 }
        };

    // Additional info which was added to make the
    // probabilty of getting out more intersting
    Dictionary<int, int> outProbabiltyMap =
        new Dictionary<int, int>
        {
            { 0, 98 },
            { 1, 95 },
            { 2, 92 },
            { 4, 88 },
            { 6, 85 }
        };

    // Start is called before the first frame update
    void Start()
    {
        ResetGame();
        isSpin = false; // default is fast bowling mode.
    }

    public void ResetGame(bool status = true)
    {
        runsSelection.Disable();
        score = 0;
        balls = 30;
        isSelectionPending = false;
        wickets = 5;
        isWon = false;
        randomNumber = 0;
        isEndGame = false;
        if (status)
        {
            UpdateStatus("Click the dark area on the");
            AppendStatus("pitch for throwing the ball");
            scoretext.UpdateScore(0, 0, 0,TARGET_SCORE);
        }
    }


    //Not using update since we are relying on event triggers.
    void Update()
    {
        
    }

    private void Awake()
    {
        scoretext = FindObjectOfType<Score>();
        status = FindObjectOfType<Status>();
        runsSelection = FindObjectOfType<RunSelection>();
    }

    public void UpdateStatus(string text)
    {
        status.UpdateStatus(text);
    }

    public void AppendStatus(string text)
    {
        status.AppendStatus(text);
    }

    // Main game logic
    // Run for each selection.
    public void Evaluate(int number)
    {
        var iswicket = false;
        var evaluatedScore = EvalScore(number);
        if (evaluatedScore == -1)
        {
            wickets--;
            evaluatedScore = 0;
            iswicket = true;
        }
        score += evaluatedScore;
        balls--;
        
        if (balls <= 0)
        {
            isEndGame = true;
            isWon = false;
            UpdateStatus("Game has ended");
        }
        if (wickets <= 0)
        {
            isEndGame = true;
            isWon = false;
        }
        // this check should come last because we can win on the last ball
        if( score >= TARGET_SCORE)
        {
            isEndGame = true;
            isWon = true;
        }
        scoretext.UpdateScore(score, (5 - wickets), (30 - balls),TARGET_SCORE);
        if (!iswicket)
            UpdateStatus("Scored runs:" + evaluatedScore);
        else
            UpdateStatus("Fall of wicket");
        AppendStatus("Click the dark area on the");
        AppendStatus("pitch for throwing the ball");

        runsSelection.Disable();
        isSelectionPending = false;

        if(isEndGame)
        {
            UpdateStatus("Game has ended");
            if (isWon)
                AppendStatus("You won");
            else
                AppendStatus("You lose");
            AppendStatus("Click on the dark area to start the game");
            ResetGame(false);
        }
    }

    // OnClick method of the spin button
    public void ToggleBowlingMode()
    {
        isSpin = !isSpin;
    }

    // use this fetch the bowling mode and update the button status
    public bool GetBowlingMode()
    {
        return isSpin;
    }

    //Update the score based on probabilty
    private int EvalScore(int number)
    {
        
        randomNumber = Random.Range(1, 100);
        // add probabilty based calculations.
        int scoredruns = 0;
        var treshold = successProbabiltyMap.GetValueOrDefault(number);
        if (randomNumber <= treshold)
            scoredruns = number;
        treshold = outProbabiltyMap.GetValueOrDefault(number);
        if (randomNumber > treshold)
            scoredruns = -1;
        return scoredruns;
    }

    public int GetScore()
    {
        return score;
    }
}
