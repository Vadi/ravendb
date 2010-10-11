﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Raven.Client.Linq
{
    /// <summary>
    /// A specialised query provider processor for querying dynamic types
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class DynamicQueryProviderProcessor<T> : RavenQueryProviderProcessor<T>
    {
        /// <summary>
        /// Creates a dynamic query proivder around the provided session
        /// </summary>
        /// <param name="session"></param>
        /// <param name="customizeQuery"></param>
        public DynamicQueryProviderProcessor(IDocumentSession session,
            Action<IDocumentQueryCustomization> customizeQuery) 
            : base(session, customizeQuery, "dynamic")
        {

        }

        /// <summary>
        /// Gets member info for the specified expression and the path to that expression
        /// </summary>
        /// <param name="expression"></param>
        /// <returns></returns>
        protected override ExpressionMemberInfo GetMember(System.Linq.Expressions.Expression expression)
        {
            var info = base.GetMember(expression);
            return new ExpressionMemberInfo(
                this.CurrentPath + info.Path,
                info.InnerMemberInfo);
        }
 
        
    
    }
}