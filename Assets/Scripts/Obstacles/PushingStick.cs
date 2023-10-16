using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Runner.Obstacles
{
    public class PushingStick : MonoBehaviour
    {
        private int _playerLayer;
        private int _aiLayer;
        private float _pushForce = 20f;

        private void Start()
        {
            _aiLayer = LayerMask.NameToLayer("AI");
            _playerLayer = LayerMask.NameToLayer("Player");
        }
        private void OnCollisionEnter(Collision other)
        {
            if (other.gameObject.layer == _playerLayer || other.gameObject.layer == _aiLayer)
            {
                //reverse the normal (normally it points from other to this)
                Vector3 contactNormal = -other.GetContact(0).normal;
                other.rigidbody.AddForce(contactNormal * _pushForce, ForceMode.Impulse);
            }
        }
    }
}
