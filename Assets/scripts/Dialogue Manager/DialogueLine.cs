﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace DialogueSystem
{
    public class DialogueLine : MonoBehaviour
    {
        [Header("Buttons")]
        public GameObject continueButton;

        [Header("Text Options")]
        [SerializeField] private TextMeshProUGUI textDisplay;
        [SerializeField] private string[] sentences;
        [SerializeField] private int index;

        [Header("Time Parameter")]
        [SerializeField] private float TypingSpeed;

        [Header("Sounds")]
        public AudioManager am;

        [Header("Canvas")]
        public GameObject phone;
        public GameObject crush;
        public GameObject school;
        public GameObject kitchen;
        public GameObject picnic;
        public bool isLevelOne;
        public bool isLevelAnswer;
        public bool isLevelTwo;
        public bool isLevelTwoAnswer;

        private void Start()
        {
            continueButton.SetActive(false);
            StartCoroutine(Type(4));
        }

        private void Update()
        {  
            //level specific checks
            if (isLevelOne == true)
                OpenPhone();
            if (isLevelAnswer == true)
            {
                EnterCrush();
                EnterSchool();
            }
            if (isLevelTwo == true)
                ActivateKitchen();
            if (isLevelTwoAnswer == true)
                StopPicnic();
        }
        #region canvas switches 
        public void StopPicnic()
        {
            if (index >= 8)
            {
                Time.timeScale = 1;
                picnic.SetActive(true);
            }
        }
        public void EnterCrush()
        {
            if (index >= 5)
            {
                Time.timeScale = 1;
                crush.SetActive(true);
            }
        }
        public void EnterSchool()
        {
            if (index >= 4)
            {
                Time.timeScale = 1;
                school.SetActive(true);
            }
        }

        public void ActivateKitchen()
        {
            if (index >= 9)
            {
                Time.timeScale = 1;
                //kitchen.SetActive(false);
                Destroy(kitchen);
            }
        }
        public void OpenPhone()
        {
            if (index >= 15)
            {
                Time.timeScale = 1;
                phone.SetActive(true);
            }
        }
        #endregion

        protected IEnumerator Type(float waitTime)
        {
            foreach (char letter in sentences[index].ToCharArray())
            {
                textDisplay.text += letter;
                am.playTyping();
                yield return new WaitForSeconds(TypingSpeed);
                am.typing.Stop();
            }
            continueButton.SetActive(true);
            //Debug.Log("continue");
        }
        public void NextSentence()
        {
            //continueButton.SetActive(true);

            if (index <= sentences.Length )
            {
                continueButton.SetActive(false);
                index++;
                textDisplay.text = "";
                StartCoroutine(Type(6));
            }
            else
                textDisplay.text = "";
        }
    }

}
    