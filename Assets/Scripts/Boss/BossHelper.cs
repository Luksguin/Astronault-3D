using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Boss
{
    public class BossHelper : MonoBehaviour
    {
        public BossBase bossBase;

        private void OnTriggerEnter(Collider other)
        {
            Player p = other.transform.GetComponent<Player>();

            if (p != null)
            {
                bossBase.ChangeState(BossAction.INIT);
                gameObject.SetActive(false);
            }
        }
    }
}
