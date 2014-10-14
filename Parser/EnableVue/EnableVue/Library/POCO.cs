using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Library.POCO
{
    public class Batch_DTO
    {
        public int batch_Number { get; set; }
        public DateTime startTime { get; set; }
        public DateTime endTime { get; set; }
        public int filesProcessed { get; set; }
        public int filesFailed { get; set; }
    }

    public class Settings_DTO
    {
        public int id { get; set; }
        public string folderPath { get; set; }
        public string webURL { get; set; }
    }

    public class FilesProcessed_GridView
    {
        public string FileName { get; set; }
        public string SubscriptionID{ get; set; }
        public string Title { get; set; }
        public string Category { get; set; }
        public bool parsed{ get; set; }
        public bool uploaded { get; set; }
        public bool error { get; set; }
    }

    public class Log_GridView
    {
        public int Id { get; set; }
        public DateTime Timestamp { get; set; }
        public string Log { get; set; }
    }
}
