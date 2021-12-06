using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueTrigger : MonoBehaviour
{
    public new string name;
    public Text storyText;
    public Color color = Color.black;
    public int textCount = 0;
    public string[] sentences;

    public AudioClip[] dialogueClips;


}
