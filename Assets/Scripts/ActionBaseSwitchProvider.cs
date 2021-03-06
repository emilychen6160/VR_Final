using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Controls;
using UnityEngine.XR.Interaction.Toolkit.Inputs;

namespace UnityEngine.XR.Interaction.Toolkit
{
    /// <summary>
    /// A locomotion provider that allows the user to rotate their rig using a 2D axis input
    /// from an input system action.
    /// </summary>
    [AddComponentMenu("XR/Locomotion/Snap Turn Provider (Action-based)")]
    //[HelpURL(XRHelpURLConstants.k_ActionBasedSwitchProvider)]
    public class ActionBaseSwitchProvider : MonoBehaviour
    {
        [SerializeField]
        [Tooltip("The Input System Action that will be used to read Snap Turn data from the left hand controller. Must be a Value Vector2 Control.")]
        InputActionProperty m_LeftHandSwitchAction;
        /// <summary>
        /// The Input System Action that will be used to read Snap Turn data sent from the left hand controller. Must be a <see cref="InputActionType.Value"/> <see cref="Vector2Control"/> Control.
        /// </summary>
        public InputActionProperty leftHandSwitchAction
        {
            get => m_LeftHandSwitchAction;
            set => SetInputActionProperty(ref m_LeftHandSwitchAction, value);
        }


        /*
        [SerializeField]
        [Tooltip("The Input System Action that will be used to read Snap Turn data from the right hand controller. Must be a Value Vector2 Control.")]
        InputActionProperty m_RightHandSnapTurnAction;
        /// <summary>
        /// The Input System Action that will be used to read Snap Turn data sent from the right hand controller. Must be a <see cref="InputActionType.Value"/> <see cref="Vector2Control"/> Control.
        /// </summary>
        public InputActionProperty rightHandSnapTurnAction
        {
            get => m_RightHandSnapTurnAction;
            set => SetInputActionProperty(ref m_RightHandSnapTurnAction, value);
        }
        */

        /// <summary>
        /// See <see cref="MonoBehaviour"/>.
        /// </summary>
        protected void OnEnable()
        {
            m_LeftHandSwitchAction.EnableDirectAction();
            //m_RightHandSnapTurnAction.EnableDirectAction();
        }

        /// <summary>
        /// See <see cref="MonoBehaviour"/>.
        /// </summary>
        protected void OnDisable()
        {
            m_LeftHandSwitchAction.DisableDirectAction();
            //m_RightHandSnapTurnAction.DisableDirectAction();
        }

        /// <inheritdoc />
        public float ReadInput()
        {
            var leftHandValue = m_LeftHandSwitchAction.action?.ReadValue<float>() ??  0.0f;
            //var rightHandValue = m_RightHandSnapTurnAction.action?.ReadValue<Vector2>() ?? Vector2.zero;

            return leftHandValue;
            //return rightHandValue;
        }

        void SetInputActionProperty(ref InputActionProperty property, InputActionProperty value)
        {
            if (Application.isPlaying)
                property.DisableDirectAction();

            property = value;

            if (Application.isPlaying && isActiveAndEnabled)
                property.EnableDirectAction();
        }
    }
}
