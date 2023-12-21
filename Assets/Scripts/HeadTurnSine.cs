using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeadTurnSine : MonoBehaviour
{
    [SerializeField] private SynthData synthData;
    private float _frequency = 1f;
    private float _frequencyMax; // for all practical purposes this is actually the amplitude
    private float _frequencyMin;
    private float _amplitude = 1f;
    private float _amplitudeMin = 0.11f;
    private float _amplitudeMax = 5f;
    private float _freqModFreq = 1f;
    private float _freqModAmpRange = 1f;
    private float _freqModAmpChangeSpeed;
    private float _freqModAmp;
    private float _ampModAmpRange = 1f;
    private float _ampModAmpChangeSpeed = 1f;
    private float _ampModAmp;

    private float time = 0f;
    private void OnEnable()
    {
        synthData.updated.AddListener(SynthDataUpdates);
    }
    private void OnDisable()
    {
        synthData.updated.RemoveListener(SynthDataUpdates);
    }

    private void Start()
    {
        _frequency = synthData.frequency;
        _frequencyMax = synthData.frequencyMax;
        _frequencyMin = synthData.frequencyMin;
        _amplitude = synthData.amplitude;
        _amplitudeMin = synthData.amplitudeMin;
        _amplitudeMax = synthData.amplitudeMax;
        _freqModFreq = synthData.freqModFreq;
        _freqModAmpRange = synthData.freqModAmpRange;
        _freqModAmpChangeSpeed = synthData.freqModAmpChangeSpeed;
        _ampModAmpRange = synthData.ampModAmpRange;
        _ampModAmpChangeSpeed = synthData.ampModAmpChangeSpeed;
        _ampModAmp = synthData.ampModAmp;
    }
    void SynthDataUpdates()
    {
        //_frequency = synthData.frequency;
        _frequencyMax = synthData.frequencyMax;
        _frequencyMin = synthData.frequencyMin;
        //_amplitude = synthData.amplitude;
        _amplitudeMin = synthData.amplitudeMin;
        _amplitudeMax = synthData.amplitudeMax;
        _freqModFreq = synthData.freqModFreq;
        _freqModAmpRange = synthData.freqModAmpRange;
        _freqModAmpChangeSpeed = synthData.freqModAmpChangeSpeed;
        _ampModAmpRange = synthData.ampModAmpRange;
        _ampModAmpChangeSpeed = synthData.ampModAmpChangeSpeed;
        _ampModAmp = synthData.ampModAmp;
    }

    void Update()
    {
        time += Time.deltaTime;

        //Modulate the frequency
        float fAmpFactor = Mathf.PingPong(time * _freqModAmpChangeSpeed, _freqModAmpRange);
        //Debug.Log(fAmpFactor);
        float modFreqAmp = ((_frequencyMax / 2) + _frequencyMin) * fAmpFactor;
        float modFrequency = modFreqAmp * Mathf.Sin(2f * Mathf.PI * _freqModFreq * time) + modFreqAmp; //offset the sinewave by the amplitude so modFrequency always positive


        //Modulate the amplitude

        float aAmpFactor = Mathf.PingPong(time * _ampModAmpChangeSpeed, _ampModAmpRange);
        float ampShift = ((_amplitudeMax - _amplitudeMin) / 2) * aAmpFactor;
        Debug.Log(aAmpFactor);
        float modAmplitude = _amplitudeMax - ampShift;

        // Calculate the sine wave value

        float sineValue = modAmplitude * Mathf.Sin(2f * Mathf.PI * modFrequency);// * time);

        // Apply the sine wave value to the position
        transform.position = new Vector3(sineValue, transform.position.y, transform.position.z);

        synthData.frequency = modFrequency;
        synthData.amplitude = modAmplitude;
        synthData.freqModAmp = fAmpFactor;
        synthData.ampModAmp = aAmpFactor;
    }
}

