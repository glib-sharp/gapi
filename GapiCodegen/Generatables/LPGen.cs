// GtkSharp.Generation.LPGen.cs - long/pointer Generatable.
//
// Author: Mike Kestner <mkestner@novell.com>
//
// Copyright (c) 2004 Novell, Inc.
//
// This program is free software; you can redistribute it and/or
// modify it under the terms of version 2 of the GNU General Public
// License as published by the Free Software Foundation.
//
// This program is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the GNU
// General Public License for more details.
//
// You should have received a copy of the GNU General Public
// License along with this program; if not, write to the
// Free Software Foundation, Inc., 59 Temple Place - Suite 330,
// Boston, MA 02111-1307, USA.

using System.IO;
using GapiCodegen.Interfaces;

namespace GapiCodegen.Generatables
{
    public class LPGen : SimpleGen, IPropertyAccessor
    {
        public LPGen(string cType) : base(cType, "long", "0L") { }

        public override string MarshalType
        {
            get
            {
                return "IntPtr";
            }
        }

        public override string CallByName(string varName)
        {
            return "new IntPtr (" + varName + ")";
        }

        public override string FromNative(string var)
        {
            return "(long) " + var;
        }

        public void WriteAccessors(TextWriter sw, string indent, string fieldName)
        {
            sw.WriteLine(indent + "get {");
            sw.WriteLine(indent + "\treturn " + FromNative(fieldName) + ";");
            sw.WriteLine(indent + "}");
            sw.WriteLine(indent + "set {");
            sw.WriteLine(indent + "\t" + fieldName + " = " + CallByName("value") + ";");
            sw.WriteLine(indent + "}");
        }
    }
}
