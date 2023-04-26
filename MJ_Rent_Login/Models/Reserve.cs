using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace MJ_Rent_Login.Models
{
    public class Reserve
    {
        [Display(Name = "編號")]
        public int Id { get; set; }
        [Display(Name = "會議室編號")]
        public int RoomId { get; set; }
        [Display(Name = "使用者編號")]
        public string UserId { get; set; }
        //預約時間
        [Display(Name = "預約日期時間")]
        public DateTime ResDateTime { get; set; }
        //預約時間查長度,單位為分,有30, 60, 90, 120, 150, 180, 480(一天)可選
        [Display(Name = "預約時間長度")]
        public int ResTimeLength { get; set; }
    }
}
