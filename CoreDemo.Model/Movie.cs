using System;
using System.Collections.Generic;
using System.Text;

namespace CoreDemo.Model
{
    //电影
     public class Movie
    {
        public int Id { get; set; }
        public string Name { get; set; }//电影名称
        public int CinemaId { get; set; }//电影院ID
        public string Starring { get; set; }//演员
        public DateTime ReleaseDate { get; set; }//上映日期
    }
}
