﻿using System;
using System.Collections.Generic;
using System.Text;

namespace UniversityPhysics.UnitsAndConstants
{
    public static class Elements
    {
        ////Data from: https://images-of-elements.com/element-properties.php
        ///Next: Rubidium

        #region Public Fields

        public static readonly Element Aluminium = new Element(13, 3, 13, "Al", "Aluminium", 26.920, 125, 3, 1, 933, 2740, 2.70);
        public static readonly Element Argon = new Element(18, 3, 18, "Ar", "Argon", 39.948, 71, 8, 3, 84, 87, 1.66);
        public static readonly Element Arsenic = new Element(33, 4, 15, "As", "Arsenic", 74.922, 115, 5, 1, null, 889, 5.72);
        public static readonly Element Beryllium = new Element(4, 2, 2, "Be", "Beryllium", 9.012, 10, 2, 1, 1551, 3750, 1.85);
        public static readonly Element Boron = new Element(5, 2, 13, "B", "Boron", 10.81, 85, 3, 2, 2349, 4200, 2.46);
        public static readonly Element Bromine = new Element(35, 4, 17, "Br", "Bromine", 79.904, 115, 7, 2, 266, 332, 3.14);
        public static readonly Element Calcium = new Element(20, 4, 2, "Ca", "Calcium", 40.078, 280, 2, 4, 1115, 1757, 1.54);
        public static readonly Element Carbon = new Element(4, 2, 14, "C", "Carbon", 12.011, 70, 4, 2, 3820, 5100, 3.51);
        public static readonly Element Chlorine = new Element(17, 3, 17, "Cl", "Chlorine", 35.453, 100, 7, 2, 172, 239, 2.95);
        public static readonly Element Chromium = new Element(24, 4, 6, "Cr", "Chromium", 51.996, 140, null, 3, 2130, 2945, 7.14);
        public static readonly Element Cobalt = new Element(27, 4, 9, "Co", "Cobalt", 58.993, 135, null, 1, 1768, 3200, 8.89);
        public static readonly Element Copper = new Element(29, 4, 11, "Cu", "Copper", 63.456, 135, null, 2, 1358, 2840, 8.92);
        public static readonly Element Fluorine = new Element(9, 2, 17, "F", "Fluorine", 18.998, 50, 7, 1, 53.5, 85.0, 1.58);
        public static readonly Element Gallium = new Element(31, 4, 13, "Ga", "Gallium", 69.723, 130, 3, 2, 303, 2477, 5.91);
        public static readonly Element Germanium = new Element(32, 4, 14, "Ge", "Germanium", 72.64, 125, 4, 4, 1211, 3093, 5.32);
        public static readonly Element Helium = new Element(2, 1, 18, "He", "Helium", 4.003, 31, 2, 2, null, 4.2, 0.17);
        public static readonly Element Hydrogen = new Element(1, 1, 1, "H", "Hydrogen", 1.008, 25, 1, 2, 14.1, 20.3, 0.084);
        public static readonly Element Iron = new Element(26, 4, 8, "Fe", "Iron", 55.845, 140, null, 4, 1808, 3023, 7.87);
        public static readonly Element Krypton = new Element(36, 4, 18, "Kr", "Krypton", 83.8, 88, 8, 5, 116, 120, 3.48);
        public static readonly Element Lithium = new Element(3, 2, 1, "Li", "Lithium", 6.941, 145, 1, 2, 454, 1615, 0.53);
        public static readonly Element Magnseium = new Element(12, 3, 2, "Mg", "Magnesium", 24.305, 150, 2, 3, 923, 1380, 1.74);
        public static readonly Element Manganese = new Element(25, 4, 7, "Mn", "Manganese", 54.938, 140, null, 1, 1517, 2235, 7.44);
        public static readonly Element Neon = new Element(10, 2, 18, "Ne", "Neon", 20.180, 38, 8, 3, 24.6, 27.1, 0.84);
        public static readonly Element Nickel = new Element(28, 4, 10, "Ni", "Nickel", 58.693, 135, null, 5, 1738, 3186, 8.91);
        public static readonly Element Nitrogen = new Element(7, 2, 15, "N", "Nitrogen", 14.007, 65, 5, 2, 63.1, 77.4, 1.17);
        public static readonly Element Oxygen = new Element(8, 2, 16, "O", "Oxygen", 15.999, 60, 6, 3, 54.4, 90.2, 1.33);
        public static readonly Element Phosphorus = new Element(15, 3, 15, "P", "Phosphorus", 30.974, 100, 5, 1, 317, 550, 1.82);
        public static readonly Element Potassium = new Element(19, 4, 1, "K", "Potassium", 39.098, 220, 1, 2, 337, 1032, 0.86);
        public static readonly Element Scandium = new Element(21, 4, 3, "Sc", "Scandium", 44.956, 160, null, 1, 1814, 3103, 2.99);
        public static readonly Element Selenium = new Element(34, 4, 16, "Se", "Selenium", 78.96, 115, 6, 5, 494, 958, 4.82);
        public static readonly Element Silicon = new Element(14, 3, 14, "Si", "Silicon", 28.085, 110, 4, 3, 1683, 2628, 2.33);
        public static readonly Element Sodium = new Element(11, 3, 1, "Na", "Sodium", 22.990, 180, 1, 1, 371, 1156, 0.97);
        public static readonly Element Sulfur = new Element(16, 3, 16, "S", "Sulfur", 62.065, 100, 6, 4, 338, 718, 2.06);
        public static readonly Element Titanium = new Element(22, 4, 4, "Ti", "Titanium", 47.867, 140, null, 5, 1941, 3560, 4.51);
        public static readonly Element Vanadium = new Element(23, 4, 5, "V", "Vanadium", 50.942, 135, null, 1, 2183, 3680, 6.09);
        public static readonly Element Zinc = new Element(30, 4, 12, "Zn", "Zinc", 65.39, 135, null, 5, 693, 1180, 7.14);

