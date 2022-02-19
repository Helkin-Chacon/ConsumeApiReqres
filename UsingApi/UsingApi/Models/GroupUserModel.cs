using System;
using System.Collections.Generic;
using System.Text;

namespace UsingApi.Models
{
    public class GroupUserModel
    {
        public int page { get; set; }
        public int per_page { get; set; }
        public int total { get; set; }
        public int total_pages { get; set; }
        public List<UserModel> data { get; set; }
    }
}
