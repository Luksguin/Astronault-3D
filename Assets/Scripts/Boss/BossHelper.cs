using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Boss
{
    public class BossHelper : MonoBehaviour
    {
        public BossBase bossBase;
        public MeshRenderer meshRenderer;
        public GameObject bossCamera;

        private void OnTriggerEnter(Collider other)
        {
            Player p = other.transform.GetComponent<Player>();

            if (p != null)
            {
                OnBoss();
            }
        }
        private void OnTriggerExit(Collider other)
        {
            Player p = other.transform.GetComponent<Player>();

            if (p != null)
            {
                OffBoss();
            }
        }

        private void Awake()
        {
            bossCamera.SetActive(false);    
        }

        private void OnBoss()
        {
            bossCamera.SetActive(true);

            bossBase.ChangeState(BossAction.INIT);
            meshRenderer.enabled = false;
        }

        private void OffBoss()
        {
            bossCamera.SetActive(false);

            bossBase.ChangeState(BossAction.IDLE);
            meshRenderer.enabled = true;
        }
    }
}
