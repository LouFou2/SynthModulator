using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(fileName = "SynthData", menuName = "SynthData/New Synth Data")]
public class SynthData : ScriptableObject
{
    [Header("Signal Settings")]
    [HideInInspector] public float frequencyMin = 0.1f;
    [Range(0.1f, 15f)] public float frequencyMax = 4.0f;
    public float frequency = 1f;
    [Range(0.1f, 5f)] public float amplitudeMin = 0.1f;
    [Range(0.1f, 5f)] public float amplitudeMax = 5f;
    public float amplitude = 1f;

    [Header("Frequency Modulation")]
    [Range(0.01f, 0.15f)] public float freqModFreq = 0.15f;
    [Range(0.1f, 1f)] public float freqModAmpRange = 1f;
    [Range(0.001f, 0.1f)] public float freqModAmpChangeSpeed = 0.05f;
    public float freqModAmp;

    [Header("Amplitude Modulation")]

    [Range(0.1f, 1f)] public float ampModAmpRange = 1f;
    [Range(0.001f, 0.1f)] public float ampModAmpChangeSpeed = 0.05f;
    public float ampModAmp;

    [Header("For Rotation")]
    public float rotationFactor;

    [HideInInspector] public UnityEvent updated;

    private void OnEnable()
    {
        // called when the instance is setup

        if (updated == null)
            updated = new UnityEvent();
    }

    private void OnValidate()
    {
        // called when any value is changed
        // in the inspector

        updated.Invoke();
    }
}
