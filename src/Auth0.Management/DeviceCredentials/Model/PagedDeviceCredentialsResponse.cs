using System;
using System.Collections.Generic;
using System.Text;

namespace Auth0.Management.DeviceCredentials.Model
{
    public class PagedDeviceCredentialsResponse
    {
        public class PagedUserLogResponse
        {
            public int Length { get; set; }
            public int Total { get; set; }
            public int Start { get; set; }
            public int Limit { get; set; }
            public GetDeviceCredentialsResponse[] Logs { get; set; }
        }
    }
}
