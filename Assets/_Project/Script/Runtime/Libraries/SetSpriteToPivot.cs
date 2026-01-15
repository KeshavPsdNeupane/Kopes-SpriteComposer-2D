// Part of Kope's SpriteComposer 2D | © 2026 Keshav Prasad Neupane
// Licensed under the MIT License. See LICENSE.md in the project root for details.

using UnityEngine;
public class SetSpriteToPivot : MonoBehaviour
{
    [SerializeField] private SpriteRenderer sr;
    private void Awake() => sr.spriteSortPoint = SpriteSortPoint.Pivot;
}