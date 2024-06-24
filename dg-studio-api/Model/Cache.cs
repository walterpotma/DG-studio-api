using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace dg_studio_api.Model
{
    [Table("cache")]
    public class Cache
    {
        [Key]
        public int cachekey { get; set; }
        public string userid { get; private set; }
        public string reqtype { get; private set; }
        public string cachevalue { get; private set; }
        public DateTime expirationtime { get; private set; }
        public Cache( int id, string userid, string reqtype, string cachevalue, DateTime expirationtime)
        {
            this.cachekey = id;
            this.userid = userid;
            this.reqtype = reqtype;
            this.cachevalue = cachevalue;
            this.expirationtime = expirationtime;
        }
    }
}
