using System;
using System.Collections.Generic;
using System.Text;

namespace MLBStorage
{
    public class MediaClass
    {
        public string Title { get; set; }
        public string FilePath { get; set; }
        public string ThumbPath { get; set; }
        public string Format { get; set; }
        public string Genre { get; set; }
        public string Languages { get; set; }
        public bool? Subtitle { get; set; }
    }
}
