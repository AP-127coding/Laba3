using System;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization.Json;
using System.Xml.Serialization;
namespace Lab3


{
    public abstract partial class Tank
    {
        public int Power { get { return power; } }
        public int X { get { return x; } }
        public int Y { get { return y; } }
        public int HP { get { return hp; } }
        public bool Vision { get { return vision; } }
        public int Direction { get { return direction; } }
        public partial void Shoot(Map map, Tank tank)
        {
            int xtemp = x;
            int ytemp = y;
            switch (direction)
            {
                case 1:
                    {
                        while (map.GetEnvironments(xtemp, ytemp - 1).BulletPassability == true && (tank.x != xtemp || tank.y != ytemp - 1))
                        {
                            ytemp--;
                        }
                        if (tank.x == xtemp && tank.y == ytemp - 1) tank.hp -= power;
                        else
                        {
                            if (map.GetEnvironments(xtemp, ytemp - 1).EnvHP > 0)
                            {
                                map.GetEnvironments(xtemp, ytemp - 1).Change(this);
                                if (map.GetEnvironments(xtemp, ytemp - 1).EnvHP == 0)
                                {
                                    map.environments[xtemp, ytemp - 1] = map.GetEnvironments(1, 1);
                                }
                            }
                        }
                    }
                    break;
                case 2:
                    {
                        while (map.GetEnvironments(xtemp, ytemp + 1).BulletPassability == true && (tank.x != xtemp || tank.y != ytemp + 1))
                        {
                            ytemp++;
                        }
                        if (tank.x == xtemp && tank.y == ytemp + 1) tank.hp -= power;
                        else
                        {
                            if (map.GetEnvironments(xtemp, ytemp + 1).EnvHP > 0)
                            {
                                map.GetEnvironments(xtemp, ytemp + 1).Change(this);
                                if (map.GetEnvironments(xtemp, ytemp - 1).EnvHP == 0)
                                {
                                    map.environments[xtemp, ytemp + 1] = map.GetEnvironments(1, 1);
                                }
                            }
                        }
                    }
                    break;
                case 3:
                    {
                        while (map.GetEnvironments(xtemp - 1, ytemp).BulletPassability == true && (tank.x != xtemp - 1 || tank.y != ytemp))
                        {
                            xtemp--;
                        }
                        if (tank.x == xtemp - 1 && tank.y == ytemp) tank.hp -= power;
                        else
                        {
                            if (map.GetEnvironments(xtemp - 1, ytemp).EnvHP > 0)
                            {
                                map.GetEnvironments(xtemp - 1, ytemp).Change(this);
                                if (map.GetEnvironments(xtemp, ytemp - 1).EnvHP == 0)
                                {
                                    map.environments[xtemp - 1, ytemp] = map.GetEnvironments(1, 1);
                                }
                            }
                        }
                    }
                    break;
                case 4:
                    {
                        while (map.GetEnvironments(xtemp + 1, ytemp).BulletPassability == true && (tank.x != xtemp + 1 || tank.y != ytemp))
                        {
                            xtemp++;
                        }
                        if (tank.x == xtemp + 1 && tank.y == ytemp) tank.hp -= power;
                        else
                        {
                            if (map.GetEnvironments(xtemp + 1, ytemp).EnvHP > 0)
                            {
                                map.GetEnvironments(xtemp + 1, ytemp).Change(this);
                                if (map.GetEnvironments(xtemp, ytemp - 1).EnvHP == 0)
                                {
                                    map.environments[xtemp + 1, ytemp] = map.GetEnvironments(1, 1);
                                }
                            }
                        }
                    }
                    break;
            }

        }
        public partial void Movement(Map map, char k)
        {

            switch (k)
            {
                case 'i':
                case 'w':
                    {
                        direction = 3;
                        if (map.GetEnvironments(x - 1, y).EnvHP == 0)
                        {
                            OwnMovement();
                            x--;
                            hp -= map.GetEnvironments(x, y).Damage;
                            if (map.GetEnvironments(x, y).EnvVision == false)
                            {
                                vision = false;
                            }
                        }

                    }
                    break;

                case 'k':
                case 's':
                    {
                        direction = 4;
                        if (map.GetEnvironments(x + 1, y).EnvHP == 0)
                        {
                            OwnMovement();
                            x++;
                            hp -= map.GetEnvironments(x, y).Damage;
                            if (map.GetEnvironments(x, y).EnvVision == false)
                            {
                                vision = false;
                            }
                        }
                    }
                    break;

                case 'l':
                case 'd':
                    {
                        direction = 2;
                        if (map.GetEnvironments(x, y + 1).EnvHP == 0)
                        {
                            OwnMovement();
                            y++;
                            hp -= map.GetEnvironments(x, y).Damage;
                            if (map.GetEnvironments(x, y).EnvVision == false)
                            {
                                vision = false;
                            }
                        }
                    }
                    break;

                case 'j':
                case 'a':
                    {
                        direction = 1;
                        if (map.GetEnvironments(x, y - 1).EnvHP == 0)
                        {
                            OwnMovement();
                            y--;
                            hp -= map.GetEnvironments(x, y).Damage;
                            if (map.GetEnvironments(x, y).EnvVision == false)
                            {
                                vision = false;
                            }
                        }
                    }
                    break;

            }
        }

    }
    public partial class BaseTank
    {

