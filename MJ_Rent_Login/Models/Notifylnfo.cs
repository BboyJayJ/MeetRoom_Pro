using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace MJ_Rent_Login.Models
{
    public class Notifylnfo
    {
        public int Id { get; set; }
        [Display(Name = "使用者編號")]
        public string UserId { get; set; }
        [Display(Name = "通知內容")]
        //通知內容
        public string InfoContext { get; set; }
        [Display(Name = "是否已通知")]
        //是否已通知
        public Boolean HaveNotify { get; set; }
    }
}
