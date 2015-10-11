using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace E.AppServices.Interface
{
    public interface IImageServices
    {
        string SaveImage(Image imagem, string name);

        string GrayScale(Image img, string name);
    }
}
