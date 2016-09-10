using System;
using System.Collections.Generic; 
using System.Runtime.InteropServices;
using System.Threading;

namespace Tanks
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct ConsoleFont
    {
        public uint Index;
        public short SizeX, SizeY;
    }

    public static class ConsoleHelper
    {
        [DllImport("kernel32")]
        private extern static bool SetConsoleFont(IntPtr hOutput, uint index);

        private enum StdHandle
        {
            OutputHandle = -11
        }

        [DllImport("kernel32")]
        private static extern IntPtr GetStdHandle(StdHandle index);

        public static bool SetConsoleFont(uint index)
        {
            return SetConsoleFont(GetStdHandle(StdHandle.OutputHandle), index);
        }

        [DllImport("kernel32")]
        private static extern bool GetConsoleFontInfo(IntPtr hOutput, [MarshalAs(UnmanagedType.Bool)]bool bMaximize,
            uint count, [MarshalAs(UnmanagedType.LPArray), Out] ConsoleFont[] fonts);

        [DllImport("kernel32")]
        private static extern uint GetNumberOfConsoleFonts();

        public static uint ConsoleFontsCount
        {
            get
            {
                return GetNumberOfConsoleFonts();
            }
        }

        public static ConsoleFont[] ConsoleFonts
        {
            get
            {
                ConsoleFont[] fonts = new ConsoleFont[GetNumberOfConsoleFonts()];
                if (fonts.Length > 0)
                    GetConsoleFontInfo(GetStdHandle(StdHandle.OutputHandle), false, (uint)fonts.Length, fonts);
                return fonts;
            }
        }

    }

    class Field
    {
        private const int FieldWidth = 80;
        private const int FieldHeight = 80;
        public const ConsoleColor FieldColor = ConsoleColor.Gray;
        
        public static int FieldWIDTH { get { return FieldWidth; } }
        public static int FieldHEIGHT { get { return FieldHeight; } }

        public static void CreateField()
        { 
            {
                Console.SetWindowSize((Console.LargestWindowWidth > FieldWidth) ? FieldWidth : Console.LargestWindowWidth, (Console.LargestWindowHeight > FieldHeight) ? FieldHeight: Console.LargestWindowHeight);
                Console.SetBufferSize(FieldWidth, FieldHeight); 
            }
            
             Console.BackgroundColor = FieldColor;
            Console.Clear();
            Console.CursorVisible = false;
        }

    }
}
