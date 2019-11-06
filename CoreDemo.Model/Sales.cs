using System;
using System.Collections.Generic;
using System.Text;

namespace CoreDemo.Model
{
    //销量数据
   public class Sales
    {
        public int  CinemaId { get; set; }//电影院ID
        public int MovieId { get; set; }//电影ID
        public int AudienceCount { get; set; }//销量票数量
    }
}
