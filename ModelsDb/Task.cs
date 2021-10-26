using System;

namespace ModelsDb
{
    public class Task
    {
        public int Id { get; set; }
        public DateTime? CreationTime { get; set; }
        public DateTime? ModificationTime { get; set; }
        public string Status { get; set; }
        public int ConsumerID { get; set; }
    }
}
