using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class VolumeSave : MonoBehaviour
{

    [SerializeField] Slider volumeSlider;
    [SerializeField] Text textlvl;

    // Start is called before the first frame update
    void Start()
    {
        LoadValues();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void LoadValues()
    {
        float volumeValue = PersistentData.Instance.GetVolume();
        volumeSlider.value = volumeValue;
        AudioListener.volume = volumeValue;
    }

    ///////////////

    public void VolumeSlider(float volume)
    {
        textlvl.text = PersistentData.Instance.GetVolume().ToString("0.0");
        SaveVolume();

    }

    public void SaveVolume()
    {
        float volumeValue = volumeSlider.value;
        PersistentData.Instance.SetVolume(volumeValue);
        LoadValues();
    }
}
