using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Zil.Repository.QueryHelpers.Mongo
{
    public class DynamicQuery
    {

        private static readonly string AndOperator = " and ";
        private static readonly string OrOperator = " or ";
        private static readonly string NotOperator = " not ";
        private static readonly string[] stringSeparators = new string[] { AndOperator, OrOperator, NotOperator };

        public static Expression<Func<TSource, bool>> BuildAdvanceSearchExpressionTree<TSource>(string searchTerm, string EntityName)
        {
            ParameterExpression pe = Expression.Parameter(typeof(TSource), EntityName);
            string[] result = searchTerm.Split(stringSeparators, StringSplitOptions.RemoveEmptyEntries);
            var operatorIndexes = GetListOfSortedOperatorIndexes(searchTerm);
            Expression searchExpression = null;

            #region DeviceID
            var employerExpression = GetExpression<TSource>(result, searchTerm, "UniqueData", operatorIndexes, pe, false);
            searchExpression = searchExpression == null ? employerExpression : Expression.OrElse(searchExpression, employerExpression);
            #endregion


            return Expression.Lambda<Func<TSource, bool>>(searchExpression, pe);

        }

        private static List<OperatorIndexes> GetListOfSortedOperatorIndexes(string input)
        {

            input = input.ToLower();
            string[] result = input.Split(stringSeparators, StringSplitOptions.RemoveEmptyEntries);

            List<OperatorIndexes> operatorIndexes = new List<OperatorIndexes>();
            var andOperatorIndexes = AllIndexesOf(input, stringSeparators[0]);
            var orOperatorIndexes = AllIndexesOf(input, stringSeparators[1]);

            if (andOperatorIndexes.Count > 0)
            {
                operatorIndexes.AddRange(andOperatorIndexes);
            }

            if (orOperatorIndexes.Count > 0)
            {
                operatorIndexes.AddRange(orOperatorIndexes);
            }

            if (operatorIndexes.Count > 0)
            {
                var sorterOperatorIndexes = operatorIndexes.ToList<OperatorIndexes>().OrderBy(v => v.Index).ToList<OperatorIndexes>();
            }
            return operatorIndexes;
        }

        private static List<OperatorIndexes> AllIndexesOf(string str, string value)
        {
            if (String.IsNullOrEmpty(value))
                throw new ArgumentException("the string to find may not be empty", "value");
            List<OperatorIndexes> indexes = new List<OperatorIndexes>();
            for (int index = 0; ; index += value.Length)
            {
                index = str.IndexOf(value, index);
                if (index == -1)
                    return indexes;
                indexes.Add(new OperatorIndexes
                {
                    Index = index,
                    Operator = value
                });
            }
        }

        private static Expression GetExpression<TSource>(string[] searchTerms, string keyword, string propertyName,
           List<OperatorIndexes> operatorIndexes, ParameterExpression pe, bool addParentObjectNullCheck)
        {
            // Compose the expression tree that represents the parameter to the predicate.
            Expression propertyExp = pe;
            foreach (var member in propertyName.Split('.'))
            {
                propertyExp = Expression.PropertyOrField(propertyExp, member);
            }
            Expression searchExpression = null;
            Expression finalExpression = null;
            Expression nullorEmptyCheck = null;
            var left = Expression.Call(propertyExp, typeof(string).GetMethod("ToLower", Type.EmptyTypes));
            var method = typeof(string).GetMethod("Contains", new[] { typeof(string) });
            for (int count = 0; count < searchTerms.Length; count++)
            {
                var searchTerm = searchTerms[count].ToLower();
                searchTerm = searchTerm.Replace("*", string.Empty);
                searchTerm = searchTerm.Replace("\"", string.Empty);
                Expression methodCallExpresssion = null;
                Expression rightExpression = null;
                if (searchTerm.Contains(NotOperator.TrimStart()))
                {
                    searchTerm = searchTerm.Replace(NotOperator.TrimStart(), string.Empty).Trim();
                    rightExpression = Expression.Constant(searchTerm);
                    methodCallExpresssion = Expression.Call(left, method, rightExpression);
                    methodCallExpresssion = Expression.Not(methodCallExpresssion);
                }
                else
                {
                    rightExpression = Expression.Constant(searchTerm);
                    methodCallExpresssion = Expression.Call(left, method, rightExpression);
                }

                if (count == 0)
                {
                    searchExpression = methodCallExpresssion;
                }
                else
                {
                    var conditionOperator = operatorIndexes[count - 1].Operator.Trim();
                    switch (conditionOperator)
                    {
                        case "and":
                            searchExpression = Expression.AndAlso(searchExpression, methodCallExpresssion);
                            break;
                        case "or":
                            searchExpression = Expression.OrElse(searchExpression, methodCallExpresssion);
                            break;
                        default:
                            break;
                    }
                }
            }

            if (addParentObjectNullCheck)
            {
                var nullCheck = Expression.NotEqual(Expression.PropertyOrField(pe, "Value"), Expression.Constant(null, typeof(object)));
                nullorEmptyCheck = Expression.Not(Expression.Call(typeof(string), (typeof(string).GetMethod("IsNullOrEmpty")).Name, null, propertyExp));
                finalExpression = Expression.AndAlso(nullCheck, nullorEmptyCheck);
                finalExpression = Expression.AndAlso(finalExpression, searchExpression);
            }
            else
            {
                nullorEmptyCheck = Expression.Not(Expression.Call(typeof(string), (typeof(string).GetMethod("IsNullOrEmpty")).Name, null, propertyExp));
                finalExpression = Expression.AndAlso(nullorEmptyCheck, searchExpression);
            }

            return finalExpression;
        }
    }

    internal class OperatorIndexes
    {
        public int Index { get; set; }
        public string Operator { get; set; }
    }

}
