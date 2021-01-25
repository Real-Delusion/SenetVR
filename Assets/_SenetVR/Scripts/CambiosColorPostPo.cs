using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class CambiosColorPostPo : MonoBehaviour
{
    // --------------------------------------------------------------------------
    // Scripts
    // --------------------------------------------------------------------------
    [Header("Scripts")]
    [SerializeField]
    private Volume _volumPostPorcesingVolume;

    // --------------------------------------------------------------------------
    // Vars
    // --------------------------------------------------------------------------
    private ColorAdjustments _colorAdjustments;

    // --------------------------------------------------------------------------
    // Runetime
    // --------------------------------------------------------------------------
    // Start is called before the first frame update
    void Start()
    {
        _volumPostPorcesingVolume = GetComponent<Volume>();

        _volumPostPorcesingVolume.profile.TryGet(out _colorAdjustments);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
