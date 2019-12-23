using System;
using System.Collections.Generic;
using System.Text;

namespace Blog_Common.Requests
{
    public class UpdatePostRequest
    {
        public int PostId { get; set; }

        public string Text { get; set; }
    }
}
