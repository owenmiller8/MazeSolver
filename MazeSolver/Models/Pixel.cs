using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;

namespace MazeSolver.Models
{
    public class Pixel
    {
        public Pixel(Color color)
        {
            IsPath = color.ToKnownColor() == KnownColor.White;
        }

        public bool IsPath { get; private set; }
    }
}
