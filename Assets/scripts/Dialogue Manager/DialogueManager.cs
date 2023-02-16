using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogueManager : MonoBehaviour
{
    [Header("Buttons")]
    public GameObject continueButton;
    public GameObject phone;

    [Header("Text Options")]
    [SerializeField] private TextMeshProUGUI textDisplay;
    [SerializeField] private string[] tutorialSentences;
    [SerializeField] private int index;

    [Header("Time Parameter")]
    [SerializeField] private float TypingSpeed;

    [Header("Sounds")]
    public AudioManager am;

    private void Start()
    {
        StartCoroutine(Type());
    }

    private void Update()
    {
        if (textDisplay.text == tutorialSentences[index])
        {
            continueButton.SetActive(true);
        }
    }

    protected IEnumerator Type()
    {
        foreach (char letter in tutorialSentences[index].ToCharArray())
        {
            textDisplay.text += letter;
            am.playTyping();
            yield return new WaitForSeconds(TypingSpeed);
            am.typing.Stop();
        }
    }
    public void NextSentence()
    {
        continueButton.SetActive(false);

        if (index < tutorialSentences.Length - 1)
        {
            index++;
            textDisplay.text = "";
            StartCoroutine(Type());
        }
        else
        {
            textDisplay.text = "";
        }
    }
    public void OpenPhone()
    {
        if (index >= 13)
        {
            Time.timeScale = 1;
            phone.SetActive(true);
        }
    }
}
