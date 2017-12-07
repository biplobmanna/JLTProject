using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace BAL
{
    public class CityBAL
    {
        private readonly CityDAL _cityDal;

        public CityBAL()
        {
            _cityDal = new CityDAL();
        }

        public DataTable GetCities()=>_cityDal.GetCities();

        public string GetCity(int id) => _cityDal.GetCity(id);
    }
}
