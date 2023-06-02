using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_WPF_Petrol_Station_MVC_.Model
{
    public class Cafe
    {
        List<PositionMenu> Menu;
        public Cafe() 
        {
        Menu = new List<PositionMenu>();
            Menu.Add(new PositionMenu() { Name = "Хот-Дог", Price =  50 });
            Menu.Add(new PositionMenu() { Name = "Бургер", Price = 59});
            Menu.Add(new PositionMenu(){ Name = "Картофель-Фри", Price = 40});
            Menu.Add(new PositionMenu() { Name = "Кола", Price = 28 });
        }
        public List<PositionMenu> GetMenuList => Menu;

    }
}
