using System;
using System.Collections.Generic;
using System.Text;

namespace GradCalc2
{
    public enum Subject
    {
        Mathematics,
        German,
        English,
        French,
        Russian,
        Spanish,
        Physics,
        Chemistry,
        Biology,
        LER,
        Religion,
        Sports,
        WP1,
        WP2,
        AL,
        Geography,
        Music,
        History,
        Politics,
        Art,
    }

    public static class SubjectExtensions
    {
        public static string T(this Subject subject)
        {
            return subject switch
            {
                Subject.Mathematics => "Mathe",
                Subject.German => "Deutsch",
                Subject.English => "Englisch",
                Subject.French => "Französisch",
                Subject.Russian => "Russisch",
                Subject.Spanish => "Spanisch",
                Subject.Physics => "Physik",
                Subject.Chemistry => "Chemie",
                Subject.Biology => "Biologie",
                Subject.LER => "LER",
                Subject.Religion => "Religion",
                Subject.Sports => "Sport",
                Subject.WP1 => "WP1",
                Subject.WP2 => "WP2",
                Subject.AL => "AL",
                Subject.Geography => "Geographie",
                Subject.Music => "Musik",
                Subject.History => "Geschichte",
                Subject.Politics => "PB",
                Subject.Art => "Kunst",
                _ => "Übersetzung fehlt",
            };
        }
    }
}
