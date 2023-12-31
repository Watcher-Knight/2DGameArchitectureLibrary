using UnityEngine;
using UnityEngine.InputSystem;

namespace ArchitectureLibrary
{
    [AddComponentMenu(ComponentPaths.v2AxisEventManager)]
    public class V2AxisEventManager : EventManager
    {
        [SerializeField] private InputAction axis = new InputAction(expectedControlType: "Vector2");
        [SerializeField] private V2AxisAction action;

        protected void OnValidate()
        {
            if (axis.bindings.Count == 0)
                axis.AddCompositeBinding("2DVector")
                    .With("Up", "<Keyboard>/upArrow")
                    .With("Down", "<Keyboard>/downArrow")
                    .With("Left", "<Keyboard>/leftArrow")
                    .With("Right", "<Keyboard>/rightArrow");
        }

        private void OnEnable()
        {
            axis.Enable();
        }

        private void OnDisable()
        {
            axis.Disable();
        }

        private void Update()
        {
            if (CheckConditions() && action != null) action.Invoke(axis.ReadValue<Vector2>());
        }
    }
}