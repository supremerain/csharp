// csc /target:exe str2bin.cs
using System;
using System.Text;
using System.IO;

class Str2bin {
    static void Main(string[] args) {
        FileStream fs = new FileStream(@args[0], FileMode.Open, FileAccess.Read);
        
        int fileSize = (int)fs.Length;
        byte[] buf = new byte[fileSize];
        
        int readSize;
        int remain = fileSize;
        int bufPos = 0;
        
        Console.WriteLine("filesize={0}Byte(s)", fileSize);
        
        while (remain > 0) {
            readSize = fs.Read(buf, bufPos, Math.Min(1024, remain));
            
            bufPos += readSize;
            remain -= readSize;
        }
        
        Console.WriteLine("read file complete..", fileSize);
        fs.Dispose();
        
        String str = System.Text.Encoding.ASCII.GetString(buf);
        byte[] binData = new byte[fileSize / 2];
        int remain_out = 0;
        
        for(int i = 0; i < str.Length; i += 2){
            int value = Convert.ToInt32(str.Substring(i,2), 16);
            binData[remain_out] = (byte)value;
            remain_out++;
        }
        
        File.WriteAllBytes(@args[1], binData);
        Console.WriteLine("write file complete.");
    }
}
