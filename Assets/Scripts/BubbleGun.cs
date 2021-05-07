using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

namespace UnityEngine.XR.Interaction.Toolkit
{
    [RequireComponent(typeof(XRGrabInteractable))]

    public class BubbleGun : MonoBehaviour
    {
        // Start is called before the first frame update

        bool state = false;

        public Transform StartPoint;
        public Transform EndPoint;
        public float ShootingForce;

        XRGrabInteractable m_InteractableBase;
        //Animator m_Animator;

        [SerializeField] ParticleSystem m_BubbleParticleSystem = null;

        const string k_AnimTriggerDown = "TriggerDown";
        const string k_AnimTriggerUp = "TriggerUp";
        const float k_HeldThreshold = 0.1f;

        float m_TriggerHeldTime;
        bool m_TriggerDown;

        // ****** bullet ******
        public GameObject generation;
        public GameObject gun;
        //

        int input_state;
        float last;
        float old;
        float now;
        float fire_state;
        float button_state;

        public ActionBaseSwitchProvider mySwitchProvider;

        protected void Start()
        {
            m_InteractableBase = GetComponent<XRGrabInteractable>();
            //m_Animator = GetComponent<Animator>();
            m_InteractableBase.selectExited.AddListener(DroppedGun);
            m_InteractableBase.activated.AddListener(TriggerPulled);
            m_InteractableBase.deactivated.AddListener(TriggerReleased);

            mySwitchProvider = GetComponent<ActionBaseSwitchProvider>();
            old = mySwitchProvider.ReadInput();
            //Debug.Log("old");
            //Debug.Log(old);

            //last = mySwitchProvider.ReadInput();
            //Debug.Log(last);
        }

        protected void Update()
        {
            mySwitchProvider = GetComponent<ActionBaseSwitchProvider>();
            now = mySwitchProvider.ReadInput();

            if (old == 0 && now == 1)
            {
                button_state = 1;
            }

            else if (old == now)
            {
                
            }

            else if (old == 1 && now == 0)
            {
                if (button_state == 1)
                {
                    button_state = 0;
                    if (fire_state == 1)
                    {
                        fire_state = 0;
                    }
                    else if (fire_state == 0)
                    {
                        fire_state = 1;
                    }
                }
            }
            old = now;

            if (fire_state == 0)
            {
                if (m_TriggerDown)
                {
                Vector3 Rectile = EndPoint.position - StartPoint.position;
               
                    Debug.Log("bullet");
                    Debug.Log(now);

                    if (state == false)
                    {
                        state = true;
                        GameObject shot = GameObject.Instantiate(generation, EndPoint.position, new Quaternion());
                        shot.GetComponent<Rigidbody>().AddForce(Rectile * ShootingForce);
                        StartCoroutine(ShootingGap());
                    }
                }
            }

            if (fire_state == 1)
            {
                if (m_TriggerDown)
                {
                m_TriggerHeldTime += Time.deltaTime;

                    Debug.Log("fire");
                    Debug.Log(now);

                    if (m_TriggerHeldTime >= k_HeldThreshold)
                    {
                        if (!m_BubbleParticleSystem.isPlaying)
                        {
                            m_BubbleParticleSystem.Play();
                        }
                    }
                }
            }
        }

        void TriggerReleased(DeactivateEventArgs args)
        {
            //m_Animator.SetTrigger(k_AnimTriggerUp);
            m_TriggerDown = false;
            m_TriggerHeldTime = 0f;
            m_BubbleParticleSystem.Stop();
        }

        void TriggerPulled(ActivateEventArgs args)
        {
            //m_Animator.SetTrigger(k_AnimTriggerDown);
            m_TriggerDown = true;
        }

        void DroppedGun(SelectExitEventArgs args)
        {
            // In case the gun is dropped while in use.
            //m_Animator.SetTrigger(k_AnimTriggerUp);

            m_TriggerDown = false;
            m_TriggerHeldTime = 0f;
            m_BubbleParticleSystem.Stop();
        }

        public void ShootEvent()
        {
            m_BubbleParticleSystem.Emit(1);
        }

        IEnumerator ShootingGap()
        {
            yield return new WaitForSeconds(1.0f);
            state = false;
        }
    }
}
