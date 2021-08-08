using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    [System.Serializable]
    public class SoundData
    {
        // 音源エイリアス
        public string name;
        // 音源
        public AudioClip audioClip;
        // 前回再生した時間
        public float playedTime;
    }

    [SerializeField]
    private SoundData[] soundDatas;

    // AudioSourceを同時に鳴らしたい音の数だけ用意
    private AudioSource[] audioSourceList = new AudioSource[20];

    // エイリアスをキーとした管理用Dictionary
    private Dictionary<string, SoundData> soundDictionary = new Dictionary<string, SoundData>();

    // 一度再生してから、次再生できるまでの間隔（秒）
    [SerializeField]
    private float playableDistance = 0.2f;

    // 1つであることを保証するため&グローバルアクセス用
    public static SoundManager Instance
    {
        private set;
        get;
    }

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
        else if(Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        // audioSourceList配列の数だけAudioSourceを自身に生成して配列に格納
        for(var i = 0; i < audioSourceList.Length; ++i)
        {
            audioSourceList[i] = gameObject.AddComponent<AudioSource>();
        }

        // soundDictionaryにセット
        foreach(var soundData in soundDatas)
        {
            soundDictionary.Add(soundData.name, soundData);
        }
    }

    // 未使用のAudioSourceの取得、全て使用中の場合はnullを返却
    private AudioSource GetUnuseAudioSource()
    {
        for(var i = 0; i < audioSourceList.Length; ++i)
        {
            if (audioSourceList[i].isPlaying == false) return audioSourceList[i];
        }
        Debug.Log("未使用のAudioSourceは見つかりませんでした。");
        return null;
    }

    // 指定されたAudioClipを未使用のAudioSourceで再生
    public void Play(AudioClip clip)
    {
        var audioSource = GetUnuseAudioSource();
        if(audioSource == null)
        {
            Debug.Log("audioSourceを再生できませんでした。");
            return;
        }
        audioSource.clip = clip;
        audioSource.Play();
    }

    // 指定された別名で登録されたAudioClipを再生
    public void Play(string name)
    {
        if (soundDictionary.TryGetValue(name, out var soundData)) // 管理用Dictionaryから別名で探索
        {
            // まだ再生するには早い
            if (Time.realtimeSinceStartup - soundData.playedTime < playableDistance) return;
            soundData.playedTime = Time.realtimeSinceStartup; // 次回用に今回の再生時間の保持
            Play(soundData.audioClip); // 見つかったら再生
        }
        else
        {
            Debug.LogWarning($"そのエイリアスは登録されていません:{name}");
        }
    }
}
