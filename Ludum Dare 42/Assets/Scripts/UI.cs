using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI : World {

    private Text events;
    private Text positiveBuff;
    private Image positiveElement;
    private Text negativeBuff;
    private Image negativeElement;
    [SerializeField]
    private Sprite[] elementImgs;

    public void changeCurrentEvent(string newEvText)
    {
        events.text = newEvText;
    }

    private void setImage(Image imgObj, int element)
    {
        imgObj.sprite = elementImgs[element];
    }

    public void changeBuffs(int posElem, int negElem, int buffStrenght)
    {
        positiveBuff.text = "+" + buffStrenght + "%";
        negativeBuff.text = "-" + buffStrenght + "%";
        setImage(positiveElement, posElem);
        setImage(negativeElement, negElem);
    }

	// Use this for initialization
	void Start () {
        events = GameObject.Find("Events").GetComponent<Text>();
        positiveBuff = GameObject.Find("PositiveBuff").GetComponent<Text>();
        positiveElement = GameObject.Find("PositiveElement").GetComponent<Image>();
        negativeBuff = GameObject.Find("NegativeBuff").GetComponent<Text>();
        negativeElement = GameObject.Find("NegativeElement").GetComponent<Image>();
    }
}
