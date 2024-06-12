using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockVisualSystem : MonoBehaviour
{
    [SerializeField] private GameObject RedImage;
    [SerializeField] private GameObject YellowImage;
    [SerializeField] private GameObject PurpleImage;
    [SerializeField] private GameObject ForceParticlesEffect;

    Unit unit;
    BlockCollisionManager blockCollisionManager;
    void Start()
    {
        
        unit = GetComponentInChildren<Unit>();
        unit.OnBlockActive += Unit_OnBlockActive;
        unit.OnBlockWait += Unit_OnBlockWait;
        unit.OnBlockDeactive += Unit_OnBlockDeactive;

        blockCollisionManager = GetComponentInChildren<BlockCollisionManager>();
        blockCollisionManager.OnParticlesForceEffect += BlockCollisionManager_OnParticlesForceEffect;
    }

    private void BlockCollisionManager_OnParticlesForceEffect(object sender, System.EventArgs e)
    {
        if (unit.isBallInteract) {
            ForceParticlesEffect.SetActive(true);
        }
    }

    private void Unit_OnBlockDeactive(object sender, System.EventArgs e)
    {
        RedImage.SetActive(true);
        YellowImage.SetActive(false);
        PurpleImage.SetActive(false);
        ForceParticlesEffect.SetActive(false);
    }

    private void Unit_OnBlockWait(object sender, System.EventArgs e)
    {
        RedImage.SetActive(false);
        YellowImage.SetActive(true);
        PurpleImage.SetActive(false);
        ForceParticlesEffect.SetActive(false);
    }

    private void Unit_OnBlockActive(object sender, System.EventArgs e)
    {
        RedImage.SetActive(false);
        YellowImage.SetActive(false);
        PurpleImage.SetActive(true);
    }
}
