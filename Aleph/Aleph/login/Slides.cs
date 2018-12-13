using System;
using System.Collections.Generic;
using System.Text;

namespace Aleph.login
{
    public class Slides
    {
        public Slides(String image, String description)
        {
            Image = image;
            Description = description;
        }

        public String Image { get; set; }
        public String Description { get; set; }
    }
}
