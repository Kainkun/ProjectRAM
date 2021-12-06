using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Configs.AudioClipPriority;

namespace Configs
{
    [CreateAssetMenu(fileName = "Configs/Audio")]
    public class AudioClipPriority : ScriptableObject
    {
        public EAudioClips ClipType;
        public float Priority;
        public List<AudioClip> Clip;

        public AudioClip GetRandomClip()
        {
            return Clip[0]; // Make this a random one
        }

        public enum EAudioClips
        {
            UNDEFINED = 0,
            SIMPLE_CLIP =1,
            SCREAM = 2,
        }
    }


}