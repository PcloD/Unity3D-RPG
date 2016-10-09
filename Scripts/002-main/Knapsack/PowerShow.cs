using UnityEngine;
using System.Collections;

public class PowerShow : MonoBehaviour {
    public static PowerShow _Instance;

    private float startValue = 0;
    private int endValue = 1000;
    private bool isStart = false;
    private bool isUp = true;//数字是否增加
    public int speed = 1000;
    
    private UILabel label;
    private TweenAlpha tween;

    void Awake()
    {
        _Instance = this;
        label = transform.Find("Label").GetComponent<UILabel>();
        tween = GetComponent<TweenAlpha>();

        EventDelegate ed = new EventDelegate(this, "OnTweenFinised");
        tween.onFinished.Add(ed);

        gameObject.SetActive(false);
    }

    void Update()
    {
        
        if (isStart)
        {
            if (isUp)
            {
                startValue += speed * Time.deltaTime;
               

                if (startValue>=endValue)
                {
                    startValue = endValue;
                    isStart = false;
                    tween.PlayReverse();
                }

            }
            else
            {
                startValue -= speed * Time.deltaTime;
                if (startValue <= endValue)
                {
                    startValue = endValue;
                    isStart = false;
                    tween.PlayReverse();
                }
            }
            label.text = ((int)startValue).ToString();
        }
    }

    public void ShowPowerChanged(int startValue,int endValue)
    {
        gameObject.SetActive(true);
        tween.PlayForward();
        this.startValue = startValue;
        this.endValue = endValue;


        if (endValue>startValue)
        {
            isUp = true;
        }
        else
        {
            isUp = false;
        }

        isStart = true;
    }

    public void OnTweenFinised()
    {
        if (isStart==false)
        {
            gameObject.SetActive(false);
        }
    }

}
