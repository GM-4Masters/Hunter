using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

public class ResultPopup : MonoBehaviour
{
    private float sp = 300;
    private float deltaSP = 150;
    private float deltatime = 3;
    private float deltaMoney = 500;
    private float mental = 100;
    private float deltaMental = 10;

    public Image spGauge;
    public Image mentalGauge;
    public Text spTxt;
    public Text mentalTxt;
    public Text moneyTxt;
    public Text timeTxt;
    public float time = 12;
    public float money = 115116;
    public Text preMoneyTxt;
    public Text preTimeTxt;

    public GameObject SP;
    public GameObject Time2;
    public GameObject Money;
    public GameObject Mental;

    void Start()
    {
        ShowResult();
    }

    async void ShowResult()
    {
        await Task.Delay(1000);

        SP.SetActive(true);
        Time2.SetActive(true);
        Money.SetActive(true);
        Mental.SetActive(true);

        await Task.Delay(1000);

        //spGauge.fillAmount = (sp-deltaSP) / sp;

        StartCoroutine(SPCount(sp - deltaSP, sp));
        StartCoroutine(TimeCount(time + deltatime, time));
        StartCoroutine(MoneyCount(money - deltaMoney, money));
        StartCoroutine(MentalCount(mental - deltaMental, mental));

        //mentalGauge.fillAmount = (mental-deltaMental) / mental;

        await Task.Delay(1000);
        spTxt.text = "(-" + deltaSP.ToString() + ")";
        timeTxt.text = "(+" + deltatime.ToString() + "시간)";
        moneyTxt.text = "(-" + deltaMoney.ToString() + "$)";
        mentalTxt.text = "(-" + deltaMental.ToString() + ")";
    }

    IEnumerator SPCount(float target, float current)
    {
        float duration = 0.5f; // 카운팅에 걸리는 시간 설정. 
        float offset = (current - target) / duration;
        float max = current;
        current = target;
        while (current < max)
        {
            current += offset * Time.deltaTime;
            spGauge.fillAmount = target / current;
            yield return null;
        }
        current = target;
    }

    IEnumerator TimeCount(float target, float current)
    {
        float duration = 0.5f; // 카운팅에 걸리는 시간 설정. 
        float offset = (target - current) / duration;
        while (current < target)
        {
            current += offset * Time.deltaTime;
            preTimeTxt.text = ((int)current).ToString() + ":00";
            yield return null;
        }
        current = target;
        preTimeTxt.text = ((int)current).ToString() + ":00";
    }

    IEnumerator MoneyCount(float target, float current)
    {
        float duration = 0.5f; // 카운팅에 걸리는 시간 설정. 
        float offset = (current - target) / duration;
        while (current > target)
        {
            current -= offset * Time.deltaTime;
            preMoneyTxt.text = ((int)current).ToString() + "$";
            yield return null;
        }
        current = target;
        preMoneyTxt.text = ((int)current).ToString() + "$";
    }

    IEnumerator MentalCount(float target, float current)
    {
        float duration = 0.5f; // 카운팅에 걸리는 시간 설정. 
        float offset = (current - target) / duration;
        float max = current;
        current = target;
        while (current < max)
        {
            current += offset * Time.deltaTime;
            mentalGauge.fillAmount = target / current;
            yield return null;
        }
        current = target;
    }
}