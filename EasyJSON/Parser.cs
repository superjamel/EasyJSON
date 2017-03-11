#region License
// Copyright (c) 2017 Jamel de la Fuente
//
// Permission is hereby granted, free of charge, to any person
// obtaining a copy of this software and associated documentation
// files (the "Software"), to deal in the Software without
// restriction, including without limitation the rights to use,
// copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the
// Software is furnished to do so, subject to the following
// conditions:
//
// The above copyright notice and this permission notice shall be
// included in all copies or substantial portions of the Software.
//
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND,
// EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES
// OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND
// NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT
// HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY,
// WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING
// FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR
// OTHER DEALINGS IN THE SOFTWARE.
#endregion

using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace EasyJSON
{
	/// <summary>
	/// Provides methods to convert .Net object types or JSON types
	/// </summary>
	public class Parser
	{
		/// <summary>
		/// Serializes a class to a JSON format.
		/// </summary>
		/// <returns>The serialized JSON string.</returns>
		/// <param name="obj">Object needs to be serialized.</param>
		/// <typeparam name="T">The 1st type parameter.</typeparam>
		public static string JsonSerialize<T> (T obj)
		{
			StringBuilder builder = new StringBuilder();
			builder.Append("{");
			Type objectType = obj.GetType();
			List<PropertyInfo> properties = new List<PropertyInfo>(objectType.GetProperties());
			for (int i = 0; i < properties.Count; i++)
			{
				PropertyInfo property = properties[i];
				String propName = property.Name;
				var propVal = property.GetValue(obj, null);
				builder.Append(property.Name + ":");
				if (StringUtils.isString(propVal))
				{
					builder.Append("\"" + propVal + "\"");
				}
				else
				{
					builder.Append(propVal.ToString());
				}

				if (i<properties.Count-1)
				{
					builder.Append(",");
				}
			}
			builder.Append("}");
			return builder.ToString();
		}

	}
}
