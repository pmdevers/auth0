using System;
using System.Collections.Generic;
using System.Text;

namespace Auth0.Management.Users.Models
{
    public class PagedUserLogResponse
    {
        public int Length { get; set; }
        public int Total { get; set; }
        public int Start { get; set; }
        public int Limit { get; set; }
        public UserLogResponse[] Logs { get; set; }
    }
}
