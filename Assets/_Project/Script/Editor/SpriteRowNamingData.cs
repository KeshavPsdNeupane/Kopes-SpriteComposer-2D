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
using System.Collections.Generic;

namespace Kope.SpriteComposer2D.Editor
{

    [System.Serializable]
    public struct SpriteRowData
    {
        public string category;           // e.g., "Walk", "Run", "Death"
        public List<string> subCategory;  // e.g., "Up", "Left", "Down", "Right"; empty/null for single-row animations
    }

    [System.Serializable]
    public struct SpriteRowDataSpecial
    {
        public SpriteRowData rowData;      // normal row
        public SpriteRowData specialData;  // optional special frames (like Idle)
        public bool hasSpecialSprites;
        public int specialStartIndex;      // at which frame index to insert special frames
        public int specialSize;            // how many frames to treat as special
    }

    [CreateAssetMenu(fileName = "SpriteRowNamingData", menuName = "Sprite Tools/Row Naming Data")]
    public class SpriteRowNamingData : ScriptableObject
    {
        public List<SpriteRowDataSpecial> rows = new();
    }
}