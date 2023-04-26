
    using System.ComponentModel.DataAnnotations;
    using Microsoft.EntityFrameworkCore.Metadata.Internal;
    using System.ComponentModel.DataAnnotations.Schema;

namespace MJ_Rent_Login.Models
{
    public class MeetRoom
    {
        [Display(Name = "編號")]
        public int Id { get; set; }
        [Display(Name = "名稱")]
        public string Name { get; set; }
        [Display(Name = "描述")]
        public string Description { get; set; }
        [Display(Name = "類型")]
        public string Type { get; set; }
        [Display(Name = "容納人數")]
        public int Capacity { get; set; }
        [Display(Name = "是否有攝影機")]
        public Boolean Haveprojector { get; set; }
        [Display(Name = "是否有白板")]
        public Boolean HaveWhiteboard { get; set; }
        [Display(Name = "是否可使用")]
        public Boolean IsActive { get; set; }


        public MeetRoom() { }
    }
}
