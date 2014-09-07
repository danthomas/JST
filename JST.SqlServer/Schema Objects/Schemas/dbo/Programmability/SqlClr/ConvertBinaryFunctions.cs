//------------------------------------------------------------------------------
// <copyright file="CSSqlFunction.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation.  All rights reserved.
// </copyright>
//------------------------------------------------------------------------------
using System;
using System.Collections;
using System.Data.SqlTypes;
using Microsoft.SqlServer.Server;

public class ConvertBinaryFunctions
{
    #region ConvertBinaryToInt

    /// <summary>
    /// Converts the binary array to table of int values.  
    /// Note the order may be reversed or otherwise not gauranteed; could be wrapped in a sorted function/temp table with PK if this is required.
    /// </summary>
    /// <param name="sqlBinaryArray">The SQL binary array of ints.</param>
    /// <returns>Table of ints</returns>
    /// <author>barnetp</author>
    /// <createdDate>24/02/2014</createdDate>
    [SqlFunction(Name = "ConvertBinaryToInt", FillRowMethodName = "ConvertBinaryToInt_FillRow", TableDefinition = "Value int", IsPrecise = true, IsDeterministic = false, DataAccess = DataAccessKind.None, SystemDataAccess = SystemDataAccessKind.None)]
    public static IEnumerable ConvertBinaryToInt(SqlBytes sqlBinaryArray)
    {
        if (sqlBinaryArray.IsNull) return new Int32[] { };

        byte[] byteArrayOfInt32s = sqlBinaryArray.Value;
        Int32[] int32ArrayOfInts = new Int32[byteArrayOfInt32s.Length / 4];

        for (int pos = 0; pos < int32ArrayOfInts.Length; pos++)
            int32ArrayOfInts[pos] = BitConverter.ToInt32(byteArrayOfInt32s, pos * 4);

        return int32ArrayOfInts;
    }

    public static void ConvertBinaryToInt_FillRow(object item, out SqlInt32 id)
    {
        id = new SqlInt32((Int32)item);
    }

    #endregion ConvertBinaryToInt

    #region ConvertBinaryToSmallInt

    /// <summary>
    /// Converts the binary array to table of smallint values.  
    /// Note the order may be reversed or otherwise not gauranteed; could be wrapped in a sorted function/temp table with PK if this is required.
    /// </summary>
    /// <param name="sqlBinaryArray">The SQL binary array of int16s.</param>
    /// <returns>Table of smallints</returns>
    /// <author>barnetp</author>
    /// <createdDate>24/02/2014</createdDate>
    [SqlFunction(Name = "ConvertBinaryToSmallInt", FillRowMethodName = "ConvertBinaryToSmallInt_FillRow", TableDefinition = "Value smallint", IsPrecise = true, IsDeterministic = false, DataAccess = DataAccessKind.None, SystemDataAccess = SystemDataAccessKind.None)]
    public static IEnumerable ConvertBinaryToSmallInt(SqlBytes sqlBinaryArray)
    {
        if (sqlBinaryArray.IsNull) return new Int16[] { };

        byte[] byteArrayOfInt16s = sqlBinaryArray.Value;
        Int16[] int16ArrayOfInts = new Int16[byteArrayOfInt16s.Length / 2];

        for (int pos = 0; pos < int16ArrayOfInts.Length; pos++)
            int16ArrayOfInts[pos] = BitConverter.ToInt16(byteArrayOfInt16s, pos * 2);

        return int16ArrayOfInts;
    }

    public static void ConvertBinaryToSmallInt_FillRow(object item, out SqlInt16 id)
    {
        id = new SqlInt16((Int16)item);
    }

    #endregion ConvertBinaryToSmallInt

}
