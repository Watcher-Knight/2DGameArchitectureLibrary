using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace ArchitectureLibrary
{
    [AddComponentMenu(ComponentPaths.axisEventManager)]
    public class AxisEventManager : EventManager
    {
        [SerializeField] private InputAction axis = new InputAction(expectedControlType: "Axis");
        [SerializeField] private AxisAction action;

        protected void OnValidate()
        {
            if (axis.bindings.Count == 0)
                axis.AddCompositeBinding("1DAxis").With("Positive", "<Keyboard>/rightArrow").With("Negative", "<Keyboard>/leftArrow");
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
            if (CheckConditions() && action != null) action.Invoke(axis.ReadValue<float>());
        }
    }
}