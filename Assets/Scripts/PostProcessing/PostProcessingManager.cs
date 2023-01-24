using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class PostProcessingManager : MonoBehaviour
{
    public PostProcessVolume postProcess;
    //public float duration;

    private Vignette _vignette;

    [NaughtyAttributes.Button]
    public void ShowVignette()
    {
        StartCoroutine(VignetteCoroutine());
    }

    IEnumerator VignetteCoroutine()
    {
        Vignette tmp;
        //float time = 0;

        if(postProcess.profile.TryGetSettings(out tmp))
        {
            _vignette = tmp;
        }

        //time = Time.deltaTime;
        _vignette.intensity.Interp(0, .4f, 1f);
        yield return new WaitForSeconds(.3f);
        _vignette.intensity.Interp(.4f, 0, 1f);

        /*while (time < duration)
        {
            time = Time.deltaTime;
            _vignette.intensity.Interp(0, .4f, 1f);
            yield return new WaitForSeconds(.3f);
            _vignette.intensity.Interp(.4f, 0, 1f);
        }

        time = 0;
        while (time < duration)
        {
            time = Time.deltaTime;
            _vignette.intensity.value = 0;
            yield return new WaitForEndOfFrame();
        }*/
    }
}
