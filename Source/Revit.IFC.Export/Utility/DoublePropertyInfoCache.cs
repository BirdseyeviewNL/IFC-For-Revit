﻿//
// BIM IFC library: this library works with Autodesk(R) Revit(R) to export IFC files containing model geometry.
// Copyright (C) 2012  Autodesk, Inc.
// 
// This library is free software; you can redistribute it and/or
// modify it under the terms of the GNU Lesser General Public
// License as published by the Free Software Foundation; either
// version 2.1 of the License, or (at your option) any later version.
//
// This library is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the GNU
// Lesser General Public License for more details.
//
// You should have received a copy of the GNU Lesser General Public
// License along with this library; if not, write to the Free Software
// Foundation, Inc., 51 Franklin Street, Fifth Floor, Boston, MA  02110-1301  USA
//

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Autodesk.Revit.DB.IFC;

using GeometryGym.Ifc;

namespace Revit.IFC.Export.Utility
{
    /// <summary>
    /// Used to keep a cache of IFC double properties.
    /// </summary>
    public class DoublePropertyInfoCache : Dictionary<KeyValuePair<string, double>, IfcProperty>
    {
        /// <summary>
        /// Finds if it contains the property with the specified double value.
        /// </summary>
        /// <param name="propertyName">The property name.</param>
        /// <param name="value">The value.</param>
        /// <returns>True if it has, false otherwise.</returns>
        public IfcProperty Find(string propertyName, double value)
        {
            KeyValuePair<string, double> key = new KeyValuePair<string, double>(propertyName, value);

            IfcProperty propertyHandle;
            if (TryGetValue(key, out propertyHandle))
                return propertyHandle;

            return null;
        }

        /// <summary>
        /// Adds a new property of a double value to the cache.
        /// </summary>
        /// <param name="propertyName">The property name.</param>
        /// <param name="value">The value.</param>
        /// <param name="propertyHandle">The property handle.</param>
        public void Add(string propertyName, double value, IfcProperty propertyHandle)
        {
            KeyValuePair<string, double> key = new KeyValuePair<string, double>(propertyName, value);
            this[key] = propertyHandle;
        }
    }
}