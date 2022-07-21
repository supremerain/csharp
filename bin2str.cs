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
        int bufpos = 0;
        
    }
}
