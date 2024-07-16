﻿namespace Intersect.Collections
{

    public partial struct SanitizedValue<T>
    {

        public T Before { get; }

        public T After { get; }

        public SanitizedValue(T before, T after)
        {
            Before = before;
            After = after;
        }

    }

}
