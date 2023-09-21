using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Netcode;

namespace ArcadeVP
{
    public class SkidMarks : NetworkBehaviour
    {
        public TrailRenderer skidMark;
        private ParticleSystem smoke;
        public ArcadeVehicleController carController;
        float fadeOutSpeed;


        public Material skidMaterialDirt;

        private void Awake()
        {
            smoke = GetComponent<ParticleSystem>();
            skidMark = GetComponent<TrailRenderer>();
            skidMark.emitting = false;
            skidMark.startWidth = carController.skidWidth;

        }


        private void OnEnable()
        {
            skidMark.enabled = true;
        }
        private void OnDisable()
        {
            skidMark.enabled = false;
        }

        // Update is called once per frame
        void FixedUpdate()
        {
            if(!IsOwner) { return ; }
            TestTrailServerRpc();

            //if(!IsOwner) { return; }

            //if (carController.grounded())
            //{

            //    if (Mathf.Abs(carController.carVelocity.x) > 10)
            //    {
            //        fadeOutSpeed = 0f;
            //        skidMark.materials[0].color = Color.black;
            //        skidMark.emitting = true;
            //    }
            //    else
            //    {
            //        skidMark.emitting = false;
            //    }
            //}
            //else
            //{
            //    skidMark.emitting = false;

            //}
            //if (!skidMark.emitting)
            //{
            //    fadeOutSpeed += Time.deltaTime / 2;
            //    Color m_color = Color.Lerp(Color.black, new Color(0f, 0f, 0f, 0f), fadeOutSpeed);
            //    skidMark.materials[0].color = m_color;
            //    if (fadeOutSpeed > 1)
            //    {
            //        skidMark.Clear();
            //    }
            //}

            //// smoke
            //if (skidMark.emitting == true)
            //{
            //    smoke.Play();
            //}
            //else { smoke.Stop(); }

        }

        [ServerRpc()]
        public void TestTrailServerRpc()
        {
            //ParticleSystem ps1 = Instantiate(smoke, transform.position, transform.rotation);
            //ps1.GetComponent<NetworkObject>

            if(carController.grounded())
            {

                if (Mathf.Abs(carController.carVelocity.x) > 10)
                {
                    fadeOutSpeed = 0f;
                    skidMark.materials[0].color = new Color(178, 5, 5, .3f);
                    skidMark.emitting = true;
                }
                else
                {
                    skidMark.emitting = false;
                }
            }
            else
            {
                skidMark.emitting = false;

            }
            if (!skidMark.emitting)
            {
                //fadeOutSpeed += Time.deltaTime / 2;
                //Color m_color = Color.Lerp(Color.blue, new Color(0f, 0f, 0f, 0f), fadeOutSpeed);
                //skidMark.materials[0].color = m_color;
                //if (fadeOutSpeed > 1)
                {
                //    skidMark.Clear();
                }
            }

            // smoke
            if (skidMark.emitting == true)
            {
                smoke.Play();
            }
            else { smoke.Stop(); }
        }

    }
}
