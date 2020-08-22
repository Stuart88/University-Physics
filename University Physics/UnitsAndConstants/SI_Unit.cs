using System.Collections.Generic;
using System.Linq;

namespace UniversityPhysics.UnitsAndConstants
{
    internal static class Units
    {
        #region Public Fields

        public static readonly DerivedUnit Acceleration = new DerivedUnit("metres per second squared", "a", new List<BaseUnit>() { Length }, new List<BaseUnit>() { Time, Time });
        public static readonly BaseUnit AmountOfSubstance = new BaseUnit("mole", "mol");
        public static readonly DerivedUnit Area = new DerivedUnit("square metre", "A", new List<BaseUnit>() { Length, Length }, new List<BaseUnit>());
        public static readonly DerivedUnit Concentration = new DerivedUnit("amount of substance per metre cubed", "Concentration", new List<BaseUnit>() { AmountOfSubstance }, new List<BaseUnit>() { Length, Length, Length });
        public static readonly DerivedUnit Coulomb = new DerivedUnit("coulomb", "coulomb", new List<BaseUnit>() { Current }, new List<BaseUnit>() { Time });
        public static readonly BaseUnit Current = new BaseUnit("ampere", "A");
        public static readonly DerivedUnit CurrentDensity = new DerivedUnit("amps per square metre", "J", new List<BaseUnit>() { Current }, new List<BaseUnit>() { Length, Length });
        public static readonly DerivedUnit Density = new DerivedUnit("kilgorams per cubic metre", "ρ", new List<BaseUnit>() { Mass }, new List<BaseUnit>() { Length, Length, Length });
        public static readonly BaseUnit Length = new BaseUnit("metre", "m");
        public static readonly DerivedUnit Luminance = new DerivedUnit("luminosity", "Luminance", new List<BaseUnit>() { Luminosity }, new List<BaseUnit>() { Length, Length });
        public static readonly BaseUnit Luminosity = new BaseUnit("candela", "cd");
        public static readonly DerivedUnit MagneticFieldStrength = new DerivedUnit("amps per square metre", "H", new List<BaseUnit>() { Current }, new List<BaseUnit>() { Length });
        public static readonly BaseUnit Mass = new BaseUnit("kilogram", "kg");
        public static readonly BaseUnit Temperature = new BaseUnit("kelvin", "K");
        public static readonly BaseUnit Time = new BaseUnit("second", "s");
        public static readonly DerivedUnit Velocity = new DerivedUnit("metres per second", "V", new List<BaseUnit>() { Length }, new List<BaseUnit>() { Time });
        public static readonly DerivedUnit Volume = new DerivedUnit("cubic metre", "V", new List<BaseUnit>() { Length, Length, Length }, new List<BaseUnit>());
        public static readonly DerivedUnit WaveNumber = new DerivedUnit("inverse metre", "k", new List<BaseUnit>(), new List<BaseUnit>() { Length });

        #endregion Public Fields

        #region Public Classes

        public class BaseUnit
        {
            #region Public Properties

            public string Abbreviation { get; }

            public string Name { get; }

            #endregion Public Properties

            #region Public Constructors

            public BaseUnit(string name, string abbrev)
            {
                Name = name;
                Abbreviation = abbrev;
            }

            #endregion Public Constructors
        }

        public class DerivedUnit
        {
            #region Private Properties

            private string Abbreviation { get; set; }

            private List<BaseUnit> DimensionsDenominator { get; set; }

            private List<BaseUnit> DimensionsNumerator { get; set; }

            private string Name { get; set; }

            #endregion Private Properties

            #region Public Constructors

            public DerivedUnit(string name, string abbrev, List<BaseUnit> numerator, List<BaseUnit> denominator)
            {
                Name = name;
                Abbreviation = abbrev;
                DimensionsNumerator = numerator;
                DimensionsDenominator = denominator;
            }

            #endregion Public Constructors

            #region Public Methods

            public override string ToString()
            {
                string numeratorStr = "";
                var numerators = DimensionsNumerator.GroupBy(x => x.Name);
                foreach (var n in numerators)
                {
                    numeratorStr += n.First().Abbreviation;
                    if (n.Count() > 1)
                        numeratorStr += string.Format("^{0}", n.Count());
                }

                string denominatorStr = "";
                var denominators = DimensionsDenominator.GroupBy(x => x.Name);
                foreach (var d in denominators)
                {
                    denominatorStr += d.First().Abbreviation;
                    if (d.Count() > 1)
                        denominatorStr += string.Format("^{0}", d.Count());
                }

                return string.IsNullOrEmpty(denominatorStr)
                    ? numeratorStr
                    : string.Format("({0}) / ({1})", numeratorStr, denominatorStr);
            }

            #endregion Public Methods
        }

        #endregion Public Classes
    }
}