using Lab3;

namespace TestClass
{
    [TestClass]
    public class TankTests
    {
        [TestMethod]
        public void Shoot_BetonHp()
        {
            Map map = new Map();
            Tank tank = new BaseTank(1, 1, 4);

            int expected = 40;
            tank.Shoot(map, tank);

            int actual = map.environments[3, 1].EnvHP;

            Assert.AreEqual(expected, actual);

        }
        [TestMethod]
        public void Shoot_2Tanks()
        {
            Map map = new Map();

            Tank tank1 = new SpeedTank(1, 1, 2);

            Tank tank2 = new BaseTank(1, 8, 1);

            int expected = 30;

            tank2.Shoot(map, tank1);

            int actual = tank1.HP;

            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void Movement_Tank()
        {
            Map map = new Map();

            Tank tank = new BaseTank(1, 1, 2);
            Tank tank2 = new SpeedTank(2, 7, 2);
            char move = 'd';
            int xExpected = 1;
            int yExpected = 2;

            tank.Movement(map,tank2, move);

            int yActual = tank.Y;
            int xActual = tank.X;

            Assert.AreEqual(xExpected, xActual);
            Assert.AreEqual(yExpected, yActual);

        }
        [TestMethod]
        public void Movement_2Tanks()
        {
            Map map = new Map();
            Tank tank = new BaseTank(2, 6, 2);
            Tank tank2 = new SpeedTank(2, 7, 2);

            char move = 'd';

            int xExpected = 2;
            int yExpected = 6;

            tank.Movement(map, tank2, move);

            int xActual = tank.X;
            int yActual = tank.Y;

            Assert.AreEqual(xExpected, xActual);
            Assert.AreEqual(yExpected, yActual);
        }
        [TestMethod]
        public void NoneMovement_Tank()
        {
            Map map = new Map();

            Tank tank = new BaseTank(1, 1, 3);
            Tank tank2 = new SpeedTank(2, 7, 2);
            char move = 'w';

            int xExpected = 1;
            int yExpected = 1;

            tank.Movement(map,tank2, move);

            int yActual = tank.Y;
            int xActual = tank.X;

            Assert.AreEqual(xExpected, xActual);
            Assert.AreEqual(yExpected, yActual);

        }

        [TestMethod]
        public void MovementLavaDamage_Tank()
        {
            Map map = new Map();

            Tank tank = new BaseTank(10, 3, 3);
            Tank tank2 = new SpeedTank(2, 7, 2);
            char move = 'a';

            int xExpected = 10;
            int yExpected = 2;
            int hpExpected = 105;
            tank.Movement(map,tank2, move);

            int yActual = tank.Y;
            int xActual = tank.X;
            int hpActual = tank.HP;
            Assert.AreEqual(xExpected, xActual);
            Assert.AreEqual(yExpected, yActual);
            Assert.AreEqual(hpExpected, hpActual);
        }
        [TestMethod]
        public void MovementGrass_Tank()
        {
            Tank tank = new SpeedTank(1, 3, 2);
            Tank tank2 = new SpeedTank(2, 7, 2);
            Map map = new Map();

            char move = 'd';

            bool tankVisionExpected = false;

            tank.Movement(map,tank2, move);

            bool tankVisionActual = tank.Vision;

            Assert.AreEqual(tankVisionExpected, tankVisionActual);
        }
    }
}