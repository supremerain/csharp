// csc /target:exe bin2str.cs
using System;
using System.Test;
using System.IO;

class Bin2str {
    static void Main(string[] args) {
        FileStream fs = new FileStream(@args[0], FileMode.Open, FileAccess.Read);
        
        int fileSize = (int)fs.Length;
        byte[] buf = new byte[fileSize];
        
        int readSize;
        int remain = fileSize;
        int bufPos = 0;
        
        Console.WriteLine("filesize={0}Byte(s)", fileSize);
        
        StringBuffer sb = new StringBuffer();
        while (remain > 0) {
            readSize = fs.Read(buf, bufPos, Math.Min(1024, remain));
            
            bufPos += readSize;
            remain -= readSize;
        }
        
        Console.WriteLine("read file complete..", fileSize);
        fs.Dispose();
        
        for(int i = 0; i < buf.Length; i++){
            sb.Append(buf[i].ToString("x2"));
        }
        
        File.WriteAllText(@args[1], sb.ToString());
        Console.WriteLine("write file complete.");
    }
}
