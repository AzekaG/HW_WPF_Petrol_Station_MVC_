using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HW_WPF_Petrol_Station_MVC_.Model;

namespace HW_WPF_Petrol_Station_MVC_
{
    public class Controller
    {
        PetrolCollection PetrolCollection;
        Cafe cafe;
        public Controller()
        {
            PetrolCollection = new PetrolCollection();
            cafe = new Cafe();
        }

        public List<Petrol> GetPetrolCollection() => PetrolCollection.GetPetrolList;
        public List<PositionMenu> GetCafe() => cafe.GetMenuList;
        public string GetNamePositionIndex(int index) => PetrolCollection.GetPetrolList.ElementAt(index).Kind;
        public double GetPricePositionIndex(int index) => PetrolCollection.GetPetrolList.ElementAt(index).Price;


    } 
}
