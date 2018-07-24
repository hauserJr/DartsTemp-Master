using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Darts.Lib.DBTemp;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using static Darts.Lib.Services.DBServices;

namespace DartsTemp_Master.Controllers
{
    [Produces("application/json")]
    [Route("api/Messages")]
    public class MessagesController : Controller
    {
        public IDBAction getDB;
        public DartTempContext db;

        public MessagesController(IDBAction _getDB, DartTempContext _db)
        {
            this.getDB = _getDB;
            this.db = _db;
        }

        // GET: api/Messages
        [HttpGet]
        public IEnumerable<Temp> Getmessages()
        {
            //Injection Service取得資料
            var query = this.getDB.ReadRangeData<Temp>();

            //直接Injection DB取得資料
            var GetDate = this.db.Set<Temp>().AsNoTracking();
            return query;
        }
    }
}