using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class TreasureBoxNazo : MonoBehaviour
{
    //�@���݂̓��͂�ۑ�����z��
    public int[] inputColor = new int[4] { 0, 0, 0, 0 };
    //�@�����̔z��
    public int[] correct = new int[4];
    //�@�F�̐��@���A�I�����W�A���F�A�s���N
    [SerializeField] int ColorType = 4;
   // public GameObject TapPositionTrue = default;
    public GameObject TapPositionFalse = default;

    //�@�}�e���A����ύX����Q�[���I�u�W�F�N�g
    [SerializeField] GameObject[] gameobjs = new GameObject[4];
    //�@�󔠂��J�����}�X�N�p�l��
    [SerializeField] GameObject MaskPanel = default;
    //�@���P�b�g�擾��̃}�X�N�p�l��
    [SerializeField] GameObject MaskPanel2 = default;

    public void OnClick(int i)
    {
        if (FlagManager.instance.IsClearTreasureBox == false)
        {
            //�@�}�e���A���̃C���f�b�N�X
            var idx = inputColor[i];
            //�@���𑝂₷
            inputColor[i]++;
            if (inputColor[i] >= ColorType)
            {
                inputColor[i] = 0;
            }
            //�@�Q�[���I�u�W�F�N�g�ɃJ���[���f
            if (inputColor[i] == 0) gameobjs[i].GetComponent<Image>().color = Color.white;
            if (inputColor[i] == 1) gameobjs[i].GetComponent<Image>().color = Color.red;
            if (inputColor[i] == 2) gameobjs[i].GetComponent<Image>().color = Color.blue;
            if (inputColor[i] == 3) gameobjs[i].GetComponent<Image>().color = Color.green;


            CheckCorrect();
        }
    }



    public void CheckCorrect()
    {
        //�@����������
        if (inputColor.SequenceEqual(correct) == true)
        {
            // �{�^���𔽉����Ȃ��悤�ɂ���
            for(int i = 0; i < gameobjs.Length; i++)
            {
                gameobjs[i].GetComponent<Button2>().interactable = false;
            }

            //TODO�F �t���O�ύX
            FlagManager.instance.IsClearTreasureBox = true;
            //�@TapPosition �\��/��\��
            TapPositionFalse.SetActive(false);
           // TapPositionTrue.SetActive(true);

            this.gameObject.SetActive(false);
            //DelayMethod��1.0�b��ɌĂяo��
            Invoke(nameof(DelayMethod), 1.0f);


        }
    }

    public void DelayMethod()
    {
        
        MaskPanel.SetActive(true);
        //DelayMethod��1.0�b��ɌĂяo��
        Invoke(nameof(DelayMethod2), 1.0f);

    }

    public void DelayMethod2()
    {

        //���P�b�g����
        this.GetComponent<PickupObj>().OnClickObj();
        //���P�b�g���Ƃ�����̉摜�ɐ؂�ւ�
        MaskPanel2.SetActive(true);
        this.gameObject.SetActive(false);
    }


}
