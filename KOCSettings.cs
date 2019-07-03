using System;

namespace KerbalOccupationColors
{
    public class KOCSettings : GameParameters.CustomParameterNode
    {

        [GameParameters.CustomParameterUI("Automatically Apply Future Suit?", toolTip = "Should new Kerbals automatically equip the Future Suit by default?")]
        public bool automaticallyApplyFutureSuit = false;

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