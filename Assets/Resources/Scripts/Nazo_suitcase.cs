using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class Nazo_suitcase : MonoBehaviour
{
    //�@���݂̓��͂�ۑ�����z��
    public int[] input = new int[3] { 0, 0, 0 };
    //�@�����̔z��
    public int[] correct = new int[3];
    //�@�؂�ւ��摜
    public Sprite[] images = new Sprite[4];
    // public GameObject TapPositionTrue = default;
    public GameObject TapPositionFalse = default;

    //�@�}�e���A����ύX����Q�[���I�u�W�F�N�g
    [SerializeField] GameObject[] gameobjs = new GameObject[3];
    //�@�󔠂��J�����}�X�N�p�l��
    [SerializeField] GameObject MaskPanel = default;
    //�@���P�b�g�擾��̃}�X�N�p�l��
    [SerializeField] GameObject MaskPanel2 = default;

    [SerializeField] GameObject TapPosition_true = default;

    public void OnClick(int i)
    {
        if (FlagManager.instance.IsClearSuitCase == false)
        {
            //�@�}�e���A���̃C���f�b�N�X
            var idx = input[i];
            //�@���𑝂₷
            input[i]++;
            if (input[i] >= images.Length)
            {
                input[i] = 0;
            }
            //�@�Q�[���I�u�W�F�N�g�ɉ摜�؂�ւ�
            gameobjs[i].GetComponent<Image>().sprite = images[input[i]];


          
        }
    }



    public void CheckCorrect()
    {
        //�@����������
        if (input.SequenceEqual(correct) == true)
        {
            // �{�^���𔽉����Ȃ��悤�ɂ���
            for (int i = 0; i < gameobjs.Length; i++)
            {
                gameobjs[i].GetComponent<Button2>().interactable = false;
            }

            //TODO�F �t���O�ύX
            FlagManager.instance.IsClearSuitCase = true;
            //�@TapPosition �\��/��\��
            TapPositionFalse.SetActive(false);
            TapPosition_true.SetActive(true);

            //DelayMethod��1.0�b��ɌĂяo��
            Invoke(nameof(DelayMethod), 1.0f);
            this.gameObject.SetActive(false);

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


    }



}
