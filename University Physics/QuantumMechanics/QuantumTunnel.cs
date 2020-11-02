using System;
using UniversityPhysics.UnitsAndConstants;

namespace UniversityPhysics.QuantumMechanics
{
    public class QuantumTunnel
    {
        #region Public Properties

        public Energy BarrierEnergy { get; set; }

        public double BarrierWidth { get; set; }

        private double K => Math.Sqrt(2d * ParticleMass.Kilograms * (this.BarrierEnergy.Joules - ParticleEnergy.Joules)) / Constants.Common.hBar;
        public Energy ParticleEnergy { get; set; }

        public Mass ParticleMass { get; set; }
        public double TunnelProbability => G * Math.Exp(-2d * K * BarrierWidth);

        #endregion Public Properties

        #region Private Properties

        private double G => 16 * (ParticleEnergy.Joules / this.BarrierEnergy.Joules) * (1 - ParticleEnergy.Joules / this.BarrierEnergy.Joules);

        #endregion Private Properties

        #region Public Constructors

        public QuantumTunnel(Energy barrierEnergy, Energy particleEnergy, double barrierWidth, Mass particleMass)
        {
            BarrierEnergy = barrierEnergy;
            BarrierWidth = barrierWidth;
            ParticleEnergy = particleEnergy;
            ParticleMass = particleMass;
        }

        #endregion Public Constructors
    }
}