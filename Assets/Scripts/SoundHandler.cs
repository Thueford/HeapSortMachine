﻿using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class SoundHandler : MonoBehaviour
{

    private AudioSource musicPlayer;
    private AudioSource ambiencePlayer;
    private AudioSource oneShotPlayer;
    public float master = 1f;
    public string[] names;
    public AudioClip[] clips;
    private Dictionary<string, AudioClip> clipDict = new Dictionary<string, AudioClip>();

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void Awake() {
        fillClipDict();
        setSources();
        setProperties(musicPlayer, true, false, null);
        // setProperties(musicPlayer, true, false, clipDoct["music"]);
        setProperties(ambiencePlayer, true, false, null);
        // setProperties(ambiencePlayer, true, false, clipDoct["ambience"]);
        setProperties(oneShotPlayer, false, false, null);
        // musicPlayer.Play();
        // ambiencePlayer.Play();
    }

    private void setSources() {
        GameObject background = gameObject;
        background.AddComponent<AudioSource>();
        background.AddComponent<AudioSource>();
        background.AddComponent<AudioSource>();
        int i = 0;
        foreach (AudioSource a in background.GetComponents<AudioSource>()) {
            if (i == 0) musicPlayer = a;
            else if (i == 1) ambiencePlayer = a;
            else oneShotPlayer = a;
            i++;
        }
    }

    private void setProperties(AudioSource a, bool loop, bool awake, AudioClip clip) {
        a.loop = loop;
        a.playOnAwake = awake;
        a.volume = master;
        a.clip = clip;
    }

    public void scaleAllVolumes(float v) {
        v = v>1 ? 1f : v<0 ? 0f : v;
        musicPlayer.volume = master * v;
        ambiencePlayer.volume = master * v;
        oneShotPlayer.volume = master * v;
    }

    public void fillClipDict() {
        if (names.Length == clips.Length) {
            for (int i = 0; i < names.Length; i++) {
                clipDict.Add(names[i], clips[i]);
            }
        }
    }

    public void oneShot(string name) {
        clipDict.TryGetValue(name, out AudioClip clip);
        if (clip != null) oneShotPlayer.PlayOneShot(clipDict[name]);
    }

}
