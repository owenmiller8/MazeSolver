using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using MazeSolver.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MazeSolver.Pages
{
    public class IndexModel : PageModel
    {
        [BindProperty]
        public IFormFile Upload { get; set; }

        public List<Pixel> Pixels { get; private set; }

        public async Task OnPostAsync()
        {
            if (Upload.FileName.EndsWith(".png"))
            {
                Bitmap img = new Bitmap((Image)Upload);
                for (int x = 0; x < img.Width; x++)
                {
                    for (int y = 0; y < img.Height; y++)
                    {
                        //All the information we actually need about the pixel is its color 
                        //i.e if its a wall pixel or path pixel
                        Color pixel = img.GetPixel(x, y);

                        Pixels.Add(new Pixel(pixel));
                    }
                }
                //Call MazeSolver api here, passing in the list of pixels, and in the future the method e.g. personal, a* etc.
            }
            //Implement some call back / failsafe to ensure an error is thrown if the file being inputted isnt an image.
        }
    }
}
