﻿using System.Collections.Generic;

namespace Flagrum.Gfxbin.Gmdl.Constructs;

public struct ColorMap
{
    public IList<Color4> Colors;
}

public struct Color4
{
    public byte R;
    public byte G;
    public byte B;
    public byte A;
}