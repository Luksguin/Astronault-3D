using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;
using Ebac.Core.Singleton;

public class PostProcessingManager : Singleton<PostProcessingManager>
{
    public PostProcessVolume postProcess;
    public float duration;

    private Vignette _vignette;

    [NaughtyAttributes.Button]
    public void ShowVignette()
    {
        Vignette tmp;

        if (postProcess.profile.TryGetSettings(out tmp))
        {
            _vignette = tmp;
        }

        StartCoroutine(VignetteCoroutine());
    }

    IEnumerator VignetteCoroutine()
    {
        _vignette.intensity.value = Mathf.Lerp(_vignette.intensity.value, .4f, 1f);
        yield return new WaitForSeconds(1f);
        _vignette.intensity.value = Mathf.Lerp(_vignette.intensity.value, 0f, 1f);
    }
}
