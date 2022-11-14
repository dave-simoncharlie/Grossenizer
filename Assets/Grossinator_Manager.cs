using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grossinator_Manager : MonoBehaviour
{
    public List<AudioClip> Openers;
    public List<AudioClip> Adjective_1;
    public List<AudioClip> Adjective_2;
    public List<AudioClip> Nouns;
    int opener_num = 0;
    int adj1_num = 0;
    int adj2_num = 0;
    int noun_num = 0;
    public enum ButtonType { Openers, Adjective_1, Adjective_2, Nouns }
    
    void Start()
    {
        UnityEngine.Random.seed = (int)(Time.realtimeSinceStartup * 10000);
    }
    void Update()
    {
        
    }
    public void AdvanceOpener()
    {
        StopAllCoroutines();
        opener_num++;
        if (opener_num >= Openers.Count)
            opener_num = 0;
        GetComponent<AudioSource>().clip = Openers[opener_num];
        GetComponent<AudioSource>().Play(0);
    }
    public void AdvanceAdjective1()
    {
        StopAllCoroutines();
        adj1_num++;
        if (adj1_num >= Adjective_1.Count)
            adj1_num = 0;
        GetComponent<AudioSource>().clip = Adjective_1[adj1_num];
        GetComponent<AudioSource>().Play(0);
    }
    public void AdvanceAdjective2()
    {
        StopAllCoroutines();
        adj2_num++;
        if (adj2_num >= Adjective_2.Count)
            adj2_num = 0;
        GetComponent<AudioSource>().clip = Adjective_2[adj2_num];
        GetComponent<AudioSource>().Play(0);
    }
    public void AdvanceNoun()
    {
        StopAllCoroutines();
        noun_num++;
        if (noun_num >= Nouns.Count)
            noun_num = 0;
        GetComponent<AudioSource>().clip = Nouns[noun_num];
        GetComponent<AudioSource>().Play(0);
    }
    public void PlaySentence()
    {
        StopAllCoroutines();
        StartCoroutine(PlaySentence_Coroutine());
    }
    IEnumerator PlaySentence_Coroutine()
    {
        AudioSource audio = GetComponent<AudioSource>();
        audio.clip = Openers[opener_num];
        audio.Play();
        yield return new WaitForSeconds(audio.clip.length);
        audio.clip = Adjective_1[adj1_num];
        audio.Play();
        yield return new WaitForSeconds(audio.clip.length);
        audio.clip = Adjective_2[adj2_num];
        audio.Play();
        yield return new WaitForSeconds(audio.clip.length);
        audio.clip = Nouns[noun_num];
        audio.Play();
    }
    public void Randomize()
    {
        opener_num = Mathf.RoundToInt(UnityEngine.Random.value * (Openers.Count - 1));
        adj1_num = Mathf.RoundToInt(UnityEngine.Random.value * (Adjective_1.Count - 1));
        adj2_num= Mathf.RoundToInt(UnityEngine.Random.value * (Adjective_2.Count - 1));
        noun_num = Mathf.RoundToInt(UnityEngine.Random.value * (Nouns.Count - 1));
        PlaySentence();
    }

}
