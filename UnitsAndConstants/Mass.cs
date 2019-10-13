namespace UniversityPhysics.UnitsAndConstants
{
    public class Mass
    {
        #region Public Constructors

        public Mass(double m, Enums.MassMeasure massMeasure)
        {
            SetMass(m, massMeasure);
        }

        #endregion Public Constructors

        #region Public Properties

        public double AMUs { get; private set; }
        public double eV { get; private set; }
        public double Kilograms { get; private set; }
        public double MeV { get; private set; }
        public double PlanckMasses { get; private set; }
        public double SolarMasses { get; private set; }

        #endregion Public Properties

        #region Public Methods

        /// <summary>
        /// For needed for performing certain calculations, e.g. LINQ methods dealing with Mass type.
        /// </summary>
        /// <param name="m"></param>
        public static implicit operator double(Mass m)
        {
            return m.Kilograms;
        }

        public static implicit operator Mass(double m)
        {
            return new Mass(m, Enums.MassMeasure.Kilogram);
        }

        public static Mass operator -(Mass M, Mass m)
        {
            return M.Kilograms - m.Kilograms;
        }

        public static bool operator !=(double m, Mass M)
        {
            return !Maths.MathsHelpers.WithinTolerance(m, M.Kilograms);
        }

        public static bool operator !=(Mass M, double m)
        {
            return !Maths.MathsHelpers.WithinTolerance(m, M.Kilograms);
        }

        public static Mass operator *(Mass M, int m)
        {
            return M.Kilograms * m;
        }

        public static Mass operator *(Mass M, float m)
        {
            return M.Kilograms * m;
        }

        public static Mass operator *(Mass M, double m)
        {
            return M.Kilograms * m;
        }

        public static Mass operator *(int m, Mass M)
        {
            return M.Kilograms * m;
        }

        public static Mass operator *(float m, Mass M)
        {
            return M.Kilograms * m;
        }

        public static Mass operator *(double m, Mass M)
        {
            return M.Kilograms * m;
        }

        public static Mass operator /(Mass M, int m)
        {
            return M.Kilograms / m;
        }

        public static Mass operator /(Mass M, float m)
        {
            return M.Kilograms / m;
        }

        public static Mass operator /(Mass M, double m)
        {
            return M.Kilograms / m;
        }

        public static double operator /(int m, Mass M)
        {
            return m / M.Kilograms;
        }

        public static double operator /(float m, Mass M)
        {
            return m / M.Kilograms;
        }

        public static double operator /(double m, Mass M)
        {
            return m / M.Kilograms;
        }

        public static Mass operator +(Mass M, Mass m)
        {
            return M.Kilograms + m.Kilograms;
        }

        public static bool operator ==(double m, Mass M)
        {
            return Maths.MathsHelpers.WithinTolerance(m, M.Kilograms);
        }

        public static bool operator ==(Mass M, double m)
        {
            return Maths.MathsHelpers.WithinTolerance(m, M.Kilograms);
        }

        public void SetMass(double m, Enums.MassMeasure massMeasure)
        {
            switch (massMeasure)
            {
                case Enums.MassMeasure.Kilogram:
                    Kilograms = m;
                    SolarMasses = Kg_to_SolarMasses(m);
                    AMUs = Kg_to_AMUs(m);
                    eV = Kg_to_eV(m);
                    MeV = Kg_to_MeV(m);
                    PlanckMasses = Kg_to_PlanckMass(m);
                    break;

                case Enums.MassMeasure.SolarMass:
                    Kilograms = SolarMass_to_Kg(m);
                    SolarMasses = m;
                    AMUs = Kg_to_AMUs(Kilograms);
                    eV = Kg_to_eV(Kilograms);
                    MeV = Kg_to_MeV(Kilograms);
                    PlanckMasses = Kg_to_PlanckMass(Kilograms);
                    break;

                case Enums.MassMeasure.AtomicMassUnit:
                    Kilograms = AMUs_to_Kg(m);
                    SolarMasses = Kg_to_SolarMasses(Kilograms);
                    AMUs = m;
                    eV = Kg_to_eV(Kilograms);
                    MeV = Kg_to_MeV(Kilograms);
                    PlanckMasses = Kg_to_PlanckMass(Kilograms);
                    break;

                case Enums.MassMeasure.eV:
                    Kilograms = eV_to_Kg(m);
                    SolarMasses = Kg_to_SolarMasses(Kilograms);
                    AMUs = Kg_to_AMUs(Kilograms);
                    eV = m;
                    MeV = Kg_to_MeV(Kilograms);
                    PlanckMasses = Kg_to_PlanckMass(Kilograms);
                    break;

                case Enums.MassMeasure.MeV:
                    Kilograms = MeV_to_Kg(m);
                    SolarMasses = Kg_to_SolarMasses(Kilograms);
                    AMUs = Kg_to_AMUs(Kilograms);
                    eV = Kg_to_eV(Kilograms);
                    MeV = m;
                    PlanckMasses = Kg_to_PlanckMass(Kilograms);
                    break;

                case Enums.MassMeasure.PlanckMass:
                    Kilograms = PlanckMass_to_Kg(m);
                    SolarMasses = Kg_to_SolarMasses(Kilograms);
                    AMUs = Kg_to_AMUs(Kilograms);
                    eV = Kg_to_eV(Kilograms);
                    MeV = Kg_to_MeV(Kilograms);
                    PlanckMasses = m;
                    break;
            }
        }

        #endregion Public Methods

        #region Private Methods

        private double AMUs_to_Kg(double e)
        {
            return e * Constants.Common.u;
        }

        private double eV_to_Kg(double e)
        {
            return e * Constants.Common.eV_Mass;
        }

        private double Kg_to_AMUs(double e)
        {
            return e / Constants.Common.u;
        }

        private double Kg_to_eV(double e)
        {//uses e=mc^2
            return e / Constants.Common.eV_Mass;
        }

        private double Kg_to_MeV(double e)
        {
            return e / Constants.Common.MeV_Mass;
        }

        private double Kg_to_PlanckMass(double e)
        {
            return e / Constants.Common.PlanckMass;
        }

        private double Kg_to_SolarMasses(double e)
        {
            return e / Constants.AstrophysicalConstants.Solar_Mass;
        }

        private double MeV_to_Kg(double e)
        {
            return e * Constants.Common.MeV_Mass;
        }

        private double PlanckMass_to_Kg(double e)
        {
            return e * Constants.Common.PlanckMass;
        }

        private double SolarMass_to_Kg(double e)
        {
            return e * Constants.AstrophysicalConstants.Solar_Mass;
        }

        #endregion Private Methods
    }
}