        #endregion Public Fields

        #region Public Classes

        public class Element
        {
            #region Public Constructors

            public Element()
            {
            }

            /// <summary>
            /// An element from the periodic table.
            /// </summary>
            /// <param name="number">Number of protons in nucleus</param>
            /// <param name="period">Horizontal position on periodic table</param>
            /// <param name="group">Vertical position on periodic table</param>
            /// <param name="symbol"></param>
            /// <param name="name"></param>
            /// <param name="mass">Kg</param>
            /// <param name="radius">Picometres ( x 10^-12)</param>
            /// <param name="valence">Numerical amount</param>
            /// <param name="isotopes">Numerical amount</param>
            /// <param name="meltingPoint">Kelvin</param>
            /// <param name="boilingPoint">Kelvin</param>
            /// <param name="density">kg/m^3</param>
            public Element(short number, short period, short group, string symbol, string name, Mass mass,
                double? radius, short? valence, short? isotopes, Temperature meltingPoint, Temperature boilingPoint,
                double? density)
            {
                Number = number;
                Period = period;
                Group = group;
                Symbol = symbol;
                Name = name;
                Mass = mass;
                if (radius.HasValue) Radius = (double)radius * 1E-12;
                Valence = valence;
                if (Isotopes.HasValue) Isotopes = (short)isotopes;
                MeltingPoint = meltingPoint;
                BoilingPont = boilingPoint;
                if (density.HasValue) Density = (double)density;
            }

            #endregion Public Constructors

            #region Public Properties

            /// <summary>
            /// Kelvin
            /// </summary>
            public Temperature BoilingPont { get; }

            /// <summary>
            /// kg/m^3 at 20 degrees C (standard ambient temperature)
            /// </summary>
            public double Density { get; }

            public short Group { get; }
            public short? Isotopes { get; }
            public Mass Mass { get; }

            /// <summary>
            /// Kelvin
            /// </summary>
            public Temperature MeltingPoint { get; }

            public string Name { get; }
            public short Number { get; }
            public short Period { get; }

            //m
            public double? Radius { get; }

            public string Symbol { get; }
            public short? Valence { get; }

            #endregion Public Properties
        }

        #endregion Public Classes
    }
}