using System.Collections;
using System.Collections.Generic;
using System.Threading;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using TMPro;

public class ScoreBehavior : MonoBehaviour
{
    private bool move;
    private int score;
    private float timeCount;
    public float rotationSpeed;
    private Transform from;
    private Quaternion start;
    private Quaternion to;
    private bool currentScoreIsA = true;
    public TextMeshProUGUI scoreA;
    public TextMeshProUGUI scoreB;

    void Start()
    {
        from = transform;
        scoreA.text = "0";
        scoreB.text = "?";
    }

    public void ScoreUpdate(int aScore)
    {
        move = true;
        score = aScore;
        start = from.localRotation;
        to = Quaternion.Euler(180f, 0f, 0f) * start;
        if (currentScoreIsA)
            scoreB.text = score.ToString();
        else
            scoreA.text = score.ToString();
    }

    void Update()
    {
        if (move)
        {
            timeCount += Time.deltaTime * rotationSpeed;
            Debug.Log(timeCount);
            from.localRotation = Quaternion.Lerp(start, to, timeCount);
            if (timeCount > 1)
            {
                currentScoreIsA = !currentScoreIsA;
                move = false;
                timeCount = 0;
            }
        }
    }
}
