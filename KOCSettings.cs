using System;
using UnityEngine;
using KSP;

namespace KerbalOccupationColors
{
    public class KOCSettings : GameParameters.CustomParameterNode
    {

        [GameParameters.CustomParameterUI("Automatically Apply Future Suit?", toolTip = "Should new Kerbals automatically equip the Future Suit by default?")]
        public bool automaticallyApplyFutureSuit = false;

        [GameParameters.CustomParameterUI("Apply Dress Code Enforcement to Kerbals on assignment as well as Kerbals at home?", toolTip = "Attempts to assign Future Suit to Kerbals in the field. May not work unless you save the game then reload it after exiting this menu.")]
        public bool dressCodeAppliesToAssignedKerbals = false;

        [GameParameters.CustomParameterUI("Force occupation color compliance on current hires?", toolTip = "(one time use then setting disables itself)")]
        public bool enforceDressCodeCompliance = false;

        public override string Section { get { return "KOC"; } }

        public override int SectionOrder { get { return 1; } }

        public override string Title { get { return "Kerbal Occupation Colors"; } }

        public override GameParameters.GameMode GameMode { get { return GameParameters.GameMode.ANY; } }

        public override bool HasPresets { get { return false; } }

        public override string DisplaySection
        {
            get
            {
                return "Kerbal Occupation Colors";
            }
        }
    }
}