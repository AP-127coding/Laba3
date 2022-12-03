using Lab3;

namespace EnvironmentTests
{
    [TestClass]
    public class EnvironmentTests
    {
        [TestMethod]
        public void ChangeBeton()
        {
            Tank tank = new PowerfulTank(1, 7, 4);

            Beton beton = new Beton();

            int hpExpected = 0;
            bool bulletPassabiltyExpected = true;

            beton.Change(tank);
            beton.Change(tank); // два выстрела в бетон

            int hpActual = beton.EnvHP;
            bool bulletPassabiltyActual = beton.BulletPassability;

            Assert.AreEqual(hpExpected, hpActual);
            Assert.AreEqual(bulletPassabiltyExpected, bulletPassabiltyActual);
        }
        [TestMethod]

        public void ChangeGlass()
        {
            Tank tank = new SpeedTank(1, 1, 3);

            Glass glass = new Glass();

            int hpExpected = 0;
            bool bulletPassabilityExpected = true;

            glass.Change(tank);

            int hpActual = glass.EnvHP;

            bool bulletPassabilityActual = glass.BulletPassability;

            Assert.AreEqual(hpExpected, hpActual);
            Assert.AreEqual(bulletPassabilityExpected, bulletPassabilityActual);
        }
    }
}