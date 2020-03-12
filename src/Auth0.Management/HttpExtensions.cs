using System;
using System.Collections.Specialized;
using System.Text;
using System.Web;

namespace Auth0.Management
{
    public static class HttpExtensions
    {
        public static string ToQueryString(this NameValueCollection collection)
        {
            if(!collection.HasKeys())
                return string.Empty;
            
            var sb = new StringBuilder();

            for (var i = 0; i < collection.Count; i++)
            {
                string text = collection.GetKey(i);
                {
                    text = HttpUtility.UrlEncode(text);

                    string val = (text != null) ? (text + "=") : string.Empty;
                    var vals = collection.GetValues(i);

                    if (sb.Length > 0)
                        sb.Append('&');

                    if (vals == null || vals.Length == 0)
                        sb.Append(val);
                    else
                    {
                        if (vals.Length == 1)
                        {
                            sb.Append(val);
                            sb.Append(HttpUtility.UrlEncode(vals[0]));
                        }
                        else
                        {
                            for (var j = 0; j < vals.Length; j++)
                            {
                                if (j > 0)
                                    sb.Append('&');

                                sb.Append(val);
                                sb.Append(HttpUtility.UrlEncode(vals[j]));
                            }
                        }
                    }
                }
            }

            return "?" + sb.ToString().TrimStart('&');
        }
    }
}
