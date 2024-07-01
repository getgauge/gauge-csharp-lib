/*----------------------------------------------------------------
 *  Copyright (c) ThoughtWorks, Inc.
 *  Licensed under the Apache License, Version 2.0
 *  See LICENSE.txt in the project root for license information.
 *----------------------------------------------------------------*/
using System;
using System.Reflection;
using System.Runtime.Serialization.Json;
using System.IO;
using System.Text;
using System.Collections.Generic;
using System.Linq;

namespace Gauge.CSharp.Lib
{
    /// <summary>
    ///     Holds a matrix of data, that is equivalent to Markdown representation of a table, or tablular data defined in a csv
    ///     file.
    /// </summary>
    [Serializable]
    public class Table
    {
        private readonly List<string> _headers;
        private readonly List<List<string>> _rows;
        private readonly List<TableRow> _tableRows;

        /// <summary>
        ///     Creates a new Table type
        /// </summary>
        /// <param name="headers">A List of string representing the headers, in order.</param>
        public Table(List<string> headers)
        {
            _headers = headers;
            _rows = new List<List<string>>();
            _tableRows = new List<TableRow>();
        }

        /// <summary>
        ///     Creates a new Table type from JSON string
        /// </summary>
        /// <param name="asJson">A JSON string representing the Table object.</param>
        public Table(string asJSon)
        {
            var serializer = new DataContractJsonSerializer(typeof(Table));
            using (var ms = new MemoryStream(Encoding.UTF8.GetBytes(asJSon)))
            {
                var deserializedTable = serializer.ReadObject(ms) as Table;
                if (deserializedTable != null)
                {
                    // Use LINQ with reflection to copy properties
                    typeof(Table).GetFields(BindingFlags.NonPublic | BindingFlags.Instance)
                        .ToList()
                        .ForEach(field => field.SetValue(this, field.GetValue(deserializedTable)));
                }
                else
                {
                    throw new ArgumentException("Invalid JSON string for Table deserialization.");
                }
            }
        }

        public Table FromJSon(string asJSon)
	    {
            var serializer = new DataContractJsonSerializer(typeof(Table));
            using (var ms = new MemoryStream(Encoding.UTF8.GetBytes(asJSon)))
            {
                var obj = serializer.ReadObject(ms);
                return obj as Table;
            }
	    }

        /// <summary>
        ///     Add a row of data to the table.
        /// </summary>
        /// <param name="row">List of string representing the tuple of a table.</param>
        /// <exception cref="RowSizeMismatchException">Throws RowSizeMismatchException if column size doesn't match row size.</exception>
        public void AddRow(List<string> row)
        {
            if (row.Count != _headers.Count)
                throw new RowSizeMismatchException(string.Format(
                    "Row size mismatch. Expected row size: {0}, Obtained row size: {1}", _headers.Count, row.Count));
            _rows.Add(row);
            var tableRow = new TableRow();
            foreach (var columnValue in _headers)
                tableRow.AddCell(columnValue, row[_headers.IndexOf(columnValue)]);
            _tableRows.Add(tableRow);
        }

        /// <summary>
        ///     Fetch all column headers of a table.
        /// </summary>
        /// <returns>List of string representing the column headers of table.</returns>
        public List<string> GetColumnNames()
        {
            return _headers;
        }

        /// <summary>
        ///     Fetch all the rows of a table, in order.
        /// </summary>
        /// <returns>List of string representing the tuples of a table.</returns>
        [Obsolete("Method GetRows is deprecated, please use GetTableRows instead.")]
        public List<List<string>> GetRows()
        {
            return _rows;
        }

        /// <summary>
        ///     Fetch all the rows of a table represented as TableRow.
        /// </summary>
        /// <returns>List of TableRow representing the tuples of a table.</returns>
        public List<TableRow> GetTableRows()
        {
            return _tableRows;
        }

        /// <summary>
        ///     Fetches all the column values defined under the given column name
        /// </summary>
        /// <param name="columnName">Name of the Column to fetch</param>
        /// <returns>IEnumerable of string containing the given column's values</returns>
        public IEnumerable<string> GetColumnValues(string columnName)
        {
            var columnIndex = _headers.IndexOf(columnName);
            return columnIndex >= 0 ? _rows.Select(list => list[columnIndex]) : Enumerable.Empty<string>();
        }

        /// <summary>
        ///     Converts the table to the Markdown equivalent string
        /// </summary>
        /// <returns>Markdown String of Table</returns>
        public override string ToString()
        {
            IEnumerable<string> columnStrings = new string[_rows.Count + 2];
            foreach (var header in GetColumnNames())
            {
                var columnValues = GetColumnValues(header).ToList();
                var columnWidth = columnValues.Concat(new[] {header}).Max(s => s.Length);
                string formatCellValue(string s) => string.Format("|{0}", s.PadRight(columnWidth, ' '));
                var paddedColumn = new[] {header, new string('-', columnWidth)}.Concat(columnValues)
                    .Select(formatCellValue);
                columnStrings = columnStrings.Zip(paddedColumn, string.Concat);
            }
            return string.Concat(columnStrings.Aggregate((s, s1) => string.Format("{0}|\n{1}", s, s1)), "|");
        }
    }
}