using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public enum ENumType
    {
        [Description("Giới tính nam")]
        Male,
        [Description("Giới tính nữ")]
        Female,    
        [Description(" Bán Sản Phẩm ")]
        Sell,
        [Description(" Cho Sản Phẩm ")]
        Share,
        [Description(" Nhận Xách Tay ")]
        Ship,
        [Description(" Chia Sẻ Nhà Ở ")]
        House,
        [Description(" Chia Sẻ Công Việc ")]
        Job,
        [Description(" Cần Giúp Đỡ ")]
        Help
    }

    public enum Role
    {        
        [Description(" User đã đăng nhập vào hệ thống ")]
        User,
        [Description(" Cộng Tác Viên Quản Trị ")]
        Mod,
        [Description(" Quản Trị Hệ Thống ")]
        Admin
    }

    public enum DisplayLevel
    {
        [Description(" Chỉ hiển thị với User đã đăng nhập")]
        ForUser,
        [Description(" Hiển thị với cả khách chưa đăng nhập ")]
        ForGuess
    }
}
