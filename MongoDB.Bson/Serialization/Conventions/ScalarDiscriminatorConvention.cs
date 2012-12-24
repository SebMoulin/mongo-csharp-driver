﻿/* Copyright 2010-2012 10gen Inc.
*
* Licensed under the Apache License, Version 2.0 (the "License");
* you may not use this file except in compliance with the License.
* You may obtain a copy of the License at
*
* http://www.apache.org/licenses/LICENSE-2.0
*
* Unless required by applicable law or agreed to in writing, software
* distributed under the License is distributed on an "AS IS" BASIS,
* WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
* See the License for the specific language governing permissions and
* limitations under the License.
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;

using MongoDB.Bson.IO;
using MongoDB.Bson.Serialization.Serializers;

namespace MongoDB.Bson.Serialization.Conventions
{
    /// <summary>
    /// Represents a discriminator convention where the discriminator is provided by the class map of the actual type.
    /// </summary>
    public class ScalarDiscriminatorConvention : StandardDiscriminatorConvention
    {
        // constructors
        /// <summary>
        /// Initializes a new instance of the ScalarDiscriminatorConvention class.
        /// </summary>
        /// <param name="elementName">The element name.</param>
        public ScalarDiscriminatorConvention(string elementName)
            : base(elementName)
        {
        }

        // public methods
        /// <summary>
        /// Gets the discriminator value for an actual type.
        /// </summary>
        /// <param name="nominalType">The nominal type.</param>
        /// <param name="actualType">The actual type.</param>
        /// <returns>The discriminator value.</returns>
        public override BsonValue GetDiscriminator(Type nominalType, Type actualType)
        {
            var classMap = BsonClassMap.LookupClassMap(actualType);
            return classMap.Discriminator;
        }
    }
}