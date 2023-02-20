using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SchoolLunch_ComboManager : MonoBehaviour
{
    [SerializeField]GameObject goComboImage = null;
    [SerializeField]UnityEngine.UI.Text txtCombo = null;

    int currentCombo = 0;

    void Start() 
    {
        txtCombo.gameObject.SetActive(false);
        goComboImage.SetActive(false);
    }

    public void IncreaseCombo(int p_num = 1) //콤보점수 올리기
    {
        currentCombo += p_num;
        txtCombo.text = string.Format("{0:#,##0}", currentCombo);

        if(currentCombo > 2) //콤보점수가 2보다 크면 화면에 보이게
        {
            txtCombo.gameObject.SetActive(true);
            goComboImage.SetActive(true);
        }
    }

    public int GetCurrentCombo()//콤보점수 내보내기(점수판 표출할때 사용)
    {
        return currentCombo;
    }

    public void ResetCombo()//콤보점수 리셋(게임 다시 시작할때 사용)
    {
        currentCombo = 0;
        txtCombo.text = "0";
        txtCombo.gameObject.SetActive(false);
        goComboImage.SetActive(false);
    }
}
