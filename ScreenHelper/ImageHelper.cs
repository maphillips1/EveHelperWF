using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace EveHelperWF.ScreenHelper
{
    public static class ImageHelper
    {
        public static Bitmap ConvertByteToBitmap(byte[] imageData)
        {
            MemoryStream mStream = new MemoryStream();
            mStream.Write(imageData, 0, Convert.ToInt32(imageData.Length));
            Bitmap bm = new Bitmap(mStream, false);
            mStream.Dispose();
            return bm;
        }
    }
}
