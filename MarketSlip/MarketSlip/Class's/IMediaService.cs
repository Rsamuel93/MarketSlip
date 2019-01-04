using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MarketSlip.Class_s
{
   
        public interface IMediaService

        {

            Task OpenGallery();

            void ClearFiles(List<string> filePaths);

        }
    
}
