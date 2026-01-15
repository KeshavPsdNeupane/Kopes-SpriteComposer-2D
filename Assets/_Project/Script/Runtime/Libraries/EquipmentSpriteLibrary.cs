// ==============================================================================
// Kope's SpriteComposer 2D
// © 2026 Keshav Prasad Neupane ("Kope")
// License: MIT License (See LICENSE.md in project root)
//
// Overview:
// A comprehensive framework for Unity designed for modular character assembly.
// Allows building characters from independent body parts and equipment while
// keeping animations synchronized through a data-driven approach.
// ==============================================================================

using UnityEngine;
namespace Kope.SpriteComposer2D
{

    public class EquipmentSpriteLibrary : CustomSpriteLibraryDefination
    {
        [Tooltip("Put the Equipment part this SpriteLibrary is associated with.")]
        [SerializeField] private EquipmentPartEnum currentBodyEquipmentPart = EquipmentPartEnum.none;
        public EquipmentPartEnum CurrentBodyEquipmentPart => currentBodyEquipmentPart;

        protected override void OnValidate()
        {
            if (this.currentBodyEquipmentPart == EquipmentPartEnum.none)
            {
                Debug.LogWarning($"EquipmentSpriteLibrary '{this.name}' has currentBodyEquipmentPart set to 'none'");
            }
        }
    }
}