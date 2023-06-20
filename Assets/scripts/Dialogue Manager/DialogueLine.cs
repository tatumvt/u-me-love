using System.Collections;
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
        public AudioSource pic;

        [Header("Canvas")]
        public GameObject phone;
        public GameObject crush;
        public GameObject picture;
        public GameObject school;
        public GameObject kitchen;
        public GameObject picnic;
        public bool isTutorial;
        public bool isLevelOne;
        public bool isLevelAnswerGood;
        public bool isLevelAnswerWrong;
        public bool isLevelTwo;
        public bool isLevelFive;
        public bool isLevelSix;
        public bool isLevelSixAnswer;
        public bool isLevelThreeGood;


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
            if (isLevelAnswerGood == true)
                EnterCrush();
            if (isLevelAnswerWrong == true)
                EnterSchool();
            if (isLevelTwo == true)
                GrabPhone();
            if (isLevelFive == true)
                TakePhone();
            if (isLevelSix == true)
                ActivateKitchen();
            if (isLevelSixAnswer == true)
                StopPicnic();
            if (isTutorial == true)
                MarketTutorial();
            if (isLevelThreeGood == true)
                TakePicture();
        }
        #region canvas switches 
        public void MarketTutorial()
        {
            if (index >= 5)
            {
                Time.timeScale = 1;
                phone.SetActive(true);
            }
        }
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
        public void TakePicture()
        {
            if (index >= 5)
            {
                Time.timeScale = 1;
                picture.SetActive(true);
                pic.Play();
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
            if (index >= 10)
            {
                Time.timeScale = 1;
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
        public void GrabPhone()
        {
            if (index >= 25)
            {
                Time.timeScale = 1;
                phone.SetActive(true);
            }
        }
        public void TakePhone()
        {
            if (index >= 20)
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
    