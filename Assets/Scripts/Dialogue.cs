using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class Dialogue
{
    public string name;
    public Text storyText;
    public Color color = Color.black;
    public int textCount = 0;
    public string[] sentences;

    public AudioClip[] soundClips;
}
