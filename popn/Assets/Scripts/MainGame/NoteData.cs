using System;

namespace NoteClass
{
    public enum NoteType
    {
        Normal,
        Long,
        Bar,
        SpeedChange,
    }
    [Serializable]
    public class NoteData : IComparable
    {
        public NoteType type;
        public Int32 line;
        public Single timing;
        public Single otherInfo;

        public int CompareTo(object obj)
        {
            if (this.timing > (obj as NoteData).timing) return 1;
            else if (this.timing == (obj as NoteData).timing) return 0;
            else return -1;
        }

        public override string ToString()
        {
            return $"Type : {type}, Line : {line}, timing : {timing}, otherInfo : {otherInfo}";
        }
    }
}