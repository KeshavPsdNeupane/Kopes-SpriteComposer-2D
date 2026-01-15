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
    public class BodyRegionSpriteLibrary : CustomSpriteLibraryDefination
    {
        [Tooltip("Put the body region this SpriteLibrary is associated with.")]
        [SerializeField] private BodyRegionEnum currentBodyRegion = BodyRegionEnum.none;
        public BodyRegionEnum CurrentBodyRegion => currentBodyRegion;

        protected override void OnValidate()
        {
            if (this.currentBodyRegion == BodyRegionEnum.none)
            {
                Debug.LogWarning($"BodyRegionSpriteLibrary '{this.name}' has bodyRegion set to 'none'");
            }
        }
    }
}