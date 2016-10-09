using UnityEngine;
using System.Collections;

public class MessageManager : MonoBehaviour {

    public static MessageManager _Instance;
    private UILabel messageLabel;
    private TweenAlpha tween;

    private bool isSetActive = true;
    void Awake()
    {
        _Instance = this;

        messageLabel = transform.Find("Bg/Label").GetComponent<UILabel>();
        tween = this.GetComponent<TweenAlpha>();

        EventDelegate ed=new EventDelegate(this,"OnTweenFinished");

        tween.onFinished.Add(ed);


        gameObject.SetActive(false);
    }

    public void ShowMessage(string message,float time=1)
    {
        gameObject.SetActive(true);
        StartCoroutine(show(message,time));
    }

    IEnumerator show(string message,float time)
    {
        
        tween.PlayForward();
        isSetActive = true;
        messageLabel.text = message;

        yield return new WaitForSeconds(time);
        isSetActive = false;
        tween.PlayReverse();

    }

    public void OnTweenFinished()
    {
        if (isSetActive==false)
        {
            gameObject.SetActive(false);
        }
    }

}
