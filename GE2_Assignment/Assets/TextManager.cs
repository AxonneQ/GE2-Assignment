using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextManager : MonoBehaviour
{
    private static TextManager _instance;
    private AudioSource audioSource;
    private string messageToWrite;
    private int charIndex;
    private float timer;
    private bool isBusy = false;
    private bool isWriting = false;
    private bool invisibleCharacters;
    private float timeOnScreen;

    public Text textBox;
    public float timePerChar;

    public static TextManager Instance { get { return _instance; } }

    private void Awake() {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        } else {
            _instance = this;
        }
    }

    public void WriteText(string text, float timeOnScreen, bool invisibleCharacters = true) {
        if(isBusy && isWriting) {
            return;
        }
        this.isBusy = true;
        this.isWriting = true;
        this.messageToWrite = text;
        this.invisibleCharacters = invisibleCharacters;
        this.charIndex = 0;
        this.timeOnScreen = timeOnScreen;
    }

    IEnumerator ClearAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        textBox.text = "";
        isBusy = false;
    }

    // Start is called before the first frame update
    void Start()
    {
        textBox.text = "";
        textBox.supportRichText = true;
        this.audioSource = textBox.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if(isWriting) {
            timer -= Time.deltaTime;
            while(timer <= 0f) {
                timer += timePerChar;
                charIndex++;

                string text = messageToWrite.Substring(0, charIndex);

                if(invisibleCharacters) {
                    text += "<color=#00000000>" + messageToWrite.Substring(charIndex) + "</color>";
                }

                textBox.text = text;
                audioSource.PlayOneShot(audioSource.clip);

                if(charIndex >= messageToWrite.Length) {
                    StartCoroutine(ClearAfterDelay(timeOnScreen));
                    isWriting = false;
                    return;
                }
            }
        }
    }
}
