using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp2
{
    class Vlc
    {
        AxAXVLC.AxVLCPlugin2 VlcVideo;

        public Vlc(AxAXVLC.AxVLCPlugin2 AxVLCPlugin21)
        {
            VlcVideo = AxVLCPlugin21;
            
        }
        public void VlcLoad(string videoPath)
        {
            VlcVideo.playlist.add("file:///" + videoPath);
            VlcVideo.playlist.next();
        }
        
    }

}
