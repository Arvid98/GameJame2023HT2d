using System.Collections;
using System.Collections.Generic;
using TMPro;
//using UnityEditor.Timeline;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TimerLabyrint : MonoBehaviour
{

    [SerializeField] Transform player;
    [Header("Component")]
    public TextMeshProUGUI timerText;

    [Header("Timer Settings")]
    public float startTime;
    float currentTime;
    public bool countDown;


    [Header("Limit Setting")]
    public bool hasLimit;
    public float timerLimit;
    public float yellowTimer;

    [Header("Format Settings")]
    public bool hasFormat;
    public TimerFormats formats;
    private Dictionary<TimerFormats, string> timeFormats = new Dictionary<TimerFormats, string>();

    private void Start()
    {
        currentTime = startTime;
        timeFormats.Add(TimerFormats.Whole, "0");
        timeFormats.Add(TimerFormats.TenthDecimal, "0.0");
        timeFormats.Add(TimerFormats.HunderethsDecimal, "0.00");

    }


    private void Update()
    {
        if(currentTime < yellowTimer)
        {
            timerText.color = Color.yellow;
        }

        currentTime = countDown ? currentTime -= Time.deltaTime : currentTime += Time.deltaTime;

        if (hasLimit && (countDown && currentTime < timerLimit) || (!countDown && currentTime >= timerLimit))
        {
            currentTime = startTime;
            SetTimerText();
            timerText.color = Color.white;
            //enabled = false;
            player.position = new Vector2(110, -125);

        }

        SetTimerText();

    }

    private void SetTimerText()
    {
        timerText.text = hasFormat ? currentTime.ToString(timeFormats[formats]) : currentTime.ToString();

    }
    public enum TimerFormats
    {
        Whole,
        TenthDecimal,
        HunderethsDecimal
    }
}
