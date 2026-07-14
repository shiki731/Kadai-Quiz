using System.Collections;
using TMPro;
using UnityEngine;

public class ButtonSystem : MonoBehaviour
{
    private bool IsPressed = false;
    private bool bol;
    private int QuestPattern = 0;
    private bool ok;

    public TextMeshProUGUI mondai;
    public TextMeshProUGUI buttonL;
    public TextMeshProUGUI buttonR;

    public enum Mode
    {
        WaitInput,
        Start,
        Question,
        WaitAnswer,
        Answer
    }
    Mode Main = Mode.WaitInput;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        IsPressed = false;
        bol = false;
    }

    // Update is called once per frame
    void Update()
    {
        switch (Main)
        {
            case Mode.WaitInput:
                buttonR.text = "Žn‚ß‚é";
                buttonL.text = "@";
                if (IsPressed)
                {
                    Main = Mode.Start;
                    IsPressed = false;
                    StartCoroutine(StartCount());
                }
                break;
            case Mode.Start:
                buttonL.text = "Z";
                buttonR.text = "~";
                if (bol)
                {
                    QuestPattern = QuestPattern + 1;
                    Main = Mode.Question;
                    Debug.Log(QuestPattern);
                }
                break;
            case Mode.Question:
                if(QuestPattern == 1)
                {
                    mondai.text = "–â‘è‚P:1ŽžŠÔ‚Í100•ª‚Å‚ ‚é";
                }
                else if (QuestPattern == 2)
                {
                    mondai.text = "–â‘è‚Q:1dl‚Í100ml‚Å‚ ‚é";
                }
                else if (QuestPattern == 3)
                {
                    mondai.text = "–â‘è‚R:1t‚Í100kg‚Å‚ ‚é";
                }
                else if (QuestPattern == 4)
                {
                    mondai.text = "–â‘è‚S:1m‚Í100cm‚Å‚ ‚é";
                }
                Main = Mode.WaitAnswer;
                break;
            case Mode.WaitAnswer:
                if (ok == true)
                {
                    ok = false;
                    Main = Mode.Start;
                }
                break;
        }
    }

    IEnumerator StartCount()
    {
        for(int i = 3;i > 0; i--)
        {
            mondai.text = i.ToString();
            yield return new WaitForSeconds(0.5f);
        }
        bol = true;
    }

    public void OnClickRightButton()
    {
        IsPressed = true;
        if(QuestPattern == 1 || QuestPattern == 3)
        {
            ok = true;
        }
    }

    public void OnClickLeftButton()
    {
        if (QuestPattern == 2 || QuestPattern == 4)
        {
            ok = true;
        }
    }
}
