using UnityEngine.Audio;
using UnityEngine;

public class Options : MonoBehaviour
{
    public AudioMixer mainMixer; //Skapar en audiomixervariabel - Darian
    public void SetVolume(float Volume)
    {
        mainMixer.SetFloat("Volume", Volume); //gör så att man kan ändra volymen - Darian
    }
    public void SetFullscreen(bool isFullscreen)
    {
        Screen.fullScreen = isFullscreen; //gör så att man kan ändra mellan fullscreen och ej fullscreen - Darian
    }
}
