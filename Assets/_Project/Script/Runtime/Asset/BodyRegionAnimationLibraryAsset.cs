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
    /// <summary>
    /// make sure if the new parts are added, they are in ascending order
    /// and spaced by 100s to allow future insertions.
    /// same part groups should be clustered together seperated 1s.
    /// </summary>

    public enum BodyRegionEnum : short
    {
        none = -1,
        hairP1 = 0,
        hairP2 = 1,
        head = 100,
        ear = 200,
        body = 300,
        tail = 400,
        shadow = 500,
        wings = 600
    }

    [CreateAssetMenu(fileName = "New Base Body Animation Library", menuName = "Animation/BodyRegionAsset")]
    public class BodyRegionAnimationLibraryAsset : SpriteAnimationLibraryAssetDefinition
    {

        [SerializeField] private BodyRegionEnum applicableBaseBody = BodyRegionEnum.none;
        public BodyRegionEnum ApplicableBaseBody => this.applicableBaseBody;
        private string _cachedId;

        public override string LibraryId
        {
            get
            {
                if (string.IsNullOrEmpty(_cachedId))
                {
                    _cachedId = this.applicableGender.ToIdPart() + "_" +
                                this.applicableBaseBody.ToIdPart() + "_" +
                                this.variantName + "_" + this.applicableColorPermutation.ToIdPart();
                }
                return _cachedId;
            }
        }

        override protected void OnValidate()
        {
            base.OnValidate();
            this._cachedId = null;
            if (this.applicableBaseBody == BodyRegionEnum.none)
            {
                Debug.LogWarning($"BodyRegionAnimationLibraryAsset '{this.name}' has applicableBaseBody set to 'none'");
            }
        }

        protected override bool IsApplicable<TPart>(GenderEnum gender, TPart tpart, RacesEnum race)
        {

            bool genderOk = GenderOk(gender);
            bool partOk = PartOk(tpart);
            bool raceOk = RaceOk(race);

            if (!genderOk) Debug.LogError($"Gender mismatch: {gender} != {this.applicableGender} on library {this.LibraryId}");
            if (!partOk) Debug.LogError($"BodyRegion mismatch: {tpart} != {this.applicableBaseBody} on library {this.LibraryId}");
            if (!raceOk) Debug.LogError($"Race mismatch: {race} not in {string.Join(", ", this.applicableRaces)} on library {this.LibraryId}");

            return genderOk && partOk && raceOk;
        }

        protected override bool PartOk<TPart>(TPart tpart)
        {
            return tpart is BodyRegionEnum part
            && (part != BodyRegionEnum.none) && part == this.applicableBaseBody;
        }
    }
}