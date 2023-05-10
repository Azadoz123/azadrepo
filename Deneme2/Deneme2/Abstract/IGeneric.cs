using Deneme2.Models;

namespace Deneme2.Abstract
{
    public interface IGeneric<Vehicle> 
    {
        //List<T> Set<T>();
        List<T> Set<T> ();

        List<Vehicle> getById();
    }
}
