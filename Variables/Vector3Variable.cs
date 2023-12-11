using UnityEngine;

namespace ArchitectureLibrary
{
    [CreateAssetMenu(fileName = "Vector3Variable", menuName = "Variable/Vector3", order = 0)]
    public class Vector3Variable : Variable<Vector3>
    {
        [SerializeField] private Vector3 _value = Vector3.zero;
        public override Vector3 value { get => _value; set => _value = value; }

        public Vector2 ToVector2() => new Vector2(value.x, value.y);

        public override string ToString() => $"{value.x}, {value.y}, {value.z}";
    }
}