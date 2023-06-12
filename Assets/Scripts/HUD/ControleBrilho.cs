using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class ControleBrilho : MonoBehaviour
{
    public Volume volume;
    private LiftGammaGain liftGammaGain;

    public Slider gainSlider;

    private void Start()
    {
        volume.profile.TryGet(out liftGammaGain);
        UpdateGainFromSlider();
    }

    public void OnSliderValueChanged()
    {
        UpdateGainFromSlider();
    }

    private void UpdateGainFromSlider()
    {
        if (liftGammaGain)
        {
            float gainValue = gainSlider.value;
            liftGammaGain.gain.Override(new Vector4(gainValue, gainValue, gainValue, gainValue));
        }
    }


}
