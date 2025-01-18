using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
public  class MySoundManager : SingleTon<MySoundManager>
{
    public const string AUDIO_PATH = "Audio/";
    private static GameObject oneShotObj;
    private static AudioSource oneShotAudioSource;
    private static Dictionary<string,float> SfxName_PlayTime;
    private static Dictionary<string,AudioClip> audios;
    //播放音效直接调用这个函数就行
    //它不关心能否同一时间大量播放,即你每一帧调用一次的话它每一帧播放一次，它不关上一个同样的音效放没放完
    public static void PlayAudio(string _sfxName)
    {
        if(oneShotObj == null)
        {
            oneShotObj = new GameObject(AUDIO_PATH + "OneShotSound");
            oneShotAudioSource = oneShotObj.AddComponent<AudioSource>();
        }
        oneShotAudioSource.volume = Random.Range(0.25f, 0.4f);
        // oneShotAudioSource.volume = Random.Range(0.6f, 0.8f);
        oneShotAudioSource.PlayOneShot(GetAudio(_sfxName));
    }
    //播放音效直接调用这个函数就行
    //它关心能否同一时间大量播放
    public static void PlayOneAudio(string _sfxName)
    {
        if(SfxName_PlayTime == null)
        {
            SfxName_PlayTime = new Dictionary<string, float>();
        }

        if(!SfxName_PlayTime.ContainsKey(_sfxName))
        {
            SfxName_PlayTime.Add(_sfxName,0f);
        }
        float curTime = Time.time;
        AudioClip clip = GetAudio(_sfxName);
        //如果播放完
        if(curTime > SfxName_PlayTime[_sfxName] + clip.length)
        {
            if(oneShotObj == null)
            {
                oneShotObj = new GameObject(AUDIO_PATH + "OneShotSound");
                oneShotAudioSource = oneShotObj.AddComponent<AudioSource>();
                oneShotAudioSource.volume = Random.Range(0.25f, 0.4f);
            }
            oneShotAudioSource.PlayOneShot(GetAudio(_sfxName));
            SfxName_PlayTime[_sfxName] = curTime;
        }
    }
    
    //获取audio clip
    private static AudioClip GetAudio(string _sfxName)
    {
        if(audios == null)
        {
            audios = new Dictionary<string, AudioClip>();
        }
    
        if(!audios.ContainsKey(_sfxName))
        {
            AudioClip clip = Resources.Load<AudioClip>(AUDIO_PATH + _sfxName);
            audios.Add(_sfxName,clip);
        }
        return audios[_sfxName];
    }
}
