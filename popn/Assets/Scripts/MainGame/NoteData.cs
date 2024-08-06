using System;

namespace NoteData
{
    public enum NoteType
    {
        Normal,
        Long,
        Bar,
        SpeedChange,
    }
    public class NoteData
    {
        public NoteType type;
        public Int32 line;
        public Single otherInfo;
    }
}