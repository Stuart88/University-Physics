using System;
using UniversityPhysics.Maths;
using UniversityPhysics.UnitsAndConstants;

namespace UniversityPhysics.ModernPhysics
{
    public class ComptonScatter
    {
        #region Public Properties

        public double IncidentPhotonWavelength { get; set; }

        #endregion Public Properties

        #region Public Constructors

        /// <param name="photonWavelength">The wavelength of the incident photon</param>
        public ComptonScatter(double photonWavelength)
        {
            this.IncidentPhotonWavelength = photonWavelength;
        }

        #endregion Public Constructors

        #region Public Methods

        /// <summary>
        /// Performs scatter.
        /// </summary>
        /// <param name="scatterAngleRadians">If left null, scatter will be to a random angle between 0 and pi</param>
        /// <returns></returns>
        public ComptonScatterResult PerformScatter(double? scatterAngleRadians = null)
        {
            Random rand = new Random();

            Energy incidentPhotonEnergy = Constants.Common.h * Constants.Common.C / IncidentPhotonWavelength;

            double resultantPhotonAngle = scatterAngleRadians ?? Math.PI * rand.NextDouble();
            double resultantPhotonWavelength = Constants.Common.h / (Constants.Common.M_e * Constants.Common.C) * (1 - Math.Cos(resultantPhotonAngle)) + IncidentPhotonWavelength;

            double E0 = Constants.Common.h * Constants.Common.C / IncidentPhotonWavelength;
            double E1 = Constants.Common.h * Constants.Common.C / resultantPhotonWavelength;

            double electronAngle = Math.Atan(E1 * Math.Sin(resultantPhotonAngle) / (E0 - E1 * Math.Cos(resultantPhotonAngle)));

            double electronKE = E0 - E1;
            double electronV = Math.Sqrt(2 * electronKE / Constants.Common.M_e);
            double vx = electronV * Math.Cos(electronAngle);
            double vy = electronV * Math.Sin(electronAngle);
            Vector electronVelocity = new Vector(vx, vy);

            Energy resultantPhotonEnergy = Constants.Common.h * Constants.Common.C / resultantPhotonWavelength;

            return new ComptonScatterResult
            {
                ElectronVelocity = electronVelocity,
                ElectronAngle = electronAngle,
                ResultantPhotonAngle = resultantPhotonAngle,
                ResultantPhotonWavelength = resultantPhotonWavelength,
                IncidentPhotonEnergy = incidentPhotonEnergy,
                ResultantPhotonEnergy = resultantPhotonEnergy,
                ElectronEnergy = incidentPhotonEnergy.Joules - resultantPhotonEnergy.Joules
            };
        }

        #endregion Public Methods

        #region Public Classes

        public class ComptonScatterResult
        {
            #region Public Properties

            public double ElectronAngle { get; internal set; }
            public Energy ElectronEnergy { get; internal set; }
            public Vector ElectronVelocity { get; internal set; }
            public Energy IncidentPhotonEnergy { get; internal set; }
            public double ResultantPhotonAngle { get; internal set; }
            public Energy ResultantPhotonEnergy { get; internal set; }
            public double ResultantPhotonWavelength { get; internal set; }

            #endregion Public Properties
        }

        #endregion Public Classes
    }
}