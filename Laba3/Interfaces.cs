using System;
using System.Threading.Tasks;

namespace Lab3
{
    interface IShoot //стрельба танков
    {
        void Shoot(Map map, Tank tank);
    }
    interface IMovement
    {
        void Movement(Map map, Tank tank, char k); // движение танков
    }

}
