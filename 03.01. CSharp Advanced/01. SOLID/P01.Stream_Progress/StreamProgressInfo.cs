using System;
using System.Collections.Generic;
using System.Text;

namespace P01.Stream_Progress
{
    public class StreamProgressInfo
    {
        private IStreamProgressInfo iSstreamProgress;

        public StreamProgressInfo(IStreamProgressInfo streamProgressInfo)
        {
            this.iSstreamProgress = streamProgressInfo;
        }

        public int CalculateCurrentPercent()
        {
            return (this.iSstreamProgress.BytesSent * 100) / this.iSstreamProgress.Length;
        }
    }
}
