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
using UnityEngine.U2D.Animation;
using UnityEngine;

namespace Kope.SpriteComposer2D
{
    /// <summary>
    /// Custom SpriteLibrary that includes body part information and a method to clear overrides.
    /// Used to manage sprite overrides for different equipping parts. While creating character customization systems.
    /// </summary>
    [RequireComponent(typeof(SpriteResolver), typeof(SetSpriteToPivot))]
    public abstract class CustomSpriteLibraryDefination : SpriteLibrary
    {
        [SerializeField] private SpriteResolver resolver;
        public void ClearOverride(SpriteLibraryAsset defaultAsset)
        {
            this.spriteLibraryAsset = defaultAsset;
            RefreshSpriteResolvers();
        }
        protected abstract void OnValidate();


        public void SetActiveLabel(string category, string label)
        {
            if (this.resolver != null)
            {
                this.resolver.SetCategoryAndLabel(category, label);
                RefreshSpriteResolvers();

            }
        }
    }
}