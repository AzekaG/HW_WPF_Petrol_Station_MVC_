using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_WPF_Petrol_Station_MVC_.Model
{
    public  class PetrolCollection
    {
        List<Petrol> petrolList;

    public PetrolCollection() 
        {
            petrolList = new List<Petrol>();
            petrolList.Add(new Petrol() { Kind = "A-92" , Price = 44}) ;
            petrolList.Add(new Petrol() { Kind = "A-95", Price = 49 });
            petrolList.Add(new Petrol() { Kind = "A-98", Price = 59 });
            petrolList.Add(new Petrol() { Kind = "DT", Price = 48 });
            petrolList.Add(new Petrol() { Kind = "LPG", Price = 22 });
        }
    public List<Petrol> GetPetrolList => petrolList;

           
    }
}
