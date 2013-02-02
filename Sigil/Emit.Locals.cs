﻿using Sigil.Impl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sigil
{
    public partial class Emit<DelegateType>
    {
        public Local DeclareLocal<Type>(string name = null)
        {
            return DeclareLocal(typeof(Type), name);
        }

        public Local DeclareLocal(Type type, string name = null)
        {
            if (type == null)
            {
                throw new ArgumentNullException("type");
            }

            name = name ?? AutoNamer.Next(this, "_local");

            var local = IL.DeclareLocal(type);

            var localIndex = NextLocalIndex;
            NextLocalIndex++;

            var ret = new Local(this, localIndex, type, local, name);

            UnusedLocals.Add(ret);

            return ret;
        }
    }
}
