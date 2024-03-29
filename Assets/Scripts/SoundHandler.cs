﻿using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class SoundHandler : MonoBehaviour
{
    private static float master = 0.6f;
    private static bool rolling = false;
    private static bool lastRolling = false;

    public string[] names;
    public AudioClip[] clips;

    private AudioSource musicPlayer, ambiencePlayer, oneShotPlayer;
    private Dictionary<string, AudioClip> clipDict = new Dictionary<string, AudioClip>();


    // Update is called once per frame
    void Update()
    {
        if (rolling && !oneShotPlayer.isPlaying) {
            oneShotPlayer.PlayOneShot(clipDict["roll"]);
            rolling = true;
        }
        if (rolling && !lastRolling && Ball.moving.Count > 0) lastRolling = true;
        if (rolling &&  lastRolling && Ball.moving.Count == 0) {
            Debug.Log("Rolling stop");
            oneShotPlayer.Stop(); 
            rolling = false; 
            lastRolling = false;
        }
    }

    void Awake() {
        fillClipDict();
        setSources();
        setProperties(musicPlayer, true, false, null);
        // setProperties(musicPlayer, true, false, clipDict["music"]);
        // setProperties(ambiencePlayer, true, false, null);
        setProperties(ambiencePlayer, true, false, clipDict["ambience"]);
        setProperties(oneShotPlayer, false, false, null);
        // musicPlayer.Play();
        if (SceneManager.GetActiveScene().name == "GameScene") ambiencePlayer.Play();
    }

    private void setSources() {
        GameObject background = gameObject;
        musicPlayer = background.AddComponent<AudioSource>();
        ambiencePlayer = background.AddComponent<AudioSource>();
        oneShotPlayer = background.AddComponent<AudioSource>();
    }

    private void setProperties(AudioSource a, bool loop, bool awake, AudioClip clip) {
        a.loop = loop;
        a.playOnAwake = awake;
        a.volume = master;
        a.clip = clip;
    }

    public void scaleAllVolumes(float v) {
        v = v>0.99 ? 1f : v<0.01 ? 0f : v;
        if (Math.Abs(musicPlayer.volume-v) > 0.5) return;
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

    public void startRolling() {
        oneShotPlayer.PlayOneShot(clipDict["roll"]);
        rolling = true;
    }
}
