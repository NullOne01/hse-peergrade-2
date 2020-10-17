using System;
using HSEPeergrade2.Extensions;
using HSEPeergrade2.Localization;

namespace HSEPeergrade2
{
    public static class MethodsOutput
    {
        /// <summary>
        /// Printing <paramref name="arr"/> elements into the console.
        /// Elements are separated by <paramref name="separator"/>.
        /// </summary>
        /// <param name="arr"> Array to print. </param>
        /// <param name="separator"> Separator of array elements. </param>
        /// <typeparam name="T"> Type of array elements. </typeparam>
        public static void PrintArray<T>(T[] arr, string separator)
        {
            foreach (var element in arr)
            {
                PrintString(element + separator);
            }
        }
        
        /// <summary>
        /// Printing <paramref name="arr"/> elements into the console.
        /// Elements are separated by NewLine character.
        /// </summary>
        /// <param name="arr"> <inheritdoc cref="PrintArray{T}(T[],string)"/> </param>
        /// <typeparam name="T"> <inheritdoc cref="PrintArray{T}(T[],string)"/> </typeparam>
        public static void PrintArray<T>(T[] arr)
        {
            PrintArray(arr, Environment.NewLine);
        }

        /// <summary>
        /// Printing <paramref name="line"/> into the console with formatting <paramref name="args"/>.
        /// </summary>
        /// <param name="line"> Line to print. </param>
        /// <param name="args"> Arguments for <paramref name="line"/>. </param>
        public static void PrintString(string line, params object[] args)
        {
            Console.Write(line.BetterFormat(args));
        }
        
        /// <summary>
        /// <inheritdoc cref="PrintString"/>
        /// Skips line after.
        /// </summary>
        /// <param name="line"> <inheritdoc cref="PrintString"/> </param>
        /// <param name="args"> <inheritdoc cref="PrintString"/> </param>
        public static void PrintStringLine(string line, params object[] args)
        {
            Console.WriteLine(line.BetterFormat(args));
        }

        /// <summary>
        /// Just skipping 1 line in console.
        /// </summary>
        public static void SkipLine()
        {
            Console.WriteLine();
        }

        /// <summary>
        /// Writing localized value by <paramref name="key"/> into the console with formatting <paramref name="args"/>.
        /// </summary>
        /// <param name="key"> The key of a localized value. </param>
        /// <param name="args"> Arguments for <paramref name="key"/>. </param>
        public static void PrintLocalString(string key, params object[] args)
        {
            Console.Write(LocalizationManager.getInstance().GetLocalizedValue(key, args));
        }
        
        /// <summary>
        /// <inheritdoc cref="PrintLocalString"/>
        /// Skips line after.
        /// </summary>
        /// <param name="key"> <inheritdoc cref="PrintLocalString"/> </param>
        /// <param name="args"> <inheritdoc cref="PrintLocalString"/> </param>
        public static void PrintLocalStringLine(string key, params object[] args)
        {
            Console.WriteLine(LocalizationManager.getInstance().GetLocalizedValue(key, args));
        }
    }
}