using UnityEngine;

namespace LuduArts.InteractionSystem.Data
{
    /// <summary>
    /// ScriptableObject that holds data for an item in the interaction system.
    /// </summary>
    [CreateAssetMenu(fileName = "New_Item", menuName = "Interaction System/Item Data")]
    public class ItemData : ScriptableObject
    {
        public string ItemID;
        public string ItemName;
        public Color ItemColor;
        public GameObject WorldPrefab;
        public Sprite Icon;
    }
}