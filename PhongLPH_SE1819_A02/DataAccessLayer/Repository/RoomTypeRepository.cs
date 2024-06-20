using BussinessObjectLayer;
using DataAccessLayer.DataAccessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repository
{
    public class RoomTypeRepository : IRoomTypeRepository
    {
        public IEnumerable<RoomType> GetRoomTypes() => RoomTypeDAO.GetInstance().GetRoomTypes();
    }
}
