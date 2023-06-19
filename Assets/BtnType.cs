using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;

public class BtnType : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{ 

    public BTNType currentType;
    public Transform buttonScale;
    public Vector3 defaultScale;
    public CanvasGroup mainGroup;
    public CanvasGroup optionGroup;
    public TMP_Text SoundText;

    private void Start()
    {
        defaultScale = buttonScale.localScale;
    }

    bool isSound = true;

    public void OnBtnClick()
    {
        switch (currentType)
        {

            case BTNType.New:
                SceneLoader.LoadSceneHandle("SampleScene", 0);
                break;

            case BTNType.Continue:
                SceneLoader.LoadSceneHandle("SampleScene", 1);
                break;

            case BTNType.Option:
                CanvasGroupOn(optionGroup);
                CanvasGroupOff(mainGroup);
                break;

            case BTNType.Sound:
                if (isSound)
                {
                    isSound = !isSound;
                    SoundText.text = "Sound OFF";
                    Debug.Log("사운드 끄기");
                }
                else 
                {
                    isSound = !isSound;
                    SoundText.text = "Sound ON";
                    Debug.Log("사운드 켜기");
                }
                break;

            case BTNType.Back:
                CanvasGroupOn(mainGroup);
                CanvasGroupOff(optionGroup);
                break;

            case BTNType.Quit:
                Application.Quit();
                Debug.Log("게임 종료");
                break;
        }
    }

    public void CanvasGroupOn(CanvasGroup cg)
    {
        cg.alpha = 1;
        cg.interactable = true;
        cg.blocksRaycasts = true;
    }

    public void CanvasGroupOff(CanvasGroup cg)
    {
        cg.alpha = 0;
        cg.interactable = false;
        cg.blocksRaycasts = false;
    }


    public void OnPointerEnter(PointerEventData eventData)
    {
        buttonScale.localScale = defaultScale * 1.2f;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        buttonScale.localScale = defaultScale;
    }
}
