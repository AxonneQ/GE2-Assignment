using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextPlayer : MonoBehaviour
{
    public float time = 0;
    public List<string> subtitles;
    public List<float> delays;
    // Start is called before the first frame update
    void Start()
    { }

    void Awake()
    {
        for (int i = 0; i < subtitles.Count; i++)
        {   
            IEnumerator coroutine = WriteOnScreenAfter(subtitles[i], delays[i]);
            this.StartCoroutine(coroutine);
        }
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
    }

    IEnumerator WriteOnScreenAfter(string text, float delay)
    {
        Debug.Log($"starting {text}, delay: {delay}");

        yield return new WaitForSeconds(delay);
        Debug.Log("Executing coroutine");
 
        TextManager.Instance.WriteText(text, 2); 
        
    }
}
