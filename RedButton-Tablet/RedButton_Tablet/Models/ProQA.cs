using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedButton_Tablet
{
   public static class ProQA
    {
      public static readonly List<string> AbdominalPain = new List<string>()
        { "01a01 abdominal pain",
          "01c01 suspected aortic aneurysm(tearing/ripping pain)>50",
          "01c02 known aortic aneurysm",
          "01c03   faint or near faint > 50",
          "01c04   females faint / near faint 12 - 50",
          "01c05   males pain above naveel > 35",
          "01c06   females pain above navel > 45",
          "01d01   not alert" };
      public  static readonly List<string> Allergies = new List<string>()
        { "02A01 No Dyspnoea",
          "02A02 Spider bite (no priority symptoms)",
           "02B01 Unknown status/other codes not applicable",
           "02C01 Dyspnoea",
           "02C02 History of severe allergic reaction",
           "02C03 Minor Jelly-fish sting",
           "02D01 Not alert",
           "02D02 Difficulty speaking between breaths",
           "02D03 Swarming attack (bee, wasp)",
           "02D04 Snakebite",
           "02D05 Funnel Web spider",
           "02D06 Major Jelly-fish sting",
           "02E01 Ineffective Breathing"

        };
       public static readonly List<string> AnimalBites = new List<string>()
        {"03A01 Not dangerous body area",
         "03A02 Non-recent injuries (>6hrs)",
         "03A03 Superficial bites",
         "03B02 Serious Haemorrhage",
         "03B03 Unknown Status (3rd party caller)",
         "03D01 Unconscious or Arrest",
         "03D02 Not Alert.",
         "03D03 Chest or Neck injury (with difficulty breathing)",
         "03D04 Dangerous Body Area",
         "03D05 large Animal",
         "03D06 Exotic Animal",
         "03D07 Attack or multiple animals"

        };


    }
}
