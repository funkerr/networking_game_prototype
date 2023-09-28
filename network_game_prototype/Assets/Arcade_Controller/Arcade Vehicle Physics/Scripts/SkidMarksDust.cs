using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Netcode;

namespace ArcadeVP
{
    public class SkidMarksDust : NetworkBehaviour
    {
        public ArcadeVehicleController carController;
        public ParticleSystem dust;
      


        private void Awake()
        {
            //dust.Stop(true);
            //dustTest.SetActive(false);

            
         
        }


        //private void OnEnable()
        //{
        //    skidMark.enabled = true;
        //}
        //private void OnDisable()
        //{
        //    skidMark.enabled = false;
        //}

        // Update is called once per frame
        void FixedUpdate()
        {
            //if(Input.GetKey(KeyCode.W))
            //{
            //    dust.Play();
            //    Debug.Log(dust.name);
               
            //}
            //Debug.Log(carController.carVelocity.x.ToString());
            if (!IsOwner) { return ; }
            TestTrailServerRpc();
            dust.Play(true);



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
                    
                    dust.Play(true);
                    Debug.Log("Got to dust");
                    //dust.emission = true;
                }
                else 
                { 
                    
                    dust.Stop(); }
                }
                
        }
          

           
        

    }
}