        public override partial void OwnMovement()
        {
            Thread.Sleep(300);
        }
    }
    partial class PowerfulTank
    {

        public override partial void OwnMovement()
        {
            Thread.Sleep(500);
        }
    }
    partial class SpeedTank
    {

        public override partial void OwnMovement()
        {
            Thread.Sleep(100);
        }
    }
    abstract public partial class Environment
    {
        public virtual partial void Change(Tank tank)
        {
            Console.WriteLine("Свойства клетки изменились");
        }
    }
    public partial class Beton
    {
        public override partial void Change(Tank tank)
        {
            if (tank.Power > envhp)
            {
                envhp = 0;
                bulletPassability = true;
            }
            else envhp -= tank.Power;

        }
    }
    public partial class Glass
    {
        public override partial void Change(Tank tank)
        {
            if (tank.Power > envhp)
            {
                envhp = 0;
                bulletPassability = true;
            }
            else envhp -= tank.Power;
        }
    }
    public partial class Grass
    {

    }
    public partial class Lava
    {
    }
    public partial class Map
    {
        public partial Environment GetEnvironments(int x, int y)
        {
            return environments[x, y];
        }
    }


    class Program
    {
        static Map MapSerialisation(Map map, bool flag)
        {

            Environment[] environments2 = new Environment[144];
            FileStream mapfile = File.Create("map.xml");

            int ind = 0;
            for (int i = 0; i < 12; i++)
            {
                for (int j = 0; j < 12; j++)
                {
                    environments2[ind] = map.environments[i, j];
                    ind++;
                }
            }
            XmlSerializer mapdata = new XmlSerializer(typeof(Environment[]));
            mapdata.Serialize(mapfile, map.environments);

            mapfile.Close();
            if (flag == true)
            {
                mapfile = File.OpenRead("map.xml");
                Environment[] environmentstemp = new Environment[144];
                environmentstemp = mapdata.Deserialize(mapfile) as Environment[];

                for (int i = 0; i < 12; i++)
                {
                    for (int j = 0; j < 12; j++)
                    {
                        map.environments[i, j] = environmentstemp[ind];
                        ind++;
                    }
                }

            }
            return map;
        }
        static Tank TankSerialisation(Tank tank, bool flag)
        {
            if (flag == true)
            {
                FileStream tankdfile = File.OpenRead("tank.json");
                DataContractJsonSerializer tankddata = new DataContractJsonSerializer(tank.GetType());
                Tank tankd1 = tankddata.ReadObject(tankdfile) as Tank;
                return tankd1;
            }
            FileStream tankfile = File.Create("tank.json");
            DataContractJsonSerializer tankdata = new DataContractJsonSerializer(tank.GetType());
            tankdata.WriteObject(tankfile, tank);
            tankfile.Close();

            return tank;
        }
        static Tank Tank2Serialisation(Tank tank2, bool flag)
        {
            if (flag == true)
            {
                FileStream tankd2file = File.OpenRead("tank2.json");
                DataContractJsonSerializer tank2ddata = new DataContractJsonSerializer(tank2.GetType());
                Tank tankd2 = tank2ddata.ReadObject(tankd2file) as Tank;
                return tankd2;
            }
            FileStream tank2file = File.Create("tank2.json");
            DataContractJsonSerializer tank2data = new DataContractJsonSerializer(tank2.GetType());
            tank2data.WriteObject(tank2file, tank2);
            tank2file.Close();

            return tank2;
        }

        static void Main()
        {
            Map map = new Map();
            Tank tank = new SpeedTank(1, 1, 2);
            Tank tank2 = new BaseTank(1, 7, 1);


            while (tank.HP > 0 && tank2.HP > 0)
            {
                char k = Convert.ToChar(Console.ReadLine());
                switch (k)
                {
                    case 'p':
                        {
                            for (int i = 0; i < 12; i++)
                            {
                                for (int j = 0; j < 12; j++)
                                {
                                    Console.WriteLine($"{map.environments[i, j].GetType().Name}");
                                }
                            }
                        }
                        break;
                    case 'i': tank2.Movement(map, k); break;
                    case 'w': tank.Movement(map, k); break;
                    case 'k': tank2.Movement(map, k); break;
                    case 's': tank.Movement(map, k); break;
                    case 'l': tank2.Movement(map, k); break;
                    case 'd': tank.Movement(map, k); break;
                    case 'j': tank2.Movement(map, k); break;
                    case 'a': tank.Movement(map, k); break;
                    case 'x': tank.Shoot(map, tank2); break;
                    case 'm': tank2.Shoot(map, tank); break;
                    case 'q':
                        {
                            // map = MapSerialisation(map, false);
                            tank = TankSerialisation(tank, false);
                            tank2 = Tank2Serialisation(tank2, false);
                        }; break;
                    case 'z':
                        {
                            //map = MapSerialisation(map, true);
                            tank = TankSerialisation(tank, true);
                            tank2 = Tank2Serialisation(tank2, true);
                        }
                        break;
                }

            }
            Console.WriteLine("GAME OVER!");

        }
    }
}
