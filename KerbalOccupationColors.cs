using System;
using System.Linq;
using UnityEngine;
using KSP;

namespace KerbalOccupationColors
{
    [KSPAddon(KSPAddon.Startup.FlightEditorAndKSC, false)]
    public class KerbalOccupationColors : MonoBehaviour
    {                  
        public KerbalOccupationColors()
        {            
        }

        public void Start()
        {
            GameEvents.onKerbalAdded.Add(KerbalDressCodeEnforcement);
            GameEvents.OnGameSettingsApplied.Add(OnGameSettingsApplied);
        }

        void OnGameSettingsApplied()
        {
            if (HighLogic.CurrentGame.Parameters.CustomParams<KOCSettings>().enforceDressCodeCompliance)
            {
                try
                {
                    EnforceDressCodeCompliance();
                }
                catch
                {
                }
                // We sent out our dress code memos; disable setting until player requests it again.
                HighLogic.CurrentGame.Parameters.CustomParams<KOCSettings>().enforceDressCodeCompliance = false;
            }
        }

        void EnforceDressCodeCompliance()
        {
            KerbalRoster kerbalRoster = HighLogic.fetch.currentGame.CrewRoster;
            foreach (ProtoCrewMember kerbal in kerbalRoster.Kerbals())
            {
                if (kerbal.rosterStatus != ProtoCrewMember.RosterStatus.Assigned || HighLogic.CurrentGame.Parameters.CustomParams<KOCSettings>().dressCodeAppliesToAssignedKerbals)
                {
                    KerbalDressCodeEnforcement(kerbal);
                }
            }
        }

        void KerbalDressCodeEnforcement(ProtoCrewMember kerbal)
        {
            Vector3 occupationColor = GetOccupationColor(kerbal.trait);
            kerbal.lightR = occupationColor[0];
            kerbal.lightG = occupationColor[1];
            kerbal.lightB = occupationColor[2];

            // Should the new Kerbal get a shiny nifty new Future Suit???
            if (HighLogic.CurrentGame.Parameters.CustomParams<KOCSettings>().automaticallyApplyFutureSuit)
                // SCORE!!!!111oneone
                kerbal.suit = ProtoCrewMember.KerbalSuit.Future;
        }

        public Vector3 GetOccupationColor(string occupation)
        {
            ConfigNode occupationColors = GameDatabase.Instance.GetConfigNodes("KERBAL_OCCUPATION_COLORS").Last();
            if (occupationColors != null)
            {
                if (occupationColors.HasNode(occupation))
                {
                    ConfigNode colors = occupationColors.GetNode(occupation);
                    float red = 0f;
                    float green = 0f;
                    float blue = 0f;

                    if (colors.HasValue("red"))
                        float.TryParse(colors.GetValue("red"), out red);
                    if (colors.HasValue("green"))
                        float.TryParse(colors.GetValue("green"), out green);
                    if (colors.HasValue("blue"))
                        float.TryParse(colors.GetValue("blue"), out blue);

                    return new Vector3(red, green, blue);
                }
                Debug.Log("[KerbalOccupationColors] occupation " + occupation + " not found in KERBAL_OCCUPATION_COLORS");
            }
            else
                Debug.Log("[KerbalOccupationColors] KERBAL_OCCUPATION_COLORS config not found");
            // Couldn't find an entry for this occupation or couldn't find config, so return default colors.
            return new Vector3(1f, 0.5176f, 0f);
        }
    }
}
