using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    // gives acces to DialogueTrigger and Dialogue classes
    private DialogueTrigger dialogueTrigger;

    // will be used to reference clips in Dialogue class
    private AudioSource dialogueSource;

    // will be used to reference strings in Dialogue class
    private Queue<string> dialogue;

    // used to to lerp text
    private float t;


    // Start is called before the first frame update
    void Start()
    {
        // gets reference to relevant components
        #region
        dialogueTrigger = GetComponent<DialogueTrigger>();
        dialogueSource = GetComponent<AudioSource>();
        dialogueTrigger.dialogueClass.storyText.text = dialogueTrigger.dialogueClass.sentences[0];
        #endregion

        //sets text color in order to control alpha
        #region
        dialogueTrigger.dialogueClass.color.a = 0;
        dialogueTrigger.dialogueClass.storyText.color = dialogueTrigger.dialogueClass.color;
        StartCoroutine(FadeInText());
        StartCoroutine(FadeOutText());
        #endregion


        // plays first 4 audio clips in sequence
        #region
        Invoke("PlayClip1", 5);
        Invoke("PlayClip2", 25);
        Invoke("PlayClip3", 46);
        Invoke("PlayClip4", 85);
        #endregion
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // for dialogue methods
    #region 

    /*
    public void StartDialogue(Dialogue dialogue)
    {
        Debug.Log("Starting convo with" + dialogue.name);
    }
    */
    void PlayClip1()
    {
        dialogueSource.clip = dialogueTrigger.dialogueClass.soundClips[0];
        dialogueSource.Play();
        print("it played");
    }

    void PlayClip2()
    {
        dialogueSource.clip = dialogueTrigger.dialogueClass.soundClips[1];
        dialogueSource.Play();
    }

    void PlayClip3()
    {
        dialogueSource.clip = dialogueTrigger.dialogueClass.soundClips[2];
        dialogueSource.Play();
    }

    void PlayClip4()
    {
        dialogueSource.clip = dialogueTrigger.dialogueClass.soundClips[3];
        dialogueSource.Play();
    }

    public void PlayClip5()
    {
        dialogueSource.clip = dialogueTrigger.dialogueClass.soundClips[4];
        dialogueSource.Play();
    }
    #endregion

    // for coroutines 
    #region
    IEnumerator FadeInText()
    {
        yield return new WaitForSeconds(5f);


        while (dialogueTrigger.dialogueClass.color.a < 1)
        {
            t += 0.001f;
            dialogueTrigger.dialogueClass.color.a = Mathf.Lerp(0f, 1f, t);
            dialogueTrigger.dialogueClass.storyText.color = dialogueTrigger.dialogueClass.color;
            //Debug.Log(color.a);
            //Debug.Log(t);
        }

    }

    IEnumerator FadeOutText()
    {
        yield return new WaitForSeconds(10f);

        while (dialogueTrigger.dialogueClass.color.a > 0)
        {
            t += 0.001f;
            dialogueTrigger.dialogueClass.color.a = Mathf.Lerp(1f, 0f, t);
            dialogueTrigger.dialogueClass.storyText.color = dialogueTrigger.dialogueClass.color;
            //Debug.Log(color.a);
            //Debug.Log(t);
        }
        dialogueTrigger.dialogueClass.textCount++;
        if (dialogueTrigger.dialogueClass.textCount < 5)
        {
            StartCoroutine(SwitchText());
        }
    }

    IEnumerator SwitchText()
    {
        switch (dialogueTrigger.dialogueClass.textCount)
        {
            case 1:
                yield return new WaitForSeconds(11);
                dialogueTrigger.dialogueClass.color.a = 0;
                dialogueTrigger.dialogueClass.storyText.color = dialogueTrigger.dialogueClass.color;
                dialogueTrigger.dialogueClass.storyText.text = dialogueTrigger.dialogueClass.sentences[1];
                StartCoroutine(FadeInText());
                StartCoroutine(FadeOutText());
                break;

            case 2:
                yield return new WaitForSeconds(11);
                dialogueTrigger.dialogueClass.color.a = 0;
                dialogueTrigger.dialogueClass.storyText.color = dialogueTrigger.dialogueClass.color;
                dialogueTrigger.dialogueClass.storyText.text = dialogueTrigger.dialogueClass.sentences[2];
                StartCoroutine(FadeInText());
                StartCoroutine(FadeOutText());
                break;

            case 3:
                yield return new WaitForSeconds(22);
                dialogueTrigger.dialogueClass.color.a = 0;
                dialogueTrigger.dialogueClass.storyText.color = dialogueTrigger.dialogueClass.color;
                dialogueTrigger.dialogueClass.storyText.text = dialogueTrigger.dialogueClass.sentences[3];
                StartCoroutine(FadeInText());
                StartCoroutine(FadeOutText());
                break;
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "MysteriousObject")
        {
            dialogueTrigger.dialogueClass.color.a = 0;
            dialogueTrigger.dialogueClass.storyText.color = dialogueTrigger.dialogueClass.color;
            dialogueTrigger.dialogueClass.storyText.text = dialogueTrigger.dialogueClass.sentences[4];
            StartCoroutine(FadeInText());
            StartCoroutine(FadeOutText());
            Invoke("PlayClip5", 5);
            print("Im triggered");
        }
    }
    #endregion
}
