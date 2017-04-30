using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TouchPad : MonoBehaviour
{
    public Image[] buttonImages;

    int[] inputs = new int[9];

    void Start()
    {
        for (int i = 0; i < inputs.Length; i++)
        {
            inputs[i] = 0;
        }
    }
    bool bStart = false;

    public void SetStart()
    {
        bStart = true;
    }

    //0~8까지 들어옵니다.
    public void OnTouchPad(int _padNo)
    {
        //여기에 들어올때 리셋 시켰냐 안시켰냐 판별해야함.
        //이미 눌려졌떤 버튼은 다시 못누른다.
        if (inputs[_padNo] == 1 || !bStart) return;

        buttonImages[_padNo].color = Color.red;

        inputs[_padNo] = 1;

        //들어올때마다 string 을 만들어서 몬스터 전체한테 쏴본다.
        if ( GameManager.Instance.CheckHit(inputs, _padNo) )
        {
            ResetPattern();
        }

    }

    public void ResetPattern()
    {
        for (int i = 0; i < inputs.Length; i++)
        {
            buttonImages[i].color = Color.white;
            inputs[i] = 0;
        }

    }

}
