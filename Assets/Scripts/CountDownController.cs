using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class CountDownController : MonoBehaviour
{

    public int _countdownTime { get; set; }
    [SerializeField] private TMP_Text _countdownDisplayText;

    public event Action OnCountdownFinished;

    public Transform textPoint;
    public Transform canvasTransform;

    private bool isCountingDown = false;

    public CountDownController(int countdownTime, TMP_Text countdownDisplayText)
    {
        _countdownTime = countdownTime;
        _countdownDisplayText = countdownDisplayText;
    }
    public void StartCountDown()
    {
        StartCoroutine(CountdownToStart());
    }
    IEnumerator CountdownToStart()
    {
        isCountingDown = true;
        while(_countdownTime > 0)
        {
            if(_countdownDisplayText != null)
            {
                _countdownDisplayText.text = _countdownTime.ToString();
                
            }
            

            yield return new WaitForSeconds(1f);

            _countdownTime--;
        }
        if (OnCountdownFinished != null)
            OnCountdownFinished();
        _countdownDisplayText.text = null;
    }

    private void LateUpdate()
    {
        if(isCountingDown)
        {
            Vector3 textPos = Camera.main.WorldToScreenPoint(textPoint.position);
            _countdownDisplayText.transform.position = textPos;
        }
    }
}
