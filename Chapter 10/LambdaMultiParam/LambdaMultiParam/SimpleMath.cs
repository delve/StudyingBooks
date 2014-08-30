namespace LambdaMultiParam
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class SimpleMath
    {
        private CheezBrgr chzDelegate;

        public delegate string CheezBrgr();

        public event EventHandler<MathArgs> MathMessage;

        public void AddCheezBurgr(CheezBrgr target)
        {
            this.chzDelegate += target;
        }

        public void Add(int x, int y)
        {
            if (this.chzDelegate != null)
            {
                Console.WriteLine(this.chzDelegate());
            }

            if (this.MathMessage != null)
            {
                this.MathMessage(this, new MathArgs("Addition completed!", x + y));
            }
        }

        public class MathArgs
        {
            public readonly string Msg;
            public readonly int Result;

            public MathArgs(string message, int result)
            {
                this.Msg = message;
                this.Result = result;
            }
        }
    }
}
