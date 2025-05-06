using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class MusicEffects : MonoBehaviour
{
    public AudioSource TitleMusic;
    public float FadeDuration;
    public UnityEvent AfterFade;
    private float _originFloat;

    public void MusicFade()
    {
        StartCoroutine(MusicFadeIE());
    }
    public IEnumerator MusicFadeIE()
    {
        _originFloat = TitleMusic.volume;
        for (int i = 0; i < 20; i++)
        {
            TitleMusic.volume = Mathf.Lerp(_originFloat, 0, i / 20f);
            yield return new WaitForSeconds(FadeDuration);
        }
        AfterFade.Invoke();
    }
}
