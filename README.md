# Kerbal Occupation Colors
Automatically assigns the Future Suit's light colors based on occupation.Red for pilots, gold for engineers and blue for scientists. Requires the Serenity DLC.

Default colors are fully configurable via the KerbalOccupationColors.cfg file (contents below as an example)
Occupation titles should be lower case.

KERBAL_OCCUPATION_COLORS
{
    pilot
    {
        red = 1
        green = 0
        blue = 0
    }
    engineer
    {
        red = 0.75
        green = 0.5
        blue = 0
    }
    scientist
    {
        red = 0
        green = 0
        blue = 1
    }
    // tourists can't EVA in stock but if they are ever encountered in the world: this is their color
    tourist
    {
        red = 1
        green = 1
        blue = 1
    }
    // if a mod adds an occupation this mod can deal with it easily. Just add new nodes for each occupation.
}
