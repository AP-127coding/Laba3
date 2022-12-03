using System;
using System.Threading.Tasks;


namespace Lab3
{
    interface IShoot
    {
        void Shoot(Map map, Tank tank);


    }
    interface IMovement
    {
        void Movement(Map map, char k);
    }

}
