using UniversityPhysics.Astrophysics;

namespace UniversityPhysics.Helpers
{
    public static class TestObjects
    {
        #region Public Fields

        public static GravitationalBody Human = new GravitationalBody(1, 85);
        public static GravitationalBody KilogramBlock = new GravitationalBody(0.1, 1);

        #endregion Public Fields
    }
